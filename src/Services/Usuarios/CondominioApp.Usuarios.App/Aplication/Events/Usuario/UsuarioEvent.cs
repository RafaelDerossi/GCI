using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioEvent : Core.Messages.Event
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Nome { get; protected set; }

        public string Sobrenome { get; protected set; }

        public string Rg { get; protected set; }

        public Cpf Cpf { get; protected set; }

        public Telefone Cel { get; protected set; }

        public Telefone Telefone { get; protected set; }

        public Email Email { get; protected set; }

        public Foto Foto { get; protected set; }

        public bool Ativo { get; protected set; }

        public TipoDeUsuario TpUsuario { get; protected set; }

        public Permissao Permissao { get; protected set; }

        public string Atribuicao { get; protected set; }

        public string Funcao { get; protected set; }

        public bool SindicoProfissional { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }

        public Guid UnidadeId { get; protected set; }

        public string NumeroUnidade { get; protected set; }

        public string AndarUnidade { get; protected set; }

        public string GrupoUnidade { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

        public bool Proprietario { get; protected set; }

        public bool Principal { get; protected set; }


        public Endereco Endereco { get; protected set; }



        public void SetNome(string nome) => Nome = nome;

        public void SetCpf(Cpf cpf) => Cpf = cpf;

        public void SetCelular(Telefone cel) => Cel = cel;

        public void SetTelefone(Telefone tel) => Telefone = tel;

        public void SetEmail(Email email) => Email = email;            

        public void SetFoto(Foto foto)=> Foto = foto;

    }
}