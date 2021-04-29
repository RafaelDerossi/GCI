using CondominioApp.Core.Enumeradores;
using CondominioAppPreCadastro.App.Models;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CondominioAppPreCadastro.App.EmailServices
{
    public class EmailPreCadastroEmpresa : ServicoDeEmail
    {
        private string _Assunto = "Novo pré cadastro realizado!";
        private Lead _lead;

        public EmailPreCadastroEmpresa(Lead lead)
        {
            _lead = lead;

            var conteudo = SubstituirValores();

            ConstruirEmail(_Assunto, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\PreCadastro\\precadastro-empresa.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("__name__", _lead.Nome);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("__email__", _lead.Email.Endereco);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("__telefone__", _lead.Telefone.ObterNumeroFormatado);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_condominios_", SubstituirValoresDosCondominios());

            return conteudoDoHtmlDoEmail;
        }

        public override async Task EnviarEmail()
        {
            _Email.To.Add("contato@condominioapp.com");
            _Email.To.Add("flavia@condominioapp.com");
            _Email.To.Add("antonio@techdog.com.br");
            _Email.To.Add("neia@techdog.com.br");
            _Email.To.Add("alexandre@techdog.com.br");

            await Task.Run(() => base.Send(_Email));
        }


        private string SubstituirValoresDosCondominios()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\PreCadastro\\condominio.html";

            var condominioHtml = File.ReadAllText(CaminhoDoHtml);

            StringBuilder sb = new StringBuilder();
            int indice = 0;

            foreach (var Condominio in _lead.Condominios)
            {
                indice++;
                condominioHtml = condominioHtml.Replace("_indice_", indice.ToString());
                condominioHtml = condominioHtml.Replace("__condominioNome__", Condominio.NomeDoCondominio);
                condominioHtml = condominioHtml.Replace("__razaoSocial__", Condominio.RazaoSocial);
                condominioHtml = condominioHtml.Replace("__sindicoNome__", Condominio.NomeDoSindico);
                condominioHtml = condominioHtml.Replace("__sindicoEmail__", Condominio.EmailDoSindico.Endereco);
                condominioHtml = condominioHtml.Replace("__tipoDeDocumento__", Condominio.TipoDeDocumento != TipoDeDocumento.OUTROS ? ((TipoDeDocumento)Condominio.TipoDeDocumento).ToString() : Condominio.OutroTipoDeDocumento);
                condominioHtml = condominioHtml.Replace("__numeroDoDocumento__", Condominio.NumeroDoDocumento);
                condominioHtml = condominioHtml.Replace("__tipoDeUnidade__", ((TipoDeUnidade)Condominio.TipoDeUnidade).ToString());
                condominioHtml = condominioHtml.Replace("__quantidadeDeUnidade__", Condominio.QuantidadeDeUnidades.ToString());
                condominioHtml = condominioHtml.Replace("__quantidadeDeAndar__", Condominio.QuantidadeDeAndar.ToString());
                condominioHtml = condominioHtml.Replace("__quantidadePorAndar__", Condominio.QuantidadeDeUnidadesPorAndar.ToString());
                condominioHtml = condominioHtml.Replace("__tipoDeGrupo__", ((TipoDeGrupo)Condominio.TipoDeGrupo).ToString());
                condominioHtml = condominioHtml.Replace("__plano__", ((TipoDePlano)Condominio.Plano).ToString());
                condominioHtml = condominioHtml.Replace("__sequenciaUnidadeObservacoes__", Condominio.Observacao);
                sb.AppendLine(condominioHtml);
            }

            return condominioHtml;
        }
    }
}