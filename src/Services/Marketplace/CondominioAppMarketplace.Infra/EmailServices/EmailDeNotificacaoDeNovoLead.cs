using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using CondominioApp.Core.DomainObjects;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Infra.EmailServices.Smtps;

namespace CondominioAppMarketplace.Infra.EmailServices
{
    public class EmailDeNotificacaoDeNovoLead : SmtpSendBlue, IServicoDeEmail
    {
        private readonly MailMessage _Email;

        private readonly List<string> _Destinatarios;

        private readonly Lead _lead;

        public EmailDeNotificacaoDeNovoLead(IAggregateRoot Aggregate, string Assunto)
        {
            _lead = (Lead)Aggregate;

            _Destinatarios = new List<string>();

            _Email = new MailMessage();

            _Destinatarios.Add(_lead.ItemDeVenda.Vendedor.Email.Endereco);

            var conteudo = SubstituirValores(Aggregate);

            ConstruirEmail(Assunto, conteudo);
        }

        public string SubstituirValores(IAggregateRoot Aggregate)
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Marketplace\\EmailDoVendedor.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoCondominio_", _lead.NomeDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoVendedor_", _lead.ItemDeVenda.Vendedor.Nome);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_EmailDoVendedor_", _lead.ItemDeVenda.Vendedor.Email.Endereco);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_NomeDoCliente_", _lead.NomeDoCliente);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_Bloco_", _lead.Bloco);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_Unidade_", _lead.Unidade);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_Observacao_", _lead.Observacao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_Telefone_", _lead.Telefone.ObterNumeroFormatado);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_produtoNome_", _lead.ItemDeVenda.Produto.Nome);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_produtoChamada_", _lead.ItemDeVenda.Produto.Chamada);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_produtoDescricao_", _lead.ItemDeVenda.Produto.Descricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_produtoEspecificacaoTecnica_", string.IsNullOrEmpty(_lead.ItemDeVenda.Produto.EspecificacaoTecnica) ? "Não informado" : _lead.ItemDeVenda.Produto.EspecificacaoTecnica);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_produtoPrecoDoProduto_", _lead.ItemDeVenda.PrecoComDescontoFormatado);

            return conteudoDoHtmlDoEmail;
        }

        public void ConstruirEmail(string Assunto, string ConteudoDoEmail)
        {
            _Email.From = new MailAddress("info@condominioapp.com", "Parceiros CondomínioApp");
            _Email.Subject = Assunto;
            _Email.IsBodyHtml = true;
            _Email.Body = ConteudoDoEmail;
        }

        public async Task EnviarEmail()
        {
            _Email.CC.Add(new MailAddress("contato@condominioapp.com", "Parceiros CondomínioApp.com"));

            foreach (var Destinatario in _Destinatarios)
            {
                _Email.To.Add(Destinatario);

                await Task.Run(() => base.Send(_Email));

                _Email.To.Clear();
            }
        }
    }
}
