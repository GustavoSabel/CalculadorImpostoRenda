using CalculadorImpostoRenda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CalculadorImpostoRenda.infra
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contribuinte> Contribuintes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contribuinte>(b =>
            {
                b.Property(x => x.Nome)
                    .HasMaxLength(Contribuinte.TamanhoMaximoNome)
                    .IsRequired();

                b.Property(x => x.CPF)
                    .HasMaxLength(Contribuinte.TamanhoCPF)
                    .IsRequired();

                b.Property(x => x.ImpostoRenda)
                    .HasColumnType("DECIMAL(15,2)");

                b.Property(x => x.RendaMensalBruta)
                    .HasColumnType("DECIMAL(15,2)");

                b.HasIndex(x => x.CPF).IsUnique();
            });

            modelBuilder.Entity<Contribuinte>().HasData(new Contribuinte { 
                Id = 1, 
                Nome = "Gustavo Sabel", 
                CPF = "20137334028", 
                NumeroDependentes = 1,
                RendaMensalBruta = 2500
            });
        }
    }
}
