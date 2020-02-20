namespace CalculadorImpostoRenda.Dominio.Models
{
    public class Contribuinte
    {
        public const int TamanhoMaximoNome = 300;
        public const int TamanhoMaximoCPF = 14;

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int NumeroDependentes { get; set; }
    }
}
