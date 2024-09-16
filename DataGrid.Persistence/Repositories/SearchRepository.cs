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
    internal class SearchRepository<DbSet, SearchObj> : ISearchRepository<DbSet, SearchObj> where DbSet : class where SearchObj : class
    {
        private readonly ProductDbContext _context;
        public SearchRepository(
            ProductDbContext context
        )
        {
            _context = context;
        }
        public async Task<SearchResult<DbSet>> SearchAsync(SearchQuery<DbSet, SearchObj> query)
        {
            // init Query
            IQueryable<DbSet> products = _context.Set<DbSet>();

            // Range Search
            if (query.RangeSearch != null)
            {
                foreach (var rangeSearch in query.RangeSearch)
                {
                    var property = typeof(DbSet).GetProperty(rangeSearch.Field);
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(int))
                        {

                            products = products.FilterByRange(rangeSearch.Field, rangeSearch.StartInt, rangeSearch.EndInt);
                        }
                        if (property.PropertyType == typeof(decimal))
                        {

                            products = products.FilterByRange(rangeSearch.Field, rangeSearch.StartDecimal, rangeSearch.EndDecimal);
                        }
                        if (property.PropertyType == typeof(DateTime))
                        {

                            products = products.FilterByRange(rangeSearch.Field, rangeSearch.StartDateTime, rangeSearch.EndDateTime);
                        }
                        if (property.PropertyType == typeof(DateOnly))
                        {

                            products = products.FilterByRange(rangeSearch.Field, rangeSearch.StartDateOnly, rangeSearch.EndDateOnly);
                        }

                    }
                }
            }

            // Search
            if (query.Search != null)
            {
                // Get the properties of SearchViewModel
                var searchProperties = query.Search.GetType().GetProperties().Where(p => p.GetValue(query.Search) != null).ToList();
                products = products.Search(query.Search, searchProperties);
            }

            // sort 
            if (query.SortBy != null && !string.IsNullOrEmpty(query.SortBy))
            {
                var sortProperty = typeof(DbSet).GetProperty(query.SortBy);
                if (sortProperty != null)
                {
                    products = products.Sort(query.SortBy, query.SortDirection);
                }
            }
            // Nested Search with NestedSearchField and NestedSearchValue
            if (query.NestedSearch != null)
            {
                foreach (var nestedSearch in query.NestedSearch)
                {
                    var property = typeof(DbSet).GetProperty(nestedSearch.RelativePath.Split('.')[0]);

                    if (property != null)
                    {

                        int intValue;
                        if (int.TryParse(nestedSearch.Value, out intValue))
                        {
                            products = products.Where(CreateNestedSearchExpression(nestedSearch.RelativePath, intValue));
                        }
                        products = products.Where(CreateNestedSearchExpression(nestedSearch.RelativePath, nestedSearch.Value));



                    }
                }
            }

            // count total records before paging
            var total = await products.CountAsync();

            // paging
            products = products.Paging(query.PageNumber, query.PageSize);

            // Include if only its a property
            if (query.Include != null)
            {
                var Includes = query.Include.Split(',');

                foreach (var include in Includes)
                {
                    var includeProperty = typeof(DbSet).GetProperty(include);
                    if (includeProperty != null)
                    {
                        products = products.Include(include);
                    }
                }
            }

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



            // Execute the Query!!
            var result = await products.ToListAsync();

            return new SearchResult<DbSet>
            {
                Data = result,
                Total = total
            };
        }
    }




}

