using NinjaStore.Core.ValueObjects;
using System;

namespace NinjaStore.Clientes.Domain.FlatModel
{    
    public class ClienteViewModel
   { 
        public Guid Id { get; set; }

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

       
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Aldeia { get; private set; }

        public ClienteViewModel()
        {
        }

        public ClienteViewModel
            (Guid id, DateTime dataDeCadastro, DateTime dataDeAlteracao, string nome, string email, string aldeia)
        {
            Id = id;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeAlteracao;
            Nome = nome;
            Email = email;
            Aldeia = aldeia;
        }

        public static ClienteViewModel Mapear(ClienteFlat flat)
        {
            return new ClienteViewModel
            {
                Id = flat.ClienteId,
                DataDeCadastro = flat.DataDeCadastro,
                DataDeAlteracao = flat.DataDeAlteracao,
                Nome = flat.Nome,
                Email = flat.Email,
                Aldeia = flat.Aldeia
            };
        }
    }
}
