using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using CondominioApp.Core.ValueObjects;
using Newtonsoft.Json;

namespace CondominioApp.BS.CompiladorDeDados
{
    public class IndiceDeBoletos
    {
        public string CaminhoParaListaDeCpfs { get; private set; }

        public string CaminhoDoNovoIndiceDeEntrada { get; private set; }

        public string CaminhoNovoIndiceDeBoletos { get; private set; }

        private readonly List<ItemBoleto> _Boletos;

        private List<ItemBoleto> _ListaDeBoletos;

        private string[] ConteudoDoNovoIndice;

        private string CaminhoDoBoletoHtml;

        const string CaminhoBase = "/IntegracaoBase/Icondo";

        public IndiceDeBoletos(string caminhoParaListaDeCpfs, string caminhoDoNovoIndiceDeEntrada, string caminhoNovoIndiceDeBoletos)
        {
            _Boletos = new List<ItemBoleto>();
            _ListaDeBoletos = new List<ItemBoleto>();

            CaminhoParaListaDeCpfs = caminhoParaListaDeCpfs;
            CaminhoDoNovoIndiceDeEntrada = caminhoDoNovoIndiceDeEntrada;
            CaminhoNovoIndiceDeBoletos = caminhoNovoIndiceDeBoletos;

            CaminhoDoBoletoHtml = CaminhoBase;

            CarregarConteudoDoIndice();
            CarregarListaDeIndicesDeCpfs();
        }

        public void Criar()
        {
            var ListaDeCpfs = ObterListaDeCpf();

            foreach (var cpf in ListaDeCpfs)
            {
                var ItemBoleto = new ItemBoleto(cpf);
                var ResultadoDeBuscaPorCpf = BuscarRegistrosDoCpf(cpf);
                DefragmentarArquivosHtmls(ResultadoDeBuscaPorCpf, ItemBoleto);
            }

            EscreverNovoIndiceDeBoletos();

            EnviarArquivoFTP(
                CaminhoNovoIndiceDeBoletos,
                "waws-prod-sn1-017.ftp.azurewebsites.windows.net",
                "$integracaobasesoftware",
                "YYaafGG3xDjtkm7BhgNS1Px7zFySzTS9c1bS8dvdjb5inX1hLnNFoD3sBhLe",
                "Estasa");
        }

