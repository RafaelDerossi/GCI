using GCI.Core.ValueObjects;
using System;

namespace GCI.Acoes.Domain.FlatModel
{    
    public class ClienteViewModel
   { 
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }


        public string Nome { get; set; }

        public string Email { get; set; }

        public string Aldeia { get; set; }

        public ClienteViewModel()
        {
        }        


        public static ClienteViewModel Mapear(ClienteFlat flat)
        {
            return new ClienteViewModel
            {
                Id = flat.ClienteId,
                DataDeCadastro = flat.DataDeCadastro,
                DataDeCadastroFormatada = flat.DataDeCadastroFormatada,
                DataDeAlteracao = flat.DataDeAlteracao,
                DataDeAlteracaoFormatada = flat.DataDeAlteracaoFormatada,
                Nome = flat.Nome,
                Email = flat.Email,
                Aldeia = flat.Aldeia
            };
        }
    }
}
