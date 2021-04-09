using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailRecuperarSenha : ServicoDeEmail
    {
        private readonly string Assunto = "Recuperar senha - CondomínioApp";
        private string CaminhoUrl = string.Empty;
        private string NomeUsuario;
        private string EmailUsuario;

        public EmailRecuperarSenha(string nomeUsuario, string emailUsuario, string token, string linkDeRedirecionamento)
        {
            NomeUsuario = nomeUsuario;

            EmailUsuario = emailUsuario; ;            

            CaminhoUrl = $"{linkDeRedirecionamento}/{HttpUtility.UrlEncode(token)}/{EmailUsuario}";

            var conteudo = SubstituirValores();

            ConstruirEmail(Assunto, conteudo);
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(EmailUsuario);
            await Task.Run(() => base.Send(_Email));
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\EmailEsqueciSenha.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", NomeUsuario);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_urlDeRedirecionamento_", $"{CaminhoUrl}");

            return conteudoDoHtmlDoEmail;
        }
    }
}
