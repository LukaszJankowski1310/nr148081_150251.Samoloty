using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace nr148081_150251.Samoloty.Web.Helpers
{
    public static class SortingHelper
    {
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> queryble, string? prop, SortDirection? direction)
        {
            if (string.IsNullOrEmpty(prop)) return queryble;
            PropertyInfo propInfo = typeof(T).GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propInfo == null) return queryble;


            if (IsEnumWithDisplayAttribute(propInfo.PropertyType))
            {
                return SortEnumWithDisplay(queryble, propInfo, direction);
            }


            if (direction == SortDirection.Ascending || direction == null)
            {
                return queryble.OrderBy(x => propInfo.GetValue(x, null));
            }
            else
            {
                return queryble.OrderByDescending(x => propInfo.GetValue(x, null));
            }         
        }

        private static bool IsEnumWithDisplayAttribute(Type type)
        {
            return type.IsEnum;
        }

        private static IEnumerable<T> SortEnumWithDisplay<T>(IEnumerable<T> queryable, PropertyInfo propInfo, SortDirection? direction)
        {
            var displayOrder = Enum.GetValues(propInfo.PropertyType)
                                  .Cast<Enum>()
                                  .OrderBy(e => (e.GetDisplayName() ?? e.ToString()))
                                  .ToList();

            if (direction == SortDirection.Ascending || direction == null)
            {
                return queryable.OrderBy(x => displayOrder.IndexOf((Enum)propInfo.GetValue(x, null)));
            }
            else
            {
                return queryable.OrderByDescending(x => displayOrder.IndexOf((Enum)propInfo.GetValue(x, null)));
            }
  
        }

    }
}
