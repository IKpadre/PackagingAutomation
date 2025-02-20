using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Reflection;

namespace PackagingAutomation.Utilities
{
    public static class EnumHelper
    {
        public static List<SelectListItem> GetEnumSelectList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Select(e => new SelectListItem
                       {
                           Value = Convert.ToInt32(e).ToString(),
                           Text = e.GetDescription()
                       })
                       .ToList();
        }

        public static string GetDescription<T>(this T enumValue) where T : Enum
        {
            return enumValue.GetType().GetField(enumValue.ToString())?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? enumValue.ToString();
        }
    }
}
