using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CptVille.Models
{
    [Table("Achievement")]
    public class Achievement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("الإسم")]
        [Required] public string Name { get; set; }
    }
}
