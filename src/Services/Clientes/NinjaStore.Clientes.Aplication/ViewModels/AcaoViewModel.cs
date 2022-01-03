using GCI.Core.ValueObjects;
using System;

namespace GCI.Acoes.Domain.FlatModel
{    
    public class AcaoViewModel
   { 
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }


        public string Codigo { get; set; }        

        public string RazaoSocial { get; set; }

        public AcaoViewModel()
        {
        }        


        public static AcaoViewModel Mapear(AcaoFlat flat)
        {
            return new AcaoViewModel
            {
                Id = flat.AcaoId,
                DataDeCadastro = flat.DataDeCadastro,
                DataDeCadastroFormatada = flat.DataDeCadastroFormatada,
                DataDeAlteracao = flat.DataDeAlteracao,
                DataDeAlteracaoFormatada = flat.DataDeAlteracaoFormatada,
                Codigo = flat.Codigo,                
                RazaoSocial = flat.RazaoSocial
            };
        }
    }
}
