using CalculadorImpostoRenda.infra;
using Microsoft.EntityFrameworkCore;
using System;
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

            //_contexto.Database.EnsureDeleted();
            //_contexto.Database.EnsureCreated();

            var rep = new ProdutoRepository(_contexto);
            var produto = new Produto(1, 1, "Produto 1", "Azul", "Metal/Azul", null, null, null, null, null);
            rep.AdicionarOuAtualizar(produto).GetAwaiter().GetResult();
            rep.SaveChangesAsync().Wait();
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
