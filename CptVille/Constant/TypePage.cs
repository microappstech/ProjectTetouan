using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CptVille.Constant
{
    public enum TypePage
    {
        [Display(Name = " إتصل بنا")]
        call_us,
        [Display(Name = "معطيات حول الوسط الطبيعي")]
        demographicdatat,
        [Display(Name = "معطيات ديموغرافية")]
        normalenvirenemen,
        [Display(Name = "بطاقة تعريفية للإقليم")]
        regionalidentification,
        [Display(Name = "البنية التحتية")]
        infrastructure,
        [Display(Name = "المجال الاقتصادي")]
        economic_field,
        [Display(Name = "كلمة الرئيس")]
        president_word,
        [Display(Name = "مكتب المجلس")]
        council_office,
        [Display(Name = "لجان المجلس")]
        board_committees,
        [Display(Name = "إعلانات ")]
        ads_blogs,
        [Display(Name = "مشاريع و منجزات")]
        achievements,
        [Display(Name = "أنشطة المجلس")]
        council_activite
    }
    public static class EnumPageExtensions
    {
        public static string GetPageDisplayName(this Enum value)
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
