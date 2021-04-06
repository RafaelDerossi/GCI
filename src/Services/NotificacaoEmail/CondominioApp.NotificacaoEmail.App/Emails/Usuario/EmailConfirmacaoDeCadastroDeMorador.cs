using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.FlatModel;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailConfirmacaoDeCadastroDeMorador : ServicoDeEmail
    {
        private readonly string Assunto = "Confirmação de cadastro";
        private MoradorFlat Morador;
        private string LogoCondominio;

        public EmailConfirmacaoDeCadastroDeMorador(MoradorFlat morador, string logoCondominio)
        {
            Morador = morador;

            LogoCondominio = logoCondominio;

            var conteudo = SubstituirValores();

            ConstruirEmail(Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\EmailConfirmacaoDeCadastroDeMorador.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", Morador.Nome);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_LogoCondominio_", LogoCondominio);

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(Morador.Email);
            await Task.Run(() => base.Send(_Email));
        }
    }
}