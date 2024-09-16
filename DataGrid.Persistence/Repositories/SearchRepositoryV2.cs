using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using DataGrid.Domain;
using DataGrid.Persistence.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Linq.Expressions;

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

            if (query.RangeSearch != null)
            {
                foreach (var rangeSearch in query.RangeSearch)
                {
                    var property = typeof(DbSet).GetProperty(rangeSearch.Field);
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(int))
                        {
                            entities = entities.FilterByRange(rangeSearch.Field, rangeSearch.StartInt, rangeSearch.EndInt);
                        }
                        else if (property.PropertyType == typeof(decimal))
                        {
                            entities = entities.FilterByRange(rangeSearch.Field, rangeSearch.StartDecimal, rangeSearch.EndDecimal);
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {
                            entities = entities.FilterByRange(rangeSearch.Field, rangeSearch.StartDateTime, rangeSearch.EndDateTime);
                        }
                        else if (property.PropertyType == typeof(DateOnly))
                        {
                            entities = entities.FilterByRange(rangeSearch.Field, rangeSearch.StartDateOnly, rangeSearch.EndDateOnly);
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(query.SearchKeyword))
            {
                var hasArName = entities.Any(e => EF.Property<string>(e, "ArName") != null);
                var hasEnName = entities.Any(e => EF.Property<string>(e, "EnName") != null);
                if (!hasArName && hasEnName)
                {
                    entities = entities.Where(e => EF.Property<string>(e, "EnName").Contains(query.SearchKeyword));
                }
                else if (!hasEnName && hasArName)
                {
                    entities = entities.Where(e => EF.Property<string>(e, "ArName").Contains(query.SearchKeyword));
                }
                else if (hasArName && hasEnName)
                {
                    entities = entities.Where(e => EF.Property<string>(e, "ArName").Contains(query.SearchKeyword) || EF.Property<string>(e, "EnName").Contains(query.SearchKeyword));
                }
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var sortProperty = typeof(DbSet).GetProperty(query.SortBy);
                if (sortProperty != null)
                {
                    entities = entities.Sort(query.SortBy, query.SortDirection);
                }
            }

            if (query.NestedSearch != null)
            {
                foreach (var nestedSearch in query.NestedSearch)
                {
                    var property = typeof(DbSet).GetProperty(nestedSearch.RelativePath.Split('.')[0]);

                    if (property != null && nestedSearch.Value != null && !string.IsNullOrEmpty(nestedSearch.Value))
                    {
                        if (int.TryParse(nestedSearch.Value, out int intValue))
                        {
                            entities = entities.Where(CreateNestedSearchExpression(nestedSearch.RelativePath, intValue));
                        }
                        entities = entities.Where(CreateNestedSearchExpression(nestedSearch.RelativePath, nestedSearch.Value));
                    }
                }
            }




            var total = await entities.CountAsync();

            entities = entities.Paging(query.PageNumber, query.PageSize);

            if (!string.IsNullOrEmpty(query.Include))
            {
                var includes = query.Include.Split(',');

                foreach (var include in includes)
                {
                    var includeProperty = typeof(DbSet).GetProperty(include);
                    if (includeProperty != null)
                    {
                        entities = entities.Include(include);
                    }
                }
            }
            // p=>p.Categoery.CategoryName =="Value"
            Expression<Func<DbSet, bool>> CreateNestedSearchExpression(string propertyName, object value)
            {
                var parameter = Expression.Parameter(typeof(DbSet), "p");
                var parts = propertyName.Split('.');
                Expression body = parameter;

                foreach (var part in parts)
                {
                    body = Expression.Property(body, part);
                }

                var propertyType = body.Type;
                var constant = Expression.Constant(Convert.ChangeType(value, propertyType));
                var equals = Expression.Equal(body, constant);

                return Expression.Lambda<Func<DbSet, bool>>(equals, parameter);
            }

            var result = await entities.ToListAsync();

            return new SearchResult<DbSet>
            {
                Data = result,
                Total = total
            };
        }
    }




}

