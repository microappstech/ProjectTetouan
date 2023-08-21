using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CptVille.Models
{
    [Table("Section")]
    public class Section
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName(" الفئة الرئيسية")]
        public string Name { get; set; }
        public ICollection<UnderSection> UnderSections { get; set;}
    }
}
