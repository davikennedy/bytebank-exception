using System;
using System.IO;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            CarregarContas();
            Console.ReadLine();
                        
            /*try
            {
                ContaCorrente conta1 = new ContaCorrente(25123, 1350);
                ContaCorrente conta2 = new ContaCorrente(1243, 14256);

                conta1.Depositar(50);
                Console.WriteLine(conta1.Saldo);
                
                conta1.Transferir(500, conta2);
                Console.WriteLine(conta2.Saldo);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Erro no parâmetro: {e.ParamName}");
                Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
            catch(OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna)");
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
                //Console.WriteLine("Exceção do tipo SaldoInsuficienteException.");
            }
            //Console.WriteLine(ContaCorrente.TaxaOperacao);*/
        }
        private static void CarregarContas()
        {
            try
            {
                LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();

                leitor.Fechar();
            }
            catch (IOException)
            {
                Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
            }
        }
    }
}
