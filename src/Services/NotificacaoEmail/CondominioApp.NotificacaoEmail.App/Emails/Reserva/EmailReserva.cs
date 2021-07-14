using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailReserva : ServicoDeEmail
    {   
        private readonly ReservaDTO _reserva;        
        private readonly string _logoCondominioApp = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";        

        public EmailReserva(ReservaDTO reserva)
        {
            _reserva = reserva;           

            var conteudo = SubstituirValores();

            ConstruirEmail(_reserva.Titulo, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Reserva\\reserva.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            if (string.IsNullOrEmpty(_reserva.LogoDoCondominio) || _reserva.LogoDoCondominio == "https://i.imgur.com/gxXxUm7.png")
                _reserva.LogoDoCondominio = _logoCondominioApp;

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_titulo_", _reserva.Titulo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_nomeCondominio_", _reserva.NomeCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_areaComum_", _reserva.AreaComumNome);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_data_", _reserva.DataRealizacao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_horaInicio_", _reserva.HoraInicio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_horaFim_", _reserva.HoraFim);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_morador_", _reserva.NomeMorador);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_descricaoUnidade_", _reserva.UnidadeDescricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_valor_", _reserva.Valor);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_observacao_", _reserva.Observacao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_justificativa_", _reserva.Justificativa);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_dataSolicitacao_", _reserva.DataDeCadastro);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominio_", _reserva.LogoDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominioApp_", _logoCondominioApp);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_corFundoTitulo_", _reserva.CorFundoTitulo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_protocolo_", _reserva.Protocolo);

            return conteudoDoHtmlDoEmail;
        }    

        public override async Task EnviarEmail()
        {
            if (_reserva.ListaDeEmails.Count() == 0)
                return;

            foreach (var email in _reserva.ListaDeEmails)
            {
                _Email.Bcc.Add(email);                
            }      
            
            await Task.Run(() => base.Send(_Email));
        }
    }
}