using System;
namespace GCI.Acoes.Aplication.Events
{
    public class AcaoAdicionadaEvent : AcaoEvent
    {

        public AcaoAdicionadaEvent
            (Guid acaoId, DateTime dataDeCadastro, string codigo, string razaoSocial)
        {
            AggregateId = acaoId;
            AcaoId = acaoId;
            DataDeCadastro = dataDeCadastro;            
            Codigo = codigo;            
            RazaoSocial = razaoSocial;
        }        
    }
}
