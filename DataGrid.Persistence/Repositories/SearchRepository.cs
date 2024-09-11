using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using DataGrid.Persistence.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

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

