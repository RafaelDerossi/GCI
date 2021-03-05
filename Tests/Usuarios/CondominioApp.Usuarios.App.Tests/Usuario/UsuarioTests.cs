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
        [Fact(DisplayName = "Criar um Usuario")]
        public void Criar_Usuario_Valido()
        {
            //Act
            var usuario = new Usuario("Nome", "sobrenome", "52145256", new Telefone("(21) 99796-7038"),
                new Email("alexandre@techdog.com.br"), new Foto("Foto.jpg", "Foto.jpg"));

        }


        [Fact(DisplayName = "Criar um usuario Sem foto")]
        public void Criar_Usuario_Valido_SemFoto()
        {
            //Act
            var usuario = new Usuario("Nome", "sobrenome", "52145256", new Telefone("(21) 99796-7038"),
               new Email("alexandre@techdog.com.br"), new Foto("", ""));
        }

    }
}