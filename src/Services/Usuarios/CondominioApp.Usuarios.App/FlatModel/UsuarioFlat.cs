using System;
using System.Collections.Generic;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.ValueObjects;

namespace CondominioApp.Usuarios.App.Models.FlatModel
{
    public class UsuarioFlat
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Cel { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }

        public string TpUsuario { get; set; }

        public string Permissao { get; set; }

        public bool Ativo { get; private set; }

        public string Atribuicao { get; private set; }

        public string Funcao { get; private set; }

        public DateTime? DataNascimento { get; private set; }

        public DateTime? UltimoLogin { get; private set; }

        public string logradouro { get; set; }

        public string complemento { get; set; }

        public string numero { get; set; }

        public string cep { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public bool SindicoProfissional { get; private set; }

        public UsuarioFlat(Guid id, string nome, string sobrenome, string rg, string cpf, string cel, 
            string telefone, string email, string foto, string tpUsuario, string permissao, bool ativo,
            string atribuicao, string funcao, DateTime? dataNascimento, DateTime? ultimoLogin,
            string logradouro, string complemento, string numero, string cep, string bairro,
            string cidade, string estado, bool sindicoProfissional)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            Cpf = cpf;
            Cel = cel;
            Telefone = telefone;
            Email = email;
            Foto = foto;
            TpUsuario = tpUsuario;
            Permissao = permissao;
            Ativo = ativo;
            Atribuicao = atribuicao;
            Funcao = funcao;
            DataNascimento = dataNascimento;
            UltimoLogin = ultimoLogin;
            this.logradouro = logradouro;
            this.complemento = complemento;
            this.numero = numero;
            this.cep = cep;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
            SindicoProfissional = sindicoProfissional;
        }
    }
}