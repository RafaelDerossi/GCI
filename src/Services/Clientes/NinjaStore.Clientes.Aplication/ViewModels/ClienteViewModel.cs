using NinjaStore.Core.ValueObjects;
using System;

namespace NinjaStore.Clientes.Domain.FlatModel
{    
    public class ClienteViewModel
   { 
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; private set; }

        public string DataDeCadastroFormatada { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public string DataDeAlteracaoFormatada { get; private set; }


        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Aldeia { get; private set; }

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
