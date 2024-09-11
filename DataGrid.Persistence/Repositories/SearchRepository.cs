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
        public async Task<List<DbSet>> SearchAsync(SearchQuery<DbSet,SearchObj> query)
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

            // paging
            products = products.Paging(query.PageNumber, query.PageSize);

            // Execute the Query!!
            return await products.ToListAsync();
        }

    }




}

