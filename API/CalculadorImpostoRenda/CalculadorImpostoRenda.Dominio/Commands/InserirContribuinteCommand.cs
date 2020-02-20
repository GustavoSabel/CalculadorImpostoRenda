namespace CalculadorImpostoRenda.Dominio.Commands
{
    public class InserirContribuinteCommand
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int NumeroDependentes { get; set; }
        public decimal RendaMensalBruta { get; set; }
    }
}
