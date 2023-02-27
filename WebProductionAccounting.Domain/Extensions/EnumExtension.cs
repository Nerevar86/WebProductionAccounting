using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WebProductionAccounting.Domain.Enum;

namespace WebProductionAccounting.Domain.Extensions
{
    public static class EnumExtension
    {

        public static string GetDisplayName(this System.Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                ?.GetName() ?? "Неопределено";
        }
  
    }
}
