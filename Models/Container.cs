using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02SWII6.Models
{
    [Table("container")]
    public class Container
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("tipo")]
        public ETipo Tipo { get; set; }

        [Column("tamanho")]
        public ETamanho Tamanho { get; set; }

        [Column("idBL")]
        public int IdBL { get; set; } // Chave estrangeira para a tabela BL
    }

    public enum ETipo
    {
        Dry = 1,
        Reefer = 2
    }

    public enum ETamanho
    {
        Pequeno = 20,
        Grande = 40
    }
}



