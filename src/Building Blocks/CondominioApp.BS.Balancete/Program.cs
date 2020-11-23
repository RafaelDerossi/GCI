using System;

namespace CondominioApp.BS.Balancete
{
    public class Program
    {
        const string CaminhoDaPasta = "/IntegracaoBase/Icondo/FAX/CBAL";

        static void Main(string[] args)
        {
            Console.WriteLine("ENVIO DE BALANCETE (ESTASA)");

            GerenciadorDeBalancete ControleBalancete = new GerenciadorDeBalancete(CaminhoDaPasta);

            ControleBalancete.EnviarArquivos();

            Console.WriteLine("Envio terminado!");
        }
    }
}