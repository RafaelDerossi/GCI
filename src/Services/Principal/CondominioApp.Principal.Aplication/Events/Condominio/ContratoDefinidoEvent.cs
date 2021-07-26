using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class ContratoDefinidoEvent : CondominioEvent
    {      
        public ContratoDefinidoEvent(Guid condominioId, Guid contratoId, DateTime dataAssinaturaContrato,
           TipoDePlano tipoPlano, string descricaoContrato, bool contratoAtivo,
           int quantidadeDeUnidadesContratadas, NomeArquivo arquivoContrato)            
        {
            CondominioId = condominioId;                   
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