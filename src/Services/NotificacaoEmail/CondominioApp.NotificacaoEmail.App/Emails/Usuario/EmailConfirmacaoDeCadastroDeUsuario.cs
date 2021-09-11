using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.Models;
using System.IO;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailConfirmacaoDeCadastroDeUsuario : ServicoDeEmail
    {
        private readonly string _assunto = "Confirmação de cadastro";
        private readonly Usuario _usuario;       

        public EmailConfirmacaoDeCadastroDeUsuario(Usuario usuario)
        {
            _usuario = usuario;            

            var conteudo = SubstituirValores();

            ConstruirEmail(_assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Usuario\\EmailConfirmacaoDeCadastro.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoUsuario_", _usuario.NomeCompleto);            

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(_usuario.Email.Endereco);
            await Task.Run(() => base.Send(_Email));
        }
    }
}