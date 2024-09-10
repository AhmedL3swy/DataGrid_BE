using DataGrid.Application.Contracts;
using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared;
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
    internal class ProductSearchRepository : ISearchRepository<Product>
    {
        private readonly ProductDbContext _context;
        public ProductSearchRepository(
            ProductDbContext context

            )
        {
            _context = context;
        }
        public async Task<List<Product>> SearchAsync(SearchQuery<SearchProductViewModel> query)
        {
            // init Query
            IQueryable<Product> products = _context.Products;

            // Search
            if (query.Search != null)
            {
                // Get the properties of SearchProductViewModel
                var searchProperties = query.Search.GetType().GetProperties().Where(p => p.GetValue(query.Search) != null).ToList();
                products = products.Search(query.Search, searchProperties);
            }

            // sort 
            if (query.SortBy != null && !string.IsNullOrEmpty(query.SortBy))
            {
                var sortProperty = typeof(Product).GetProperty(query.SortBy);
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

