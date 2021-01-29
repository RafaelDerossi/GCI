using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.ValueObjects;
using Xunit;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioTests
    {
        [Fact(DisplayName = "Criar um Morador")]
        public void Criar_Morador_Valido()
        {
            //Act
            var usuario = new Usuario("Alexandre", "Nascimento", "52145256", new Telefone("(21) 99796-7038"),
                new Email("alexandre@techdog.com.br"),
                new Foto("Foto.jpg", "Foto.jpg"), TipoDeUsuario.CLIENTE, Permissao.USUARIO);

        }


        [Fact(DisplayName = "Criar um Morador Sem foto")]
        public void Criar_Morador_Valido_SemFoto()
        {
            //Act
            var usuario = new Usuario("Alexandre", "Nascimento", "52145256", new Telefone("(21) 99796-7038"),
                new Email("alexandre@techdog.com.br"),
                new Foto("", ""), TipoDeUsuario.CLIENTE, Permissao.USUARIO);

        }

    }
}