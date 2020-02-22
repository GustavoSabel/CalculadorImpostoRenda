using System;

namespace CalculadorImpostoRenda.Dominio.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string message) : base(message)
        {
        }
    }
}
