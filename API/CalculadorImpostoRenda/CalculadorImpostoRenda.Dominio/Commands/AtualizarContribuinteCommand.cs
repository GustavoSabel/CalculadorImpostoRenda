namespace CalculadorImpostoRenda.Dominio.Commands
{
    public class AtualizarContribuinteCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NumeroDependentes { get; set; }
        public decimal RendaMensalBruta { get; set; }
    }
}
