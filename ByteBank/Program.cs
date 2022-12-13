using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(520, 1350);
                conta.Depositar(50);
                Console.WriteLine(conta.Saldo);
                conta.Sacar(1500);
                Console.WriteLine(conta.Saldo);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Erro no parâmetro: {e.ParamName}");
                Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
                Console.WriteLine(e.Message);
            }
            catch(SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException.");
            }
            //Console.WriteLine(ContaCorrente.TaxaOperacao);

            Console.ReadKey();
        }
    }
}
