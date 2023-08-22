using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using CptVille.Constant;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CptVille.Models
{
    [Table("Parameters")]
    public class Parameters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("المفتاح")]
        public string Key { get; set; }
        [Required]
        [DisplayName("نوع")]
        [BindNever]
        public int TypePara { get; set; }
        [DisplayName("القيمة")]
        public string? Value { get; set; }

    }
}
