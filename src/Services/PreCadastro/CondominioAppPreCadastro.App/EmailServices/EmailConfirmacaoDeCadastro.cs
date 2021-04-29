using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CondominioAppPreCadastro.App.EmailServices
{
    public class EmailConfirmacaoDeCadastro : ServicoDeEmail
    {
        private string _Assunto = "Confirmação de cadastro";
        private string _NomeDoUsuario;
        private string _EmailDoCliente;

        public EmailConfirmacaoDeCadastro(string Email, string NomeDoUsuario)
        {
            _EmailDoCliente = Email;
            _NomeDoUsuario = NomeDoUsuario;

            var conteudo = SubstituirValores();

            ConstruirEmail(_Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\PreCadastro\\precadastro-cliente.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_name_", _NomeDoUsuario);

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add(_EmailDoCliente);
          
            _Email.ReplyToList.Add(new MailAddress("contato@condominioapp.com"));
            _Email.ReplyToList.Add(new MailAddress("contato@techdog.com.br"));

            await Task.Run(() => base.Send(_Email));
        }
    }
}