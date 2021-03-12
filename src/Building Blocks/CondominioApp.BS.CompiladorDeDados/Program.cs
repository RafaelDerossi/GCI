using System;

namespace CondominioApp.BS.CompiladorDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            const string NovoCaminhoDeEntrada = "/IntegracaoBase/NovaEntrada.txt";
            const string CaminhoOriginalDeEntrada = "/IntegracaoBase/Icondo_novo/DB/EntDados.txt";
            const string CaminhoDaListaDeCpfs = "/IntegracaoBase/ListaDeCpfs.txt";
            const string CaminhoDoNovoIndiceDeBoletos = "/IntegracaoBase/indiceDeBoletos.txt";

            Console.WriteLine("BEM-VINDO!!");
            Console.WriteLine("Integração Base Software...(ESTASA)");

            var ControleDeEntradas = new EntradaDeDados(CaminhoOriginalDeEntrada, NovoCaminhoDeEntrada);

            Console.WriteLine("Atualizando entradas....");

            ControleDeEntradas.CriarNovoIndiceDeDados();

            var NovoIndice = new IndiceDeBoletos(CaminhoDaListaDeCpfs, NovoCaminhoDeEntrada, CaminhoDoNovoIndiceDeBoletos);
            NovoIndice.Criar();

            Console.WriteLine("Processo terminado!");
        }
    }
}