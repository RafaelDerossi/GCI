using GCI.Core.DomainObjects;
using System;

namespace GCI.Acoes.Domain.FlatModel
{
    [BsonCollection("AcaoFlat")]
    public class AcaoFlat : Document, IAggregateRoot
   {        
        public Guid AcaoId { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public string DataDeCadastroFormatada
        {
            get
            {
                if (DataDeCadastro != null)
                    return DataDeCadastro.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public DateTime DataDeAlteracao { get; private set; }

        public string DataDeAlteracaoFormatada
        {
            get
            {
                if (DataDeAlteracao != null)
                    return DataDeAlteracao.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }                

       
        public string Codigo { get; private set; }        

        public string RazaoSocial { get; private set; }

        protected AcaoFlat()
        {
        }

        public AcaoFlat(Guid id, DateTime dataDeCadastro, string codigo, string razaoSocial)
        {
            AcaoId = id;            
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeCadastro;
            Codigo = codigo;            
            RazaoSocial = razaoSocial;
        }

        public void SetEntidadeId(Guid NovoId) => AcaoId = NovoId;       

        public void SetCodigo(string codigo) => Codigo = codigo;
        
        public void SetRazaoSocial(string razaoSocial) => RazaoSocial = razaoSocial;

    }
}
