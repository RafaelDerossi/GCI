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

        public string Celular { get; private set; }

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


        public string NomeCompleto
        {
            get { return $"{Nome} {Sobrenome}"; }
        }

        public string CpfFormatado
        {
            get
            {
                if (Cpf != null && Cpf.Length == 11)
                    return $"{Cpf.Substring(0, 3)}.{Cpf.Substring(3, 3)}.{Cpf.Substring(6, 3)}-{Cpf.Substring(9, 2)}";
                return Cpf;
            }
        }

        public string TelefoneFormatado
        {
            get
            {
                if (Telefone != null && Telefone.Length == 10)
                    return $"({Telefone.Substring(0, 2)}) {Telefone.Substring(2, 4)}-{Telefone.Substring(6, 4)}";
                return Telefone;
            }
        }

        public string CelularFormatado
        {
            get
            {
                if (Celular != null && Celular.Length == 11)
                    return $"({Celular.Substring(0, 2)}) {Celular.Substring(2, 5)}-{Celular.Substring(7, 4)}";
                return Celular;
            }
        }

    }
}