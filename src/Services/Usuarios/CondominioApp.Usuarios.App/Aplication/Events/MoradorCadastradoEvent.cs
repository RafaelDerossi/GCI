using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.ValueObjects;
using FluentValidation;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorCadastradoEvent : Core.Messages.Event
    {
        public Guid UsuarioId { get; set; }

        public string Nome { get; protected set; }

        public string Sobrenome { get; protected set; }

        public string Rg { get; protected set; }

        public Cpf Cpf { get; protected set; }

        public Telefone Cel { get; protected set; }

        public Email Email { get; protected set; }

        public Foto Foto { get; protected set; }

        public TipoDeUsuario TpUsuario { get; protected set; }

        public Permissao Permissao { get; protected set; }

        public DateTime? DataNascimento { get; protected set; }
        public MoradorCadastradoEvent(Guid usuarioId, string nome, string sobrenome, string email,
            string rg = null, string cpf = null, string cel = null, string foto = null,
            string nomeOriginal = null, DateTime? dataNascimento = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            TpUsuario = TipoDeUsuario.CLIENTE;
            Permissao = Permissao.USUARIO;

            Cpf = new Cpf(cpf);
            Cel = new Telefone(cel);
            Email = new Email(email);
            Foto = new Foto(nomeOriginal, foto);
        }
    }
}