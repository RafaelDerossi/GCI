using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioAdicionadoEvent : CondominioEvent
    {
      
        public CondominioAdicionadoEvent(Guid id,
           Cnpj cnpj, string nome, string descricao, Foto logoMarca, Telefone telefone, Endereco endereo,
           bool portariaAtivada, bool portariaMoradorAtivada, bool classificadoAtivado, bool classificadoMoradorAtivado,
           bool muralAtivado, bool muralMoradorAtivado, bool chatAtivado, bool chatMoradorAtivado,
           bool reservaAtivada, bool reservaNaPortariaAtivada, bool ocorrenciaAtivada,
           bool ocorrenciaMoradorAtivada, bool correspondenciaAtivada, bool correspondenciaNaPortariaAtivada,
           bool cadastraVeiculoPeloMoradorAtivado, Guid contratoId, DateTime dataAssinaturaContrato,
           TipoDePlano tipoPlano, string descricaoContrato, bool contratoAtivo,
           int quantidadeDeUnidadesContratadas, NomeArquivo arquivoContrato)            
        {
            CondominioId = id;       
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
            Endereco = endereo;            
            PortariaAtivada = portariaAtivada;
            PortariaMoradorAtivada = portariaMoradorAtivada;
            ClassificadoAtivado = classificadoAtivado;
            ClassificadoMoradorAtivado = classificadoMoradorAtivado;
            MuralAtivado = muralAtivado;
            MuralMoradorAtivado = muralMoradorAtivado;
            ChatAtivado = chatAtivado;
            ChatMoradorAtivado = chatMoradorAtivado;
            ReservaAtivada = reservaAtivada;
            ReservaNaPortariaAtivada = reservaNaPortariaAtivada;
            OcorrenciaAtivada = ocorrenciaAtivada;
            OcorrenciaMoradorAtivada = ocorrenciaMoradorAtivada;
            CorrespondenciaAtivada = correspondenciaAtivada;
            CorrespondenciaNaPortariaAtivada = correspondenciaNaPortariaAtivada;
            CadastroDeVeiculoPeloMoradorAtivado = cadastraVeiculoPeloMoradorAtivado;
            ContratoId = contratoId;
            DataAssinatura = dataAssinaturaContrato;
            TipoPlano = tipoPlano;
            DescricaoContrato = descricaoContrato;
            ContratoAtivo = contratoAtivo;
            QuantidadeDeUnidadesContratadas = quantidadeDeUnidadesContratadas;
            ArquivoContrato = arquivoContrato;
        }


    }
}