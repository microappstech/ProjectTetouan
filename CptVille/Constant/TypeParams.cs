using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CptVille.Constant
{
    public enum TypeParams
    {
        [Display(Name = "صورة")]
        image,
        [Display(Name = "نص")]
        text,
        [Display(Name = "رابط")]
        utl,
        [Display(Name = "إختيار")]
        boolean
    }
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var enumType = value.GetType();
            var memberInfo = enumType.GetMember(value.ToString());
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((DisplayAttribute)attributes[0]).Name;
                }
            }
            return value.ToString(); // Fallback to enum value if display name is not found
        }
    }
}
