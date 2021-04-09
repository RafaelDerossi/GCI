using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.Models;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailConfirmacaoDeCadastroDeUser : ServicoDeEmail
    {
        private readonly string Assunto = "Confirmação de cadastro";
        private string NomeUsuario;
        private string EmailUsuario;
        private string CaminhoUrl;

        public EmailConfirmacaoDeCadastroDeUser(string nomeUsuario, string emailUsuario, string linkDeRedirecionamento)
        {
            NomeUsuario = nomeUsuario;

            EmailUsuario = emailUsuario;

            CaminhoUrl = linkDeRedirecionamento;

            var conteudo = SubstituirValores();

            ConstruirEmail(Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\EmailConfirmacaoDeCadastro.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", NomeUsuario);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_urlDeRedirecionamento_", $"{CaminhoUrl}");

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(EmailUsuario);
            await Task.Run(() => base.Send(_Email));
        }
    }
}