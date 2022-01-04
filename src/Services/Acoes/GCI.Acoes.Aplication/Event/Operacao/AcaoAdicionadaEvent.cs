using GCI.Core.Enumeradores;
using System;
namespace GCI.Acoes.Aplication.Events
{
    public class OperacaoAdicionadaEvent : OperacaoEvent
    {
        public OperacaoAdicionadaEvent
            (Guid operacaoId, DateTime dataDeCadastro,
             string codigoDaAcao, decimal preco, int quantidade, DateTime dataDaOperacao,
             decimal custoDaOperacao, decimal valorTotal, TipoOperacao tipo)
        {
            OperacaoId = operacaoId;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeCadastro;
            CodigoDaAcao = codigoDaAcao;
            Preco = preco;
            Quantidade = quantidade;
            DataDaOperacao = dataDaOperacao;
            CustoDaOperacao = custoDaOperacao;
            ValorTotal = valorTotal;
            Tipo = tipo;
        }
    }
}
