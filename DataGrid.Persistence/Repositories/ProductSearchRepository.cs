using DataGrid.Application.Contracts;
using DataGrid.Application.Features.Products.Queries.Search;
using DataGrid.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Product>> SearchAsync(SearchProductQuery query)
        {
            // Start the query
            IQueryable<Product> products = _context.Products;

            // Apply search filter
            if (!string.IsNullOrEmpty(query.SearchValue))
            {
                products = products.Where(p => p.Name.Contains(query.SearchValue) || p.Description.Contains(query.SearchValue));
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                products = query.SortDirection == "desc"
                    ? products.OrderByDescending(p => EF.Property<object>(p, query.SortBy))
                    : products.OrderBy(p => EF.Property<object>(p, query.SortBy));
            }

            // Apply pagination
            products = products
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);

            return await products.ToListAsync();
        }
    }
}

