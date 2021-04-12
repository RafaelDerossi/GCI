using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailRespostaOcorrencia : ServicoDeEmail
    {   
        private RespostaOcorrenciaDTO _respostaOcorrencia;        
        private string _logoCondominioApp = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";
        private string _caminhoFoto = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/";

        public EmailRespostaOcorrencia(RespostaOcorrenciaDTO respostaOcorrenciaDTO)
        {
            _respostaOcorrencia = respostaOcorrenciaDTO;           

            var conteudo = SubstituirValores();

            ConstruirEmail(_respostaOcorrencia.Titulo, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Ocorrencia\\respostaOcorrencia.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            if (string.IsNullOrEmpty(_respostaOcorrencia.LogoDoCondominio) || _respostaOcorrencia.LogoDoCondominio == "https://i.imgur.com/gxXxUm7.png")
                _respostaOcorrencia.LogoDoCondominio = _logoCondominioApp;

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_titulo_", _respostaOcorrencia.Titulo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_nomeCondominio_", _respostaOcorrencia.NomeCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_descricaoOcorrencia_", _respostaOcorrencia.DescricaoDaOcorrencia);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_resposta_", _respostaOcorrencia.Resposta);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_nomeUsuario_", _respostaOcorrencia.NomeSindico);            
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_dataCadastro_", _respostaOcorrencia.DataDaResposta);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominio_", _respostaOcorrencia.LogoDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominioApp_", _logoCondominioApp);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_foto_", RetornaFotoHtml());

            return conteudoDoHtmlDoEmail;
        }

        private string RetornaFotoHtml()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(_respostaOcorrencia.Foto))
                return sb.ToString();

            var caminho = $"{_caminhoFoto}{_respostaOcorrencia.Foto}";

            var html =$@"<br /><br /><table cellpadding = ""0"" cellspacing = ""0"" width = ""100%"" role = ""presentation"" style = ""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                            <tr style = ""border-collapse:collapse"">
                                <td align=""center"" style=""padding: 0; Margin: 0; font - size:0px"">
                                    <img class=""adapt - img"" src = ""{caminho}"" alt style = ""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" width = ""100%"">
                                </td>
                            </tr>
                          </table>";

            sb.Append(html);

            sb.Append("<br />");

            return sb.ToString();
        }

        public override async Task EnviarEmail()
        {
            if (_respostaOcorrencia.ListaDeEmails.Count() == 0)
                return;

            foreach (var email in _respostaOcorrencia.ListaDeEmails)
            {
                _Email.Bcc.Add(email);                
            }      
            
            await Task.Run(() => base.Send(_Email));
        }
    }
}