using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioEditadoEvent : UsuarioEvent
    {        
        public UsuarioEditadoEvent(Guid usuarioId, string nome, string sobrenome, Email email,
            string rg = null, Cpf cpf = null, Telefone cel = null, Foto foto = null,
            Endereco endereco = null, DateTime? dataNascimento = null)
        {            
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Rg = rg;
            Cpf = cpf;  
            Cel = cel;
            Foto = foto;
            Endereco = endereco;
            DataNascimento = dataNascimento;

        }
    }
}