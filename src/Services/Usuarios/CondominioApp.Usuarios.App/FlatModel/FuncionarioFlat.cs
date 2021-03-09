using CondominioApp.Core.DomainObjects;
using CondominioApp.Usuarios.App.ValueObjects;
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

        public bool Ativo { get; private set; }

        public DateTime? DataNascimento { get; private set; }


        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string Atribuicao { get; private set; }

        public string Funcao { get; private set; }

        public bool SindicoProfissional { get; set; }

        public string Permissao { get; set; }


        public FuncionarioFlat()
        {
        }

        public FuncionarioFlat
            (Guid id, Guid usuarioId, Guid condominioId, string nomeCondominio, string atribuicao, string funcao,
            bool sindicoProfissional, string permissao, string nome, string sobrenome, string rg, 
             string cpf, string cel, string telefone, string email, string foto, DateTime? dataNascimento,
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
            Ativo = true;
            DataNascimento = dataNascimento;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Atribuicao = atribuicao;
            Funcao = funcao;
            SindicoProfissional = sindicoProfissional;
            Permissao = permissao;
        }

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;



        public void SetNome(string nome) => Nome = nome;

        public void SetSobrenome(string sobrenome) => Sobrenome = sobrenome;

        public void SetRg(string rg) => Rg = rg;

        public void SetCpf(Cpf cpf)
        {
            if (cpf != null)
                Cpf = cpf.Numero;
            else
                Cpf = "";
        }


        public void SetTelefone(Telefone telefone)
        {
            if (telefone != null)
                Telefone = telefone.Numero;
            else
                Telefone = "";
        }

        public void SetCelular(Telefone cel)
        {
            if (cel != null)
                Cel = cel.Numero;
            else
                Cel = "";
        }

        public void SetEmail(Email email)
        {
            if (email != null)
                Email = email.Endereco;
            else
                Email = "";
        }

        public void SetFoto(Foto foto)
        {
            if (foto != null)
                Foto = foto.NomeDoArquivo;
            else
                Foto = "";
        }

        public void SetEndereco(Endereco endereco)
        {
            Logradouro = endereco.logradouro;
            Complemento = endereco.complemento;
            Numero = endereco.numero;
            Cep = endereco.cep;
            Bairro = endereco.bairro;
            Cidade = endereco.cidade;
            Estado = endereco.estado;
        }

    }
}