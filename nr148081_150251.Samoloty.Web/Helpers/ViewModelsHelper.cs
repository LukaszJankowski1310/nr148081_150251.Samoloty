using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace nr148081_150251.Samoloty.Web.Helpers
{
    public static class ViewModelsHelper
    {
        public static List<SelectListItem> GetSelectListItems<T>()
        {
            var properties = typeof(T).GetProperties();

            var selectListItems = properties
                .Where(property => !property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                .Select(property =>
            {
                var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayAttribute));
                var displayName = displayAttribute?.Name ?? property.Name;

                return new SelectListItem
                {
                    Value = property.Name,
                    Text = displayName,
                };
            }).ToList();

            return selectListItems;
        }

    }
}
