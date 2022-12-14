using System;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public SaldoInsuficienteException() 
        { 
        }
        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        { 
        }
    }
}
