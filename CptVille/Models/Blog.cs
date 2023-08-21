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
        [DisplayName("الفئة الرئيسية")] public int? SectionId { get; set; } = 0;
        [DisplayName("الفئة الرئيسية")] public Section? Section { get; set; }
        [DisplayName("الفئة الفرعية")] public int? UnderSectionId { get; set; } = 0;
        [DisplayName("الفئة الفرعية")] public UnderSection? UnderSection { get; set; }
        #nullable disable
        [DisplayName("تاريخ الإنشاء")] public DateTime CreationDate { get; set; } = DateTime.Now;
        [NotMapped] 
        List<Blog> RelatedBlogs { get; set;}
    }
}
