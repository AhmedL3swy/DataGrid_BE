using DataGrid.Application.Contracts;
using DataGrid.Application.Features.Search.Queries;
using DataGrid.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Persistence.Repositories
{
    internal class ProductSearchRepository<T> : ISearchRepository<T> where T : class
    {
        private readonly ProductDbContext _context;
        public ProductSearchRepository(
            ProductDbContext context

            )
        {
            _context = context;
        }
        public async Task<List<T>> SearchAsync(SearchProductQuery<T> query)
        {
            IQueryable<T> items = _context.Set<T>();

            // Search
            if (query.Search != null)
            {
                var searchProperties = query.Search.GetType().GetProperties().Where(p => p.GetValue(query.Search) != null).ToList();
                items = items.Search(query.Search, searchProperties);
            }

            // Sort
            if (query.Sort != null && !string.IsNullOrEmpty(query.Sort.Field))
            {
                var sortProperty = typeof(T).GetProperty(query.Sort.Field);
                if (sortProperty != null)
                {
                    items = items.Sort(query.Sort);
                }
            }

            // Paging
            items = items.Paging(query.PageNumber, query.PageSize);

            return await items.ToListAsync();
        }

    }




}

