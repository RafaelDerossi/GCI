using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.Models;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailConfirmacaoDeCadastroDeUsuario : ServicoDeEmail
    {
        private readonly string Assunto = "Confirmação de cadastro";
        private Usuario Usuario;
        private string CaminhoUrl;

        public EmailConfirmacaoDeCadastroDeUsuario(Usuario usuario, string linkDeRedirecionamento)
        {
            Usuario = usuario;

            CaminhoUrl = linkDeRedirecionamento;

            var conteudo = SubstituirValores();

            ConstruirEmail(Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\EmailConfirmacaoDeCadastro.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", Usuario.NomeCompleto);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_urlDeRedirecionamento_", $"{CaminhoUrl}");

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(Usuario.Email.Endereco);
            await Task.Run(() => base.Send(_Email));
        }
    }
}