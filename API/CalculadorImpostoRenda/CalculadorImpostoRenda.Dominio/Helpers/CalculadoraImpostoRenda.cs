using CalculadorImpostoRenda.Dominio.Entidades;

namespace CalculadorImpostoRenda.Dominio.Helpers
{
    static class CalculadoraImpostoRenda
    {
        public static decimal Calcular(decimal salarioMinimo, Contribuinte contrib)
        {
            var rendaLiquida = CalcularRendaLiquida(contrib);

            var faixa2 = ObterFaixa(rendaLiquida, (salarioMinimo * 2), (salarioMinimo * 4));
            var faixa3 = ObterFaixa(rendaLiquida, (salarioMinimo * 4), (salarioMinimo * 5));
            var faixa4 = ObterFaixa(rendaLiquida, (salarioMinimo * 5), (salarioMinimo * 7));
            var faixa5 = ObterFaixa(rendaLiquida, (salarioMinimo * 7), null);

            return
                (faixa2 * 0.075m) +
                (faixa3 * 0.150m) +
                (faixa4 * 0.225m) +
                (faixa5 * 0.275m);
        }

        private static decimal CalcularRendaLiquida(Contribuinte contrib)
        {
            var percentualDescontoPorDependentes = 0.05m * contrib.NumeroDependentes;
            var rendaLiquida = contrib.RendaMensalBruta - (contrib.RendaMensalBruta * percentualDescontoPorDependentes);
            return rendaLiquida;
        }

        private static decimal ObterFaixa(decimal valor, decimal valorMinimoFaixa, decimal? valorLimiteFaixa)
        {
            var valorFaixa = valor - valorMinimoFaixa;
            if (valorFaixa > 0)
            {
                if (valorLimiteFaixa is null)
                {
                    return valorFaixa;
                }
                else
                {
                    var valorMaximoFaixa = valorLimiteFaixa.Value - valorMinimoFaixa;
                    if (valorFaixa > valorMaximoFaixa)
                        return valorMaximoFaixa;
                    return valorFaixa;
                }
            }
            return 0;
        }
    }
}
