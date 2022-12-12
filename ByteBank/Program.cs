using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(10, 0);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Erro no parâmetro: {e.ParamName}");
                Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
                Console.WriteLine(e.Message);
            }
            //Console.WriteLine(ContaCorrente.TaxaOperacao);

            Console.ReadKey();
        }
    }
}
