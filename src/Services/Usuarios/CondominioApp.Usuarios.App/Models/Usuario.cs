using System;
using System.Collections.Generic;
using System.Linq;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Models
{
    public class Usuario : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Rg { get; private set; }

        public Cpf Cpf { get; private set; }

        public Telefone Cel { get; private set; }

        public Telefone Telefone { get; private set; }

        public Email Email { get; private set; }

        public Foto Foto { get; private set; }    

        public DateTime? DataNascimento { get; private set; }

        public Endereco Endereco { get; set; }
       

        public bool Ativo { get; private set; }

        public DateTime? UltimoLogin { get; private set; }

        public bool SindicoProfissional { get; private set; }

        protected Usuario() { }

        public Usuario(string nome, string sobrenome, string rg, Telefone cel, Email email, 
            Foto foto, DateTime? dataNascimento = null,
            Cpf cpf = null, Telefone telefone = null, Endereco endereco = null,
            bool sindicoProfissional = false)
        {            
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;            
            DataNascimento = dataNascimento;
            Endereco = endereco;
            SindicoProfissional = sindicoProfissional;

            Ativar();
        }

        public string NomeCompleto
        {
            get { return $"{Nome} {Sobrenome}"; }
        }



        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AtivarSindicoProfissional() => SindicoProfissional = true;

        public void DesativarSindicoProfissional() => SindicoProfissional = false;

        public void AtualizarUltimoLogin() => UltimoLogin = DateTime.UnixEpoch;

        public void SetNome(string nome) => Nome = nome;

        public void SetSobrenome(string sobrenome) => Sobrenome = sobrenome;

        public void SetRg(string rg) => Rg = rg;

        public void SetCpf(Cpf cpf) => Cpf = cpf;

        public void SetTelefone(Telefone telefone) => Telefone = telefone;

        public void SetCelular(Telefone cel) => Cel = cel;

        public void SetEmail(Email email) => Email = email;

        public void SetFoto(Foto foto) => Foto = foto;

        public void SetEndereco(Endereco endereco) => Endereco = endereco;




        public void SetDataNascimento(DateTime? dataNascimento) => DataNascimento = dataNascimento;


        
        public string ObterCPF()
        {
            if (Cpf == null)
                return "";
            return Cpf.Numero;
        }

        public string ObterCelular()
        {
            if (Cel == null)
                return "";
            return Cel.Numero;
        }

        public string ObterTelefone()
        {
            if (Telefone == null)
                return "";
            return Telefone.Numero;
        }

        public string ObterEmail()
        {
            if (Email == null)
                return "";
            return Email.Endereco;
        }

        public string ObterFoto()
        {
            if (Foto == null)
                return "";
            return Foto.NomeDoArquivo;
        }

        public string ObterLogradouro()
        {
            if (Endereco == null)
                return "";
            return Endereco.logradouro;
        }

        public string ObterComplemento()
        {
            if (Endereco == null)
                return "";
            return Endereco.complemento;
        }

        public string ObterNumero()
        {
            if (Endereco == null)
                return "";
            return Endereco.numero;
        }

        public string ObterCep()
        {
            if (Endereco == null)
                return "";
            return Endereco.cep;
        }

        public string ObterBairro()
        {
            if (Endereco == null)
                return "";
            return Endereco.bairro;
        }

        public string ObterCidade()
        {
            if (Endereco == null)
                return "";
            return Endereco.cidade;
        }

        public string ObterEstado()
        {
            if (Endereco == null)
                return "";
            return Endereco.estado;
        }

    }
}