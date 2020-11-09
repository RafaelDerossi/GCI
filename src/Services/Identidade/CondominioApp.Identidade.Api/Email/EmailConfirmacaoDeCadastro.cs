using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CondominioApp.Identidade.Api.Email
{
    public class EmailConfirmacaoDeCadastro : ServicoDeEmail
    {
        private IdentityUser _usuario;
        private string _Assunto = "Confirmação de cadastro";
        private string _NomeDoUsuario;

        public string caminhoUrl { get; private set; }

        public EmailConfirmacaoDeCadastro(IdentityUser Usuario, string LinkDeRedirecionamento, string NomeDoUsuario)
        {
            _usuario = Usuario;
            _NomeDoUsuario = NomeDoUsuario;

            caminhoUrl = LinkDeRedirecionamento;

            var conteudo = SubstituirValores();

            ConstruirEmail(_Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\EmailConfirmacaoDeCadastro.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", _NomeDoUsuario);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_urlDeRedirecionamento_", $"{caminhoUrl}");

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(_usuario.Email);
            await Task.Run(() => base.Send(_Email));
        }
    }
}