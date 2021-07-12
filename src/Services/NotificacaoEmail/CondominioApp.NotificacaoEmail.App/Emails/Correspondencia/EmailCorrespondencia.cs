using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailCorrespondencia : ServicoDeEmail
    {                
        private readonly CorrespondenciaDTO _correspondencia;        
        private readonly string _logoCondominioApp = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

        public EmailCorrespondencia(CorrespondenciaDTO correspondencia)
        {
            _correspondencia = correspondencia;           

            var conteudo = SubstituirValores();

            ConstruirEmail(_correspondencia.Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Correspondencia\\correspondencia.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            if (string.IsNullOrEmpty(_correspondencia.LogoDoCondominio) || _correspondencia.LogoDoCondominio == "https://i.imgur.com/gxXxUm7.png")
                _correspondencia.LogoDoCondominio = _logoCondominioApp;

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_titulo_", _correspondencia.Titulo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_mensagem_", _correspondencia.Descricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominio_", _correspondencia.LogoDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominioApp_", _logoCondominioApp);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_recebidoPor_", _correspondencia.RecebidoPor);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_codigo_", _correspondencia.Codigo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_tipo_", _correspondencia.Tipo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_localizacao_", _correspondencia.Localizacao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_obs_", _correspondencia.Observacao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_fotoCorrespondencia_", RetornaFotoHtml());

            return conteudoDoHtmlDoEmail;
        }

        private string RetornaFotoHtml()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(_correspondencia.NomeArquivoFotoCorrespondencia))
                return sb.ToString();

            var caminho = $"{_correspondencia.UrlFoto}";

            var html = $@"<br /><br /><table cellpadding = ""0"" cellspacing = ""0"" width = ""100%"" role = ""presentation"" style = ""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
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
            if (_correspondencia.ListaDeEmails.Count() == 0)
                return;

            foreach (var email in _correspondencia.ListaDeEmails)
            {
                _Email.Bcc.Add(email);                
            }      
            
            await Task.Run(() => base.Send(_Email));
        }
    }
}