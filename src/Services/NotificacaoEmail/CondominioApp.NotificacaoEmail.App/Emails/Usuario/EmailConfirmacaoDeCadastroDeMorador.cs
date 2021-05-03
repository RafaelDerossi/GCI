using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.FlatModel;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailConfirmacaoDeCadastroDeMorador : ServicoDeEmail
    {
        private readonly string _assunto = "Confirmação de cadastro";
        private MoradorFlat _morador;
        private string _logoCondominio;

        public EmailConfirmacaoDeCadastroDeMorador(MoradorFlat morador, string logoCondominio)
        {
            _morador = morador;

            _logoCondominio = logoCondominio;

            var conteudo = SubstituirValores();

            ConstruirEmail(_assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Usuario\\EmailConfirmacaoDeCadastroDeMorador.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", _morador.NomeCompleto());
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_LogoCondominio_", _logoCondominio);

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(_morador.Email);
            await Task.Run(() => base.Send(_Email));
        }
    }
}