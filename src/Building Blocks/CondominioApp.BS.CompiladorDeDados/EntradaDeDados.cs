using System;
using System.IO;

namespace CondominioApp.BS.CompiladorDeDados
{
    public class EntradaDeDados
    {
        public string CaminhoParaEntradaDeDadosOriginal { get; private set; }
        public string CaminhoDoNovoIndiceDeEntrada { get; private set; }

        public EntradaDeDados(string caminhoParaEntradaDeDadosOriginal, string caminhoDoNovoIndiceDeEntrada)
        {
            CaminhoParaEntradaDeDadosOriginal = caminhoParaEntradaDeDadosOriginal;
            CaminhoDoNovoIndiceDeEntrada = caminhoDoNovoIndiceDeEntrada;
        }

        public void CriarNovoIndiceDeDados()
        {
            var TextoDoIndice = string.Empty;

            using (StreamReader leitor = new StreamReader(CaminhoParaEntradaDeDadosOriginal))
            {
                TextoDoIndice = leitor.ReadToEnd();
                TextoDoIndice = TextoDoIndice.Replace(" ", "");
            }

            using (var logWriter = new StreamWriter(CaminhoDoNovoIndiceDeEntrada, false))
            {
                logWriter.WriteLine(TextoDoIndice);
            }

            Console.WriteLine("Novo arquivo de indice criado com sucesso!!");
        }
    }
}
