using Microsoft.EntityFrameworkCore;

namespace TP02SWII6.Models
{
    /*AUTORES:
        Ronald Pereira Evangelista / CB3020282
        Ketheleen Cristine Simão dos Santos / CB3011836
    */
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Container> Containers { get; set; }

        public DbSet<BL> BLs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>()
                .HasOne<BL>() // Relacionamento com a entidade BL
                .WithMany() // BL pode ter muitos Containers
                .HasForeignKey(c => c.IdBL) // Certifique-se de que este é o nome correto da chave estrangeira
                .HasConstraintName("fk_BL_Container");
        }
    }
}
