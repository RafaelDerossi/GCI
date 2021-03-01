using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.FlatModel
{
    public class MoradorFlat : IAggregateRoot
    {
        public const int Max = 200;

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public Guid UsuarioId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public Guid CondominioId { get; private set; }

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

        public string TpUsuario { get; private set; }



        public bool Ativo { get; private set; }

        public DateTime? DataNascimento { get; private set; }
        

        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }


        public bool SindicoProfissional { get; private set; }



        public MoradorFlat()
        {
        }

        public MoradorFlat
            (Guid usuarioId, Guid unidadeId, Guid condominioId, bool proprietario, bool principal, string nome, string sobrenome,
            string rg, string cpf, string cel, string telefone, string email, string foto, string tpUsuario,
            bool ativo, DateTime? dataNascimento, string logradouro, string complemento,
            string numero, string cep, string bairro, string cidade, string estado, bool sindicoProfissional)
        {            
            UsuarioId = usuarioId;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
            Proprietario = proprietario;
            Principal = principal;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;
            TpUsuario = tpUsuario;
            Ativo = ativo;
            DataNascimento = dataNascimento;            
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            SindicoProfissional = sindicoProfissional;
        }



        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

    }
}