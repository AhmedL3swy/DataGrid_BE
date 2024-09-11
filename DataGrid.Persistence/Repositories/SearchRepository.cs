using DataGrid.Application.Contracts;
using DataGrid.Application.Shared.Models;
using DataGrid.Persistence.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DataGrid.Persistence.Repositories
{
    internal class SearchRepository<T, S> : ISearchRepository<T, S> where T : class where S : class
    {
        private readonly ProductDbContext _context;
        public SearchRepository(
            ProductDbContext context

            )
        {
            _context = context;
        }
        public async Task<List<T>> SearchAsync(SearchQuery<S> query)
        {
            // init Query
            IQueryable<T> products = _context.Set<T>();

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
                var sortProperty = typeof(T).GetProperty(query.SortBy);
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

