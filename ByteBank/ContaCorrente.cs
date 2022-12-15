using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento 'agencia' deve ser maior do que 0.", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento 'numero' deve ser maior do que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public Cliente Titular { get; set; }

        public int Agencia { get; }
        public int Numero { get; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                ContadorSaquesNaoPermitidos++;
                throw new ArgumentException("Valor de saque não pode ser negativo", nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException($"Saldo insuficiente para saque no valor de {valor:C}\n" +
                    $"Você não tem todo o dinheiro que imagina!");
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException e)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", e);
            }
/*            if (valor < 0)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new SaldoInsuficienteException($"Saldo insuficiente para transferência no valor de {valor:C}\n" +
                    $"Você não tem todo o dinheiro que imagina!");
            }

            Sacar(valor);*/
            contaDestino.Depositar(valor);
        }

        public static double TaxaOperacao { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }
    }
}
