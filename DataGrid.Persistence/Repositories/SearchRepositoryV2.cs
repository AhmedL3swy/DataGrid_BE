using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using DataGrid.Persistence.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataGrid.Persistence.Repositories
{
    internal class SearchRepositoryV2<DbSet> : ISearchRepositoryV2<DbSet> where DbSet : class
    {
        private readonly ProductDbContext _context;

        public SearchRepositoryV2(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<SearchResult<DbSet>> SearchAsync(SearchQueryV2 query)
        {
            IQueryable<DbSet> entities = _context.Set<DbSet>();

            // Apply Keyword Search
            entities = ApplyKeywordSearch(entities, query.SearchByKeyword);

            // Apply Range Search
            entities = ApplyRangeSearch(entities, query.RangeSearch);


            // Apply Sorting
            entities = ApplySorting(entities, query.SortBy, query.SortDirection);

            // Apply Includes for related fields
            entities = ApplyIncludes(entities, query.Include);

            // Pagination
            var total = await entities.CountAsync();
            entities = ApplyPaging(entities, query.PageNumber, query.PageSize);

            var result = await entities.ToListAsync();

            return new SearchResult<DbSet>
            {
                Data = result,
                Total = total
            };
        }

        private IQueryable<DbSet> ApplyKeywordSearch(IQueryable<DbSet> query, List<SearchByKeyword> searchByKeywords)
        {
            if (searchByKeywords == null || !searchByKeywords.Any())
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(DbSet), "e");
            Expression finalExpression = null;

            foreach (var search in searchByKeywords)
            {
                Expression keywordExpression = null;

                foreach (var field in search.FieldList)
                {
                    Expression propertyExpression = parameter;

                    // Support nested properties (e.g., Category.Name)
                    foreach (var part in field.Split('.'))
                    {
                        propertyExpression = Expression.Property(propertyExpression, part);
                    }

                    // Determine property type to build appropriate expression
                    var propertyType = propertyExpression.Type;

                    if (propertyType == typeof(string))
                    {
                        var keywordConstant = Expression.Constant(search.Keyword);
                        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var containsExpression = Expression.Call(propertyExpression, containsMethod, keywordConstant);

                        // Combine multiple field searches with OR
                        keywordExpression = keywordExpression == null
                            ? containsExpression
                            : Expression.OrElse(keywordExpression, containsExpression);
                    }
                    else if (propertyType == typeof(DateTime) || propertyType == typeof(DateOnly))
                    {
                        // Parse the keyword into DateOnly/DateTime
                        DateTime parsedDate;
                        if (!DateTime.TryParse(search.Keyword, out parsedDate))
                        {
                            throw new InvalidCastException($"Cannot parse '{search.Keyword}' to a valid {propertyType.Name}.");
                        }

                        Expression dateConstant = propertyType == typeof(DateOnly)
                            ? Expression.Constant(DateOnly.FromDateTime(parsedDate))
                            : Expression.Constant(parsedDate);

                        // Use Equals method for comparison
                        var equalsExpression = Expression.Equal(propertyExpression, dateConstant);

                        // Combine multiple field searches with OR
                        keywordExpression = keywordExpression == null
                            ? equalsExpression
                            : Expression.OrElse(keywordExpression, equalsExpression);
                    }
                    else if (propertyType.IsValueType)
                    {
                        // For other value types (int, decimal, etc.), use Equals method
                        var keywordConstant = Expression.Constant(Convert.ChangeType(search.Keyword, propertyType));
                        var equalsExpression = Expression.Equal(propertyExpression, keywordConstant);

                        // Combine multiple field searches with OR
                        keywordExpression = keywordExpression == null
                            ? equalsExpression
                            : Expression.OrElse(keywordExpression, equalsExpression);
                    }
                    else
                    {
                        // Add custom logic for other types if necessary
                        throw new NotSupportedException($"Search by field '{field}' with type '{propertyType}' is not supported.");
                    }
                }

                // Combine different SearchByKeyword with AND
                finalExpression = finalExpression == null
                    ? keywordExpression
                    : Expression.AndAlso(finalExpression, keywordExpression);
            }

            if (finalExpression != null)
            {
                var lambda = Expression.Lambda<Func<DbSet, bool>>(finalExpression, parameter);
                query = query.Where(lambda);
            }

            return query;
        }



        private IQueryable<DbSet> ApplyRangeSearch(IQueryable<DbSet> entities, List<RangeSearch> rangeSearches)
        {
            if (rangeSearches == null || !rangeSearches.Any()) return entities;

            foreach (var rangeSearch in rangeSearches)
            {
                // Start building the expression with the base parameter
                var parameter = Expression.Parameter(typeof(DbSet), "x");
                Expression propertyAccess = parameter;

                // Support nested properties (e.g., Category.Price or OrderDetails.OrderDate)
                foreach (var part in rangeSearch.Field.Split('.'))
                {
                    propertyAccess = Expression.Property(propertyAccess, part);
                }

                var propertyType = propertyAccess.Type;

                Expression minExpression = null;
                Expression maxExpression = null;

                if (propertyType == typeof(DateTime) || propertyType == typeof(DateOnly))
                {
                    // Handle DateTime and DateOnly ranges
                    DateTime minValue;
                    DateTime maxValue;

                    if (!DateTime.TryParse(rangeSearch.Start.ToString(), out minValue) ||
                        !DateTime.TryParse(rangeSearch.End.ToString(), out maxValue))
                    {
                        throw new InvalidCastException($"Cannot parse range values for field '{rangeSearch.Field}' as {propertyType.Name}.");
                    }

                    minExpression = propertyType == typeof(DateOnly)
                        ? Expression.Constant(DateOnly.FromDateTime(minValue))
                        : Expression.Constant(minValue);

                    maxExpression = propertyType == typeof(DateOnly)
                        ? Expression.Constant(DateOnly.FromDateTime(maxValue))
                        : Expression.Constant(maxValue);
                }
                else if (propertyType.IsValueType)
                {
                    // Handle numeric and other value types
                    var minValue = Convert.ChangeType(rangeSearch.Start, propertyType);
                    var maxValue = Convert.ChangeType(rangeSearch.End, propertyType);

                    minExpression = Expression.Constant(minValue);
                    maxExpression = Expression.Constant(maxValue);
                }
                else
                {
                    throw new NotSupportedException($"Range search for field '{rangeSearch.Field}' with type '{propertyType}' is not supported.");
                }

                // Create expressions for GreaterThanOrEqual and LessThanOrEqual
                var greaterThanOrEqual = Expression.GreaterThanOrEqual(propertyAccess, minExpression);
                var lessThanOrEqual = Expression.LessThanOrEqual(propertyAccess, maxExpression);

                // Combine both conditions with AND
                var andExpression = Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);
                var lambda = Expression.Lambda<Func<DbSet, bool>>(andExpression, parameter);

                // Apply the range filter to the query
                entities = entities.Where(lambda);
            }

            return entities;
        }




        private IQueryable<DbSet> ApplySorting(IQueryable<DbSet> entities, string sortBy, SortDirection sortDirection)
        {
            if (string.IsNullOrEmpty(sortBy)) return entities;

            var parameter = Expression.Parameter(typeof(DbSet), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);

            var orderByMethod = sortDirection == SortDirection.Ascending
                ? nameof(Queryable.OrderBy)
                : nameof(Queryable.OrderByDescending);

            var resultExpression = Expression.Call(
                typeof(Queryable),
                orderByMethod,
                new Type[] { typeof(DbSet), property.Type },
                entities.Expression,
                lambda
            );

            return entities.Provider.CreateQuery<DbSet>(resultExpression);
        }

        private IQueryable<DbSet> ApplyIncludes(IQueryable<DbSet> entities, string includeFields)
        {
            if (string.IsNullOrEmpty(includeFields)) return entities;

            foreach (var include in includeFields.Split(','))
            {
                entities = entities.Include(include);
            }

            return entities;
        }

        private IQueryable<DbSet> ApplyPaging(IQueryable<DbSet> entities, int pageNumber, int pageSize)
        {
            return entities.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

    }
}
