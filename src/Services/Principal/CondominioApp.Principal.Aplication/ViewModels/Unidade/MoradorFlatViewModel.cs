using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class MoradorFlatViewModel
    {
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public Guid UsuarioId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string AndarUnidade { get; private set; }

        public string GrupoUnidade { get; private set; }

        public Guid CondominioId { get; private set; }

        public string NomeCondominio { get; private set; }

        public bool Proprietario { get; private set; }

        public bool Principal { get; private set; }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Rg { get; private set; }

        public string Cpf { get; private set; }

        public string Cel { get; private set; }

        public string Telefone { get; private set; }

        public string Email { get; private set; }

        public string Foto { get; private set; }


        public bool Ativo { get; private set; }

        public DateTime? DataNascimento { get; private set; }
        

        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }      




    }
}