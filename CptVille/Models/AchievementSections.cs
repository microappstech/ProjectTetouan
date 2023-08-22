using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CptVille.Models
{
    [Table("AchievementSections")]
    public class AchievementSections
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("الفئة المنجزات")]
        public string Name { get; set; }

    }
}
