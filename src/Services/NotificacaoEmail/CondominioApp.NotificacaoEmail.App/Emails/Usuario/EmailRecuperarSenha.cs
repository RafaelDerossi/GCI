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
        private readonly string _assunto = "Recuperar senha - CondomínioApp";
        private readonly string _caminhoUrl = string.Empty;
        private readonly string _nomeUsuario;
        private readonly string _emailUsuario;

        public EmailRecuperarSenha(string nomeUsuario, string emailUsuario, string token, string linkDeRedirecionamento)
        {
            _nomeUsuario = nomeUsuario;

            _emailUsuario = emailUsuario; ;            

            _caminhoUrl = $"{linkDeRedirecionamento}/{HttpUtility.UrlEncode(token)}/{_emailUsuario}";

            var conteudo = SubstituirValores();

            ConstruirEmail(_assunto, conteudo);
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(_emailUsuario);
            await Task.Run(() => base.Send(_Email));
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Usuario\\EmailEsqueciSenha.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", _nomeUsuario);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_urlDeRedirecionamento_", $"{_caminhoUrl}");

            return conteudoDoHtmlDoEmail;
        }
    }
}
