using System;
using System.Collections.Generic;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.ValueObjects;

namespace CondominioAppPreCadastro.App.Models
{
    public class Condominio : Entity
    {
        public const int Max = 1000;

        public string NomeDoCondominio { get; private set; }

        public string RazaoSocial { get; private set; }

        public string NomeDoSindico { get; private set; }

        public Email EmailDoSindico { get; private set; }

        public Telefone TelefoneDoSindico { get; private set; }

        public TipoDeDocumento TipoDeDocumento { get; private set; }

        public string OutroTipoDeDocumento { get; private set; }

        public string NumeroDoDocumento { get; private set; }

        public TipoDeUnidade TipoDeUnidade { get; private set; }

        public TipoDeGrupo TipoDeGrupo { get; private set; }

        public int QuantidadeDeGrupos { get; private set; }

        public int QuantidadeDeAndar { get; private set; }

        public int QuantidadeDeUnidadesPorAndar { get; private set; }

        public int QuantidadeDeUnidades { get; private set; }

        public string Observacao { get; private set; }

        public Endereco Endereco { get; private set; }

        public Guid LeadId { get; private set; }

        public Lead Lead { get; private set; }

        public TipoDePlano Plano { get; private set; }

        public bool Transferido { get; private set; }
        
        private readonly List<Arquivo> _arquivos;

        public IReadOnlyCollection<Arquivo> Arquivos => _arquivos;

        protected Condominio() { }

        public Condominio(string nomeDoCondominio, string razaoSocial, string nomeDoSindico, Email emailDoSindico, 
            Telefone telefoneDoSindico, TipoDeDocumento tipoDeDocumento, string outroTipoDeDocumento, string numeroDoDocumento, 
            TipoDeUnidade tipoDeUnidade, TipoDeGrupo tipoDeGrupo, int quantidadeDeGrupos, int quantidadeDeAndar, 
            int quantidadeDeUnidadesPorAndar, int quantidadeDeUnidades, string observacao, Endereco endereco,
            TipoDePlano plano)
        {
            NomeDoCondominio = nomeDoCondominio;
            RazaoSocial = razaoSocial;
            NomeDoSindico = nomeDoSindico;
            EmailDoSindico = emailDoSindico;
            TelefoneDoSindico = telefoneDoSindico;
            TipoDeDocumento = tipoDeDocumento;
            OutroTipoDeDocumento = outroTipoDeDocumento;
            NumeroDoDocumento = numeroDoDocumento;
            TipoDeUnidade = tipoDeUnidade;
            TipoDeGrupo = tipoDeGrupo;
            QuantidadeDeGrupos = quantidadeDeGrupos;
            QuantidadeDeAndar = quantidadeDeAndar;
            QuantidadeDeUnidadesPorAndar = quantidadeDeUnidadesPorAndar;
            QuantidadeDeUnidades = quantidadeDeUnidades;
            Observacao = observacao;
            Endereco = endereco;
            Plano = plano;

            NaoTransferir();
        }

        public void Transferir() => Transferido = true;

        public void NaoTransferir() => Transferido = false;

    }
}