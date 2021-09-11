using System;
using System.IO;
using System.Net;
using System.Text;

namespace CondominioApp.BS.Balancete
{
    public class GerenciadorDeBalancete
    {
        public string CaminhoDaPastaDoICondo { get; private set; }

        public GerenciadorDeBalancete(string caminhoDaPastaDoICondo)
        {
            CaminhoDaPastaDoICondo = caminhoDaPastaDoICondo;
        }

        public void EnviarArquivos()
        {
            var CaminhosDosArquivosDeBalancete = Directory.GetFiles(CaminhoDaPastaDoICondo);

            Console.WriteLine("Enviando Balancete analítico para o CondomínioApp.com...");

            foreach (var CaminhoDoArquivo in CaminhosDosArquivosDeBalancete)
            {
                var NomeDoArquivo = ObterNomeDoArquivo(CorrigirBarrasDoCaminho(CaminhoDoArquivo));

                EnviarArquivoFTP(
                    CaminhoDoArquivo,
                    "ftp.site4now.net",
                    "techdog-003",
                    "techdog2016!",
                    "BalanceteAnalitico",
                    NomeDoArquivo);

                //EnviarArquivoFTP(
                //        CaminhoDoArquivo,
                //        "waws-prod-sn1-017.ftp.azurewebsites.windows.net",
                //        "$integracaobasesoftware",
                //        "YYaafGG3xDjtkm7BhgNS1Px7zFySzTS9c1bS8dvdjb5inX1hLnNFoD3sBhLe",
                //        "BalanceteAnalitico",
                //        NomeDoArquivo);
            }

            Console.WriteLine("Upload de Balancetes completo!");
        }

        #region MétodosAuxiliares
        private void EnviarArquivoFTP(string arquivo, string url, string usuario, string senha, string folderServer, string nomeDoArquivo)
        {
            try
            {
                FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create($"ftp://{usuario}:{senha}@{url}/basesoftware/balancetes/Estasa/{folderServer}/{nomeDoArquivo}");
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                ftp.KeepAlive = false;
                ftp.UsePassive = true;

                ftp.Proxy = null;
                ftp.UseBinary = true;

                StreamReader stream = new StreamReader(arquivo);
                byte[] fileContents = Encoding.UTF8.GetBytes(stream.ReadToEnd());
                stream.Close();
                ftp.ContentLength = fileContents.Length;

                Stream requestStream = ftp.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private string ObterNomeDoArquivo(string CaminhoDoArquivo)
        {
            var Posicoes = CaminhoDoArquivo.Split("/");

            var NovoNome = Posicoes[5].Substring(0, 10);

            NovoNome = NovoNome.Replace("CBAL", "");

            NovoNome = $"{Convert.ToInt32(NovoNome)}.htm";

            return NovoNome;
        }

        private string CorrigirBarrasDoCaminho(string CaminhoDoArquivo)
        {
            return CaminhoDoArquivo.Replace("\\", "/");
        }


        #endregion

    }
}