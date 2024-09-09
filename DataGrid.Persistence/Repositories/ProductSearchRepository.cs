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
            // init Query
            IQueryable<Product> products = _context.Products;

            //  search 
            if (!string.IsNullOrEmpty(query.SearchValue))
            {
                products = products.Where(p => p.Name.Contains(query.SearchValue));
            }

            // sort 
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                products = query.SortDirection == SortDirection.Descending
                    ? products.OrderByDescending(p => EF.Property<object>(p, query.SortBy))
                    : products.OrderBy(p => EF.Property<object>(p, query.SortBy));
            }

            // paging
            products = products
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);

            return await products.ToListAsync();
        }
    }
}

