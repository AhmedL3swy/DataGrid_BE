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

            // Search
            if (query.Search != null && query.Search.Any())
            {
                foreach (var searchObject in query.Search)
                {
                    if (searchObject.Value != null)
                    {
                        var propertyType = typeof(Product).GetProperty(searchObject.Key)?.PropertyType;
                        products = products.SortByPropertyTypeAndValue(propertyType, searchObject.Key, searchObject.Value);
                    }
                }
            }

            // sort 
            if (query.Sort != null && query.Sort.Any())
            {
                foreach (var sortObject in query.Sort)
                {
                    products = products.OrderBy(p => EF.Property<string>(p, sortObject.Name));
                }
            }


            // paging
            products = products
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);
            // Excute the Query!!
            return await products.ToListAsync();
        }

    }
}

