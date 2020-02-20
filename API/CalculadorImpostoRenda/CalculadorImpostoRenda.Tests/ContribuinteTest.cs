using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.infra;
using CalculadorImpostoRenda.infra.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CalculadorImpostoRenda.Tests
{
    public class ContribuinteTest
    {
        private readonly Context _contexto;

        public ContribuinteTest()
        {
            var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("DB").Options;
            _contexto = new Context(options);
        }

        [Fact]
        public async Task Inserir()
        {
            var rep = new ContribuinteRepository(_contexto);
            rep.InserirOuAtualizar(new Contribuinte
            {
                Nome = "Gustavo Sabel",
                CPF = "20137334028",
                NumeroDependentes = 3
            });
            await rep.SaveChangesAsync();
        }

        [Fact]
        public async Task Excluir()
        {
            var rep = new ContribuinteRepository(_contexto);
            var contribuinte = new Contribuinte
            {
                Nome = "Gustavo Sabel",
                CPF = "20137334028",
                NumeroDependentes = 3
            };
            rep.InserirOuAtualizar(contribuinte);
            await rep.SaveChangesAsync();


            await rep.Excluir(contribuinte.Id);
            await rep.SaveChangesAsync();


            contribuinte = await rep.Obter(contribuinte.Id);
            Assert.Null(contribuinte);
        }
    }
}
