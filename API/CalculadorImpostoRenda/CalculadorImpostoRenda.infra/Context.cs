using CalculadorImpostoRenda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CalculadorImpostoRenda.infra
{
    public class Context : DbContext
    {
        public DbSet<Contribuinte> Contribuintes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
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
                    .HasMaxLength(Contribuinte.TamanhoMaximoCPF)
                    .IsRequired();

                b.HasIndex(x => x.CPF).IsUnique();
            });
        }
    }
}
