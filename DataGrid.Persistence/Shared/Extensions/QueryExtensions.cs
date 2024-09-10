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
        public static IQueryable<T> Search<T>(this IQueryable<T> entities, SearchProductViewModel searchObj, IEnumerable<PropertyInfo> searchProperties)
        {
            foreach (var property in searchProperties)
            {
                var value = property.GetValue(searchObj);
                if (value != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        entities = entities.FilterByString(property.Name, (string)value);
                    }
                    else if (property.PropertyType == typeof(int?))
                    {
                        entities = entities.FilterByInt(property.Name, (int)value);
                    }
                    else if (property.PropertyType == typeof(decimal))
                    {
                        entities = entities.FilterByDecimal(property.Name, (decimal)value);
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        entities = entities.FilterByDouble(property.Name, (double)value);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        entities = entities.FilterByDateTime(property.Name, (DateTime)value);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        entities = entities.FilterByBool(property.Name, (bool)value);
                    }
                }
            }

            return entities;
        }

        public static IQueryable<T> FilterByString<T>(this IQueryable<T> entities, string propertyName, string value)
        {
            return entities.Where(e => EF.Property<string>(e, propertyName).Contains(value));
        }

        public static IQueryable<T> FilterByInt<T>(this IQueryable<T> entities, string propertyName, int value)
        {
            return entities.Where(e => EF.Property<int>(e, propertyName) == value);
        }

        public static IQueryable<T> FilterByDecimal<T>(this IQueryable<T> entities, string propertyName, decimal value)
        {
            return entities.Where(e => EF.Property<decimal>(e, propertyName) == value);
        }

        public static IQueryable<T> FilterByDouble<T>(this IQueryable<T> entities, string propertyName, double value)
        {
            return entities.Where(e => EF.Property<double>(e, propertyName) == value);
        }

        public static IQueryable<T> FilterByDateTime<T>(this IQueryable<T> entities, string propertyName, DateTime value)
        {
            return entities.Where(e => EF.Property<DateTime>(e, propertyName) == value);
        }

        public static IQueryable<T> FilterByBool<T>(this IQueryable<T> entities, string propertyName, bool value)
        {
            return entities.Where(e => EF.Property<bool>(e, propertyName) == value);
        }

        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> entities, string propertyName, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
            {
                return entities.OrderBy(e => EF.Property<string>(e, propertyName));
            }
            else
            {
                return entities.OrderByDescending(e => EF.Property<string>(e, propertyName));
            }
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> entities, string SoryBy, SortDirection Direction)
        {
            return entities.OrderByProperty(SoryBy, Direction);
        }

        public static IQueryable<T> Paging<T>(this IQueryable<T> entities, int pageNumber, int pageSize)
        {
            return entities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
