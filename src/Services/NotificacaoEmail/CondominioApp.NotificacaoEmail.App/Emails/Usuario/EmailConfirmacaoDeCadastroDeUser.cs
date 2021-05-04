using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailConfirmacaoDeCadastroDeUser : ServicoDeEmail
    {
        private readonly string _assunto = "Confirmação de cadastro";
        private readonly string _nomeUsuario;
        private readonly string _emailUsuario;
        private readonly string _caminhoUrl;

        public EmailConfirmacaoDeCadastroDeUser(string nomeUsuario, string emailUsuario, string linkDeRedirecionamento)
        {
            _nomeUsuario = nomeUsuario;

            _emailUsuario = emailUsuario;

            _caminhoUrl = linkDeRedirecionamento;

            var conteudo = SubstituirValores();

            ConstruirEmail(_assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Usuario\\EmailConfirmacaoDeCadastro.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", _nomeUsuario);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_urlDeRedirecionamento_", $"{_caminhoUrl}");

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(_emailUsuario);
            await Task.Run(() => base.Send(_Email));
        }
    }
}