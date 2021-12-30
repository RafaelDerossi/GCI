using GCI.Core.ValueObjects;
using GCI.Core.DomainObjects;
using System;

namespace GCI.Acoes.Domain.FlatModel
{
    [BsonCollection("ClienteFlat")]
    public class ClienteFlat : Document, IAggregateRoot
   {
        public const int Max = 200;
        public Guid ClienteId { get; private set; }

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

        protected ClienteFlat()
        {
        }

        public ClienteFlat(Guid id, DateTime dataDeCadastro, string nome, Email email, string aldeia)
        {
            ClienteId = id;
            Nome = nome;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeCadastro;
            SetEmail(email);
            Aldeia = aldeia;
        }

        public void SetEntidadeId(Guid NovoId) => ClienteId = NovoId;       

        public void SetNome(string nome) => Nome = nome;

        public void SetEmail(Email email)
        {
            if (email == null)
                Email = "";
            Email = email.Endereco;
        }

        public void SetAldeia(string aldeia) => Aldeia = aldeia;

    }
}
