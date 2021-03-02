using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.FlatModel
{
    public class FuncionarioFlat : IAggregateRoot
    {
        public const int Max = 200;

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public Guid UsuarioId { get; private set; }       

        public Guid CondominioId { get; private set; }

        public string NomeCondominio { get; private set; }        

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Rg { get; private set; }

        public string Cpf { get; private set; }

        public string Cel { get; private set; }

        public string Telefone { get; private set; }

        public string Email { get; private set; }

        public string Foto { get; private set; }

        public string TpUsuario { get; private set; }

        public string Atribuicao { get; private set; }

        public string Funcao { get; private set; }

        public bool SindicoProfissional { get; set; }

        public bool Ativo { get; private set; }

        public DateTime? DataNascimento { get; private set; }


        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }



        public FuncionarioFlat()
        {
        }

        public FuncionarioFlat
            (Guid id, Guid usuarioId, Guid condominioId, string nomeCondominio, string nome, string sobrenome, string rg,
            string cpf, string cel, string telefone, string email, string foto, string tpUsuario, DateTime? dataNascimento, 
            string logradouro, string complemento, string numero, string cep, string bairro, string cidade, string estado)
        {
            Id = id;            
            UsuarioId = usuarioId;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;
            TpUsuario = tpUsuario;
            Ativo = true;
            DataNascimento = dataNascimento;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

    }
}