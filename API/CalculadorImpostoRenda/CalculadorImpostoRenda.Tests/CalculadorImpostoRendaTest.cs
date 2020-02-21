using CalculadorImpostoRenda.Dominio.Entidades;
using CalculadorImpostoRenda.Dominio.Helpers;
using Xunit;

namespace CalculadorImpostoRenda.Tests
{
    public class CalculadorImpostoRendaTest
    {
        [Theory]
        [InlineData(0000, 0)]
        [InlineData(1000, 0)]
        [InlineData(2000, 0)]
        [InlineData(3000, 75)]
        [InlineData(4000, 150)]
        [InlineData(5000, 300)]
        [InlineData(6000, 525)]
        [InlineData(7000, 750)]
        [InlineData(8000, 1025)]
        [InlineData(9000, 1300)]
        [InlineData(10000, 1575)]
        public void CalcularSemDependentes(decimal salario, decimal impostoRenda)
        {
            Assert.Equal(impostoRenda, CalculadoraImpostoRenda.Calcular(1000, new Contribuinte { NumeroDependentes = 0, RendaMensalBruta = salario }));
        }

        [Theory]
        [InlineData(3000, 0, 75)]
        [InlineData(3000, 1, 63.75)]
        [InlineData(3000, 5, 18.75)]
        [InlineData(10000, 2, 1300)]
        public void CalcularComPendentens(decimal salario, int dependentes, decimal impostoRenda)
        {
            Assert.Equal(impostoRenda, CalculadoraImpostoRenda.Calcular(1000, new Contribuinte { NumeroDependentes = dependentes, RendaMensalBruta = salario }));
        }
    }
}
