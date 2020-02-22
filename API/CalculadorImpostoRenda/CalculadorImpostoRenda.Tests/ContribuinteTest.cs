using CalculadorImpostoRenda.Dominio.Commands;
using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.Dominio.Handlers;
using CalculadorImpostoRenda.infra;
using CalculadorImpostoRenda.infra.Repository;
using System.Threading.Tasks;
using Xunit;

namespace CalculadorImpostoRenda.Tests
{
    public class ContribuinteTest
    {
        private readonly ApplicationDbContext _contexto;
        private readonly ContribuinteRepository _rep;
        private readonly ContribuinteHandler _handler;

        public ContribuinteTest()
        {
            _contexto = TestHelper.CriarContexto();
            _rep = new ContribuinteRepository(_contexto);
            _handler = new ContribuinteHandler(_rep);
        }

        [Fact]
        public async Task Inserir()
        {
            _rep.InserirOuAtualizar(new Contribuinte
            {
                Nome = "Gustavo Sabel",
                CPF = "20137334028",
                NumeroDependentes = 3
            });
            await _rep.SaveChangesAsync();
        }

        [Fact]
        public async Task Atualizar()
        {
            var contribuinte = await InserirContribuinteAsync();

            await _handler.HandleAsync(new AtualizarContribuinteCommand
            {
                Id = contribuinte.Id,
                Nome = "Nome alterado",
                RendaMensalBruta = 9999,
                NumeroDependentes = 7
            });

            contribuinte = await _rep.ObterAsync(contribuinte.Id);
            Assert.Equal("Nome alterado", contribuinte.Nome);
            Assert.Equal(9999, contribuinte.RendaMensalBruta);
            Assert.Equal(7, contribuinte.NumeroDependentes);
        }

        [Fact]
        public async Task Excluir()
        {
            var contribuinte = await InserirContribuinteAsync();

            await _handler.HandleAsync(new ExcluirContribuinteCommand { Id = contribuinte.Id });

            contribuinte = await _rep.ObterAsync(contribuinte.Id);
            Assert.Null(contribuinte);
        }

        [Fact]
        public async Task CalcularImpostoRenda()
        {
            //Criar contribuinte
            var contribuinte = await InserirContribuinteAsync(rendaMensalBruta: 10000);

            //Realizar o cálculo
            var resultado = await _handler.CalcularImpostoRenda(new CalcularImpostoRendaCommand { SalarioMinimo = 1000 });
            Assert.Equal(1, resultado.Count);
            Assert.True(resultado[0].ImpostoRenda > 0);

            //Validar se persistiu no banco
            contribuinte = await _rep.ObterAsync(contribuinte.Id);
            Assert.True(contribuinte.ImpostoRenda > 0);
        }

        private ValueTask<Contribuinte> InserirContribuinteAsync(decimal rendaMensalBruta = 1000)
        {
            return _handler.HandleAsync(new InserirContribuinteCommand
            {
                Cpf = "20137334028",
                Nome = "Gustavo Sabel",
                NumeroDependentes = 3,
                RendaMensalBruta = rendaMensalBruta
            });
        }
    }
}
