using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02SWII6.Models
{
    /*AUTORES:
        Ronald Pereira Evangelista / CB3020282
        Ketheleen Cristine Simão dos Santos / CB3011836
    */

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
