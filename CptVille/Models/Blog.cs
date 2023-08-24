using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CptVille.Models
{
    [Table("Blog")]
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("العنوان")] [Required] public string? Title { get; set; }
        [DisplayName("وصف المقالة")] [Required] public string? Description { get; set; }
        [DisplayName("الصورة المرفقة")] public string? Image { get; set; }
        #nullable enable
        [DisplayName("الفئة ")] public int? TypeBlog { get; set; } = 0;
        [DisplayName("فئة الإنجاز")] public int? AchieveSection { get; set; } = 0;
#nullable disable
        [DisplayName("تاريخ الإنشاء")] public DateTime CreationDate { get; set; } = DateTime.Now;
        [NotMapped] 
        List<Blog> RelatedBlogs { get; set;}
        [NotMapped]
        [DisplayName("الفئة الفرعية")] public Achievement? AchievementSection { get; set; }
    }
}
