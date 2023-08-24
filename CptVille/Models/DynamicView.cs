using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CptVille.Constant;

namespace CptVille.Models
{
        [Table("DynamicView")]
    public class DynamicView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("صحفة")]
        [EnumDataType(typeof(TypePage))]
        public int TypePage { get; set; }
        [DisplayName("صورة الغطاء")]
        public string? ImageCover { get; set; }
        [DisplayName("الفئة")]
        public int SectionId { get; set; }
        [DisplayName("الإسم")]
        [Required] public string ViewName { get; set; }
        [DisplayName("التصميم")]
        [Required] public string ViewDesign { get; set; } 
        
    }
}
