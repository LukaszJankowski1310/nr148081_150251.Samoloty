using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace nr148081_150251.Samoloty.Web.Helpers
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var displayAttribute = field?.GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? value.ToString();
        }

        public static List<SelectListItem> GetEnumSelectList<TEnum>()
         where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(enumValue => new SelectListItem
                {
                    Value = enumValue.ToString(),
                    Text = enumValue.GetDisplayName() // Use the GetDisplayName extension method to get a display name if available
                })
                .ToList();
        }

    }
}
