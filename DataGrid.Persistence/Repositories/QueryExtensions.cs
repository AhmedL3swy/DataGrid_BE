using DataGrid.Application.Features.Search.Queries;
using DataGrid.Application.Shared.Models;
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
    public static class SearchExtensions
    {
        public static IQueryable<Product> Search(this IQueryable<Product> products, SearchProductViewModel searchObj, IEnumerable<PropertyInfo> searchProperties)
        {
            foreach (var property in searchProperties)
            {
                var value = property.GetValue(searchObj);
                if (value != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        products = products.FilterByString(property.Name, (string)value);
                    }
                    else if (property.PropertyType == typeof(int?))
                    {
                        products = products.FilterByInt(property.Name, (int)value);
                    }
                    else if (property.PropertyType == typeof(decimal))
                    {
                        products = products.FilterByDecimal(property.Name, (decimal)value);
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        products = products.FilterByDouble(property.Name, (double)value);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        products = products.FilterByDateTime(property.Name, (DateTime)value);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        products = products.FilterByBool(property.Name, (bool)value);
                    }
                }
            }

            return products;
        }

        public static IQueryable<Product> FilterByString(this IQueryable<Product> products, string propertyName, string value)
        {
            return products.Where(p => EF.Property<string>(p, propertyName).Contains(value));
        }

        public static IQueryable<Product> FilterByInt(this IQueryable<Product> products, string propertyName, int value)
        {
            return products.Where(p => EF.Property<int>(p, propertyName) == value);
        }

        public static IQueryable<Product> FilterByDecimal(this IQueryable<Product> products, string propertyName, decimal value)
        {
            return products.Where(p => EF.Property<decimal>(p, propertyName) == value);
        }

        public static IQueryable<Product> FilterByDouble(this IQueryable<Product> products, string propertyName, double value)
        {
            return products.Where(p => EF.Property<double>(p, propertyName) == value);
        }

        public static IQueryable<Product> FilterByDateTime(this IQueryable<Product> products, string propertyName, DateTime value)
        {
            return products.Where(p => EF.Property<DateTime>(p, propertyName) == value);
        }

        public static IQueryable<Product> FilterByBool(this IQueryable<Product> products, string propertyName, bool value)
        {
            return products.Where(p => EF.Property<bool>(p, propertyName) == value);
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
        public static IQueryable<Product> Sort(this IQueryable<Product> products, SortObject sortObject)
        {
            return products.OrderByProperty(sortObject.Field, sortObject.Direction);
        }
        public static IQueryable<Product> Paging(this IQueryable<Product> products, int pageNumber, int pageSize)
        {
            return products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
