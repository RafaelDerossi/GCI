using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioEvent : Event
    {
        public Guid CondominioId { get; protected set; }  

        public Cnpj Cnpj { get; protected set; }

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public Foto LogoMarca { get; protected set; }

        public Telefone Telefone { get; protected set; }

        public Endereco Endereco { get; protected set; }


       
        public int? RefereciaId { get; protected set; }

        public string LinkGeraBoleto { get; protected set; }

        public string BoletoFolder { get; protected set; }

        public Url UrlWebServer { get; protected set; }


        public Guid FuncionarioIdDoSindico { get; protected set; }

        public string NomeDoSindico { get; protected set; }

        public bool PortariaAtivada { get; protected set; }

        public bool PortariaMoradorAtivada { get; protected set; }

        public bool ClassificadoAtivado { get; protected set; }
     
        public bool ClassificadoMoradorAtivado { get; protected set; }
       
        public bool MuralAtivado { get; protected set; }

        public bool MuralMoradorAtivado { get; protected set; }

        public bool ChatAtivado { get; protected set; }

        public bool ChatMoradorAtivado { get; protected set; }

        public bool ReservaAtivada { get; protected set; }

        public bool ReservaNaPortariaAtivada { get; protected set; }

        public bool OcorrenciaAtivada { get; protected set; }

        public bool OcorrenciaMoradorAtivada { get; protected set; }

        public bool CorrespondenciaAtivada { get; protected set; }

        public bool CorrespondenciaNaPortariaAtivada { get; protected set; }

        public bool CadastroDeVeiculoPeloMoradorAtivado { get; protected set; }

        public bool EnqueteAtivada { get; protected set; }

        public bool ControleDeAcessoAtivado { get; protected set; }

        public bool TarefaAtivada { get; protected set; }

        public bool OrcamentoAtivado { get; protected set; }

        public bool AutomacaoAtivada { get; protected set; }


        public Guid ContratoId { get; protected set; }

        public DateTime DataAssinatura { get; protected set; }

        public TipoDePlano TipoPlano { get; protected set; }       

        public string DescricaoContrato { get; protected set; }

        public bool ContratoAtivo { get; protected set; }

        public int QuantidadeDeUnidadesContratadas { get; protected set; }

        public NomeArquivo ArquivoContrato { get; protected set; }

    }
}