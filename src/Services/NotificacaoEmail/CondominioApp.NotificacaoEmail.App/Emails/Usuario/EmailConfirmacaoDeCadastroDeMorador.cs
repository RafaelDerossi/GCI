using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.Models;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailConfirmacaoDeCadastroDeMorador : ServicoDeEmail
    {
        private readonly string Assunto = "Confirmação de cadastro";
        private Usuario Usuario;        

        public EmailConfirmacaoDeCadastroDeMorador(Usuario usuario)
        {
            Usuario = usuario;           

            var conteudo = SubstituirValores();

            ConstruirEmail(Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\EmailConfirmacaoDeCadastroDeMorador.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", Usuario.NomeCompleto);            

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(Usuario.Email.Endereco);
            await Task.Run(() => base.Send(_Email));
        }
    }
}