        private void EnviarArquivoFTP(string arquivo, string url, string usuario, string senha, string folderServer)
        {
            try
            {
                Console.WriteLine("Enviando para o servidor...");

                FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create($"ftp://{usuario}:{senha}@{url}/site/wwwroot/wwwroot/boletos/{folderServer}/indiceDeBoletos.txt");
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

                Console.WriteLine("Upload de arquivo Completo, status {0}", response.StatusDescription);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        #region MétodosAuxiliares

        private void DefragmentarArquivosHtmls(List<string> RegistrosDoCpf, ItemBoleto ItemBoleto)
        {
            if (RegistrosDoCpf.Count == 0) return;

            foreach (var LinhaDoHtml in RegistrosDoCpf)
            {
                var AmostraDeRegistro = ColetarAmostraDeRegistro(LinhaDoHtml);

                if (AmostraDeRegistro.Any(x => x.Contains("CREC")))
                {
                    var LinhaDoArquivoHtml = AmostraDeRegistro.FirstOrDefault(x => x.Contains(".htm"));

                    IdentificarLinhaHtml(LinhaDoArquivoHtml);

                    ItemBoleto.AdicionarLinkDoBoleto(ExtrairLinkDoBoleto());

                    _Boletos.Add(ItemBoleto);
                }
            }
        }

        private void IdentificarLinhaHtml(string LinhaDoArquivoHtml)
        {
            if (string.IsNullOrEmpty(LinhaDoArquivoHtml)) return;

            var CaminhoDoHml = string.Empty;

            int indiceInicial = LinhaDoArquivoHtml.IndexOf("C:\\");

            if (indiceInicial == 0) return;

            for (int idx = indiceInicial; idx < LinhaDoArquivoHtml.Length; idx++)
                CaminhoDoHml += LinhaDoArquivoHtml[idx].ToString();

            CaminhoDoHml = CaminhoDoHml.Replace("C:\\Filtro\\Icondo", "").Replace("\\", "/");

            CaminhoDoBoletoHtml = CaminhoDoBoletoHtml + CaminhoDoHml;
        }

        private string ExtrairLinkDoBoleto()
        {
            if (!File.Exists(CaminhoDoBoletoHtml)) return string.Empty;

            using (StreamReader st = new StreamReader(CaminhoDoBoletoHtml))
            {
                string htmlread = st.ReadToEnd();
                var link = string.Empty;

                int indiceBoleto = htmlread.IndexOf("<img id='boleto' src='");

                if (indiceBoleto > 0)
                {
                    while (htmlread[indiceBoleto].ToString() != ">")
                    {
                        link += htmlread[indiceBoleto].ToString();
                        indiceBoleto++;
                    }
                }

                link = link.Replace("<img id='boleto' src=", "");
                link = link.Replace("+", " ");
                link = Uri.UnescapeDataString(link);
                link = link.Replace("'", "");

                return link;
            }
        }

        private string[] ColetarAmostraDeRegistro(string LinhaDoHtml)
        {
            int indice = Array.IndexOf(ConteudoDoNovoIndice, LinhaDoHtml);
            int count = 0;

            string[] arrLinha = new string[3];

            int fimLoop = indice + 2;

            for (int i = indice; i <= fimLoop; i++)
            {
                arrLinha[count] = ConteudoDoNovoIndice[i].ToString();
                count++;
            }

            return arrLinha;
        }

        private List<string> BuscarRegistrosDoCpf(string cpf)
        {
            return ConteudoDoNovoIndice.Where(x => x.Contains(cpf)).ToList();
        }

        private List<string> ObterListaDeCpf()
        {
            List<string> ListaDeCpfs = new List<string>();

            if (!File.Exists(CaminhoParaListaDeCpfs)) return new List<string>();

            var ArrayDeCpfs = File.ReadAllLines(CaminhoParaListaDeCpfs);

            foreach (var cpf in ArrayDeCpfs)
                ListaDeCpfs.Add(new Cpf(cpf).ObterNumeroFormatado());

            return ListaDeCpfs;
        }

        private void CarregarConteudoDoIndice()
        {
            if (!File.Exists(CaminhoDoNovoIndiceDeEntrada)) throw new Exception("Arquivo de indice não encontrado!");

            ConteudoDoNovoIndice = File.ReadAllLines(CaminhoDoNovoIndiceDeEntrada);
        }

        private void EscreverNovoIndiceDeBoletos()
        {
            SincronizarListas();

            using (var logWriter = new StreamWriter(CaminhoNovoIndiceDeBoletos, false, Encoding.UTF8))
            {
                try
                {
                    string json = JsonConvert.SerializeObject(_ListaDeBoletos, Newtonsoft.Json.Formatting.Indented);
                    logWriter.WriteLine(json);

                    Console.WriteLine("Nova lista de boletos criada com sucesso!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void CarregarListaDeIndicesDeCpfs()
        {
            using (StreamReader st = new StreamReader(CaminhoNovoIndiceDeBoletos))
            {
                string ConteudoDoArquivo = st.ReadToEnd();
                _ListaDeBoletos = JsonConvert.DeserializeObject<List<ItemBoleto>>(ConteudoDoArquivo);
            }
        }

        private void SincronizarListas()
        {
            foreach (var itemBoleto in _Boletos)
            {
                var ItemDaListaDeIndice = _ListaDeBoletos.FirstOrDefault(b => b.cpf == itemBoleto.cpf);

                if (ItemDaListaDeIndice == null)
                    _ListaDeBoletos.Add(itemBoleto);
                else
                    AtualizarIndiceDaLista(ItemDaListaDeIndice, itemBoleto.listaDeBoletos);
            }
        }

        private void AtualizarIndiceDaLista(ItemBoleto ItemDaListaDeIndice, List<string> listaDeBoletos)
        {
            _ListaDeBoletos.Remove(ItemDaListaDeIndice);
            ItemDaListaDeIndice.LimparListaDeBoletos();

            foreach (var LinkDoBoleto in listaDeBoletos)
                ItemDaListaDeIndice.AdicionarLinkDoBoleto(LinkDoBoleto);

            _ListaDeBoletos.Add(ItemDaListaDeIndice);
        }


        #endregion
    }
}
