using CalculadorImpostoRenda.Dominio.Base;

namespace CalculadorImpostoRenda.Dominio.Entidades
{
    public class Contribuinte : EntidadeBase
    {
        public const int TamanhoMaximoNome = 300;
        public const int TamanhoMaximoCPF = 14;

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int NumeroDependentes { get; set; }
        public decimal RendaMensalBruta { get; set; }
        public decimal? ImpostoRenda { get; set; }
    }
}
