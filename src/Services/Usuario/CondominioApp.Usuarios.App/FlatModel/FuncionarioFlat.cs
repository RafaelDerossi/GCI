using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
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

        public string Atribuicao { get; private set; }

        public string Funcao { get; private set; }

        public bool SindicoProfissional { get; private set; }

        public Permissao Permissao { get; private set; }

        public string DescricaoPermissao { get; private set; }


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


        public FuncionarioFlat()
        {
        }

        public FuncionarioFlat
            (Guid id, Guid usuarioId, Guid condominioId, string nomeCondominio, string atribuicao, string funcao,
            bool sindicoProfissional, Permissao permissao, string nome, string sobrenome, string rg, 
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
            Celular = cel;
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
            SetPermissao(permissao);
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
                Celular = cel.Numero;
            else
                Celular = "";
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


        public void SetFuncao(string funcao) => Funcao = funcao;

        public void SetAtribuicao(string atribuicao) => Atribuicao = atribuicao;

        public void SetPermissao(Permissao permissao)
        {
            Permissao = permissao;

            switch (permissao)
            {
                case Permissao.USUARIO:
                    DescricaoPermissao = "Usuario";
                    break;
                case Permissao.ADMIN:
                    DescricaoPermissao = "Administrador";
                    break;
                default:
                    break;
            }            
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

    }
}