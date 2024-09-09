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
    public static class QueryExtensions
    {
        public static IQueryable<Product> SearchPropertyTypeAndValue(this IQueryable<Product> products, Type propertyType, string key, object value)
        {
            if (propertyType == typeof(string))
            {
                return products.Where(p => EF.Property<string>(p, key).Contains(value.ToString()));
            }
            else if (propertyType == typeof(decimal))
            {
                if (decimal.TryParse(value.ToString(), out decimal decimalValue))
                {
                    return products.Where(p => EF.Property<decimal>(p, key) == decimalValue);
                }
            }
            return products;
        }
        public static IQueryable<Product> OrderByProperty(this IQueryable<Product> products, string propertyName, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
            {
                return products.OrderBy(p => EF.Property<string>(p, propertyName));
            }
            else
            {
                return products.OrderByDescending(p => EF.Property<string>(p, propertyName));
            }
        }

    }

}
