using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CptVille.Models
{
    [Table("UnderSection")]
    public class UnderSection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("الفئة الثانوية")]
        public string Name { get; set; }
        [DisplayName("الفئة الرئيسية")]
        public Section Section { get; set; }
        [DisplayName("الفئة الرئيسية")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="إختر الفئة الرئيسية")]

        public int MainSectionId { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
