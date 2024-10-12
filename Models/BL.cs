using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02SWII6.Models
{
    [Table("bl")]
    public class BL
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número é obrigatório.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O consignee é obrigatório.")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "O navio é obrigatório.")]
        public string Navio { get; set; }
    }
}
