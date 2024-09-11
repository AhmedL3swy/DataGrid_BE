using DataGrid.Application.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataGrid.Persistence.Shared.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Search<T, S>(this IQueryable<T> entities, S searchObj, IEnumerable<PropertyInfo> searchProperties)
        {
            foreach (var property in searchProperties)
            {
                var value = property.GetValue(searchObj);
                if (value != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        // Handle string properties using Contains
                        entities = entities.FilterByString(property.Name, (string)value);
                    }
                    else
                    {
                        // Handle other types using Equals
                        entities = entities.FilterByOtherTypes(property.Name, value);
                    }
                }
            }

            return entities;
        }

        // Filter by string using Contains
        public static IQueryable<T> FilterByString<T>(this IQueryable<T> entities, string propertyName, string value)
        {
            return entities.Where(e => EF.Property<string>(e, propertyName).Contains(value));
        }

        // Filter by other types using Equals
        public static IQueryable<T> FilterByOtherTypes<T>(this IQueryable<T> entities, string propertyName, object value)
        {
            return entities.Where(e => EF.Property<object>(e, propertyName).Equals(value));
        }


        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> entities, string propertyName, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
            {
                return entities.OrderBy(e => EF.Property<object>(e, propertyName));
            }
            else
            {
                return entities.OrderByDescending(e => EF.Property<object>(e, propertyName));
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
