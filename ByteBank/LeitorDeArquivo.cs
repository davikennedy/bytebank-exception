using System;

namespace ByteBank
{
    public class LeitorDeArquivo
    {
        public string Arquivo { get; }
        
        public LeitorDeArquivo(string Arquivo)
        {
            this.Arquivo = Arquivo;
            Console.WriteLine($"Abrindo arquivo: {Arquivo}");
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha");
            return "Linha do arquivo";
        }

        public void Fechar()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
