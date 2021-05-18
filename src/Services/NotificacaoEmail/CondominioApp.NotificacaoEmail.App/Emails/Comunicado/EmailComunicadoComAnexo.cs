using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailComunicadoComAnexo : ServicoDeEmail
    {
        private readonly string _assunto = "Novo Comunicado";        
        private readonly ComunicadoDTO _comunicado;        
        private readonly string _logoCondominioApp = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

        public EmailComunicadoComAnexo(ComunicadoDTO comunicado)
        {
            _comunicado = comunicado;           

            var conteudo = SubstituirValores();

            ConstruirEmail(_assunto, conteudo);            
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Comunicado\\novocomunicado.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            if (string.IsNullOrEmpty(_comunicado.LogoDoCondominio) || _comunicado.LogoDoCondominio == "https://i.imgur.com/gxXxUm7.png")
                _comunicado.LogoDoCondominio = _logoCondominioApp;            

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_anexo_", RetornaAnexosHtml());
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_foto_", RetornaAnexosImagensHtml());
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_titulo_", _comunicado.Titulo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_mensagem_", _comunicado.Descricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominio_", _comunicado.LogoDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominioApp_", _logoCondominioApp);            

            return conteudoDoHtmlDoEmail;
        }

        private string RetornaAnexosImagensHtml()
        {
            StringBuilder sb = new StringBuilder();

            if (!_comunicado.TemAnexos)
                return sb.ToString();

            var arquivos = _comunicado.Anexos.ToList();

            foreach (var item in arquivos)
            {
                var caminho = $"{item.Url}";
                if (item.Extensao == "jpg" || item.Extensao == "jpeg" || item.Extensao == "png")
                {
                    var html = $@"<br /><br /><table cellpadding = ""0"" cellspacing = ""0"" width = ""100%"" role = ""presentation"" style = ""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                            <tr style = ""border-collapse:collapse"">
                                <td align=""center"" style=""padding: 0; Margin: 0; font - size:0px"">
                                    <img class=""adapt - img"" src = ""{caminho}"" alt style = ""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" width = ""100%"">
                                </td>
                            </tr>
                          </table>";

                    sb.Append(html);
                }              
                sb.Append(" <br /> ");
            }

            return sb.ToString();
        }
        private string RetornaAnexosHtml()
        {
            StringBuilder sb = new StringBuilder();

            if (!_comunicado.TemAnexos)
                return sb.ToString();

            var arquivos = _comunicado.Anexos.ToList();

            foreach (var item in arquivos)
            {
                var caminho = $"{item.Url}";
                if (item.Extensao != "jpg" && item.Extensao != "jpeg" && item.Extensao != "png")                
                {                   
                    var html = @$"<a download={item.Nome} href=""{caminho}"" class=""es-button"" target=""_blank"" style=""margin-bottom:5px !important;mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:18px;color:#FFFFFF;border-style:solid;border-color:#253066;border-width:10px 20px 10px 20px;display:inline-block;background:#253066;border-radius:0px;font-weight:normal;font-style:normal;line-height:22px;width:auto;text-align:center""> Anexo</a>";
                    sb.Append(html);
                    sb.Append(" <br /> ");
                }                
            }

            return sb.ToString();
        }

        public override async Task EnviarEmail()
        {
            if (_comunicado.ListaDeEmails.Count() == 0)
                return;

            foreach (var email in _comunicado.ListaDeEmails)
            {
                _Email.Bcc.Add(email);                
            }      
            
            await Task.Run(() => base.Send(_Email));
        }
    }
}