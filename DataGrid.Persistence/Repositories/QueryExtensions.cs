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
        public static IQueryable<T> Search<T>(this IQueryable<T> items, T searchObj, IEnumerable<PropertyInfo> searchProperties) where T : class
        {
            foreach (var property in searchProperties)
            {
                var value = property.GetValue(searchObj);
                if (value != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        items = items.FilterByString(property.Name, (string)value);
                    }
                    else if (property.PropertyType == typeof(int?))
                    {
                        items = items.FilterByInt(property.Name, (int)value);
                    }
                    else if (property.PropertyType == typeof(decimal))
                    {
                        items = items.FilterByDecimal(property.Name, (decimal)value);
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        items = items.FilterByDouble(property.Name, (double)value);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        items = items.FilterByDateTime(property.Name, (DateTime)value);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        items = items.FilterByBool(property.Name, (bool)value);
                    }
                }
            }

            return items;
        }

        public static IQueryable<T> FilterByString<T>(this IQueryable<T> products, string propertyName, string value)
        {
            return products.Where(p => EF.Property<string>(p, propertyName).Contains(value));
        }

        public static IQueryable<T> FilterByInt<T>(this IQueryable<T> products, string propertyName, int value)
        {
            return products.Where(p => EF.Property<int>(p, propertyName) == value);
        }

        public static IQueryable<T> FilterByDecimal<T>(this IQueryable<T> products, string propertyName, decimal value)
        {
            return products.Where(p => EF.Property<decimal>(p, propertyName) == value);
        }

        public static IQueryable<T> FilterByDouble<T>(this IQueryable<T> products, string propertyName, double value)
        {
            return products.Where(p => EF.Property<double>(p, propertyName) == value);
        }

        public static IQueryable<T> FilterByDateTime<T>(this IQueryable<T> products, string propertyName, DateTime value)
        {
            return products.Where(p => EF.Property<DateTime>(p, propertyName) == value);
        }

        public static IQueryable<T> FilterByBool<T>(this IQueryable<T> products, string propertyName, bool value)
        {
            return products.Where(p => EF.Property<bool>(p, propertyName) == value);
        }

        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> products, string propertyName, SortDirection sortDirection)
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
        public static IQueryable<T> Sort<T>(this IQueryable<T> products, SortObject sortObject)
        {
            return products.OrderByProperty(sortObject.Field, sortObject.Direction);
        }
        public static IQueryable<T> Paging<T>(this IQueryable<T> products, int pageNumber, int pageSize)
        {
            return products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
