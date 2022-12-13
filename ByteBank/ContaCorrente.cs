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
            
            //TaxaOperacao = 30 / TotalDeContasCriadas;
            //TotalDeContasCriadas++;
        }
        public Cliente Titular { get; set; }

        public int Agencia { get; }
        public int Numero { get; }

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
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException($"Saldo insuficiente para saque no valor de {valor:C}\n" +
                    $"Você não tem todo o dinheiro que imagina!");
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }

        public static double TaxaOperacao { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }
    }
}
