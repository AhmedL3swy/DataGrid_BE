using DataGrid.Application.Contracts;
using DataGrid.Application.Features.Products.Queries.Search;
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
        public async Task<List<Product>> SearchAsync(SearchProductQuery query)
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

            //// sort 
            //if (query.Sort != null && query.Sort.Any())
            //{
            //    foreach (var sortObject in query.Sort)
            //    {
            //        products = products.OrderByProperty(sortObject.Key, sortObject.Value);
            //    }
            //}

            // paging
            products = products
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize);
            // Execute the Query!!
            return await products.ToListAsync();
        }

    }


    

}

