using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioCommandFactory
    {
        public static CadastrarMoradorCommand CadastrarMoradorCommandFactoy()
        {
            return new CadastrarMoradorCommand
                (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", Guid.NewGuid(), "Nome condominio",
                 Guid.NewGuid(), "101","1","Bloco A", "foto2.jpg", "fotoOriginal.jpg", "874541213", "689.560.890-78",
                 "(21) 99988-5241", "(21) 99988-5241", true, true, "logradouro", "lt 30","S/N","","Bairro","Rio de Janeiro",
                 "RJ", new DateTime(1985, 05, 10));
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMorador()
        {
            return CadastrarMoradorCommandFactoy();
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemFoto()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetFoto("", "");

            return comando;
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemNome()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetNome("");

            return comando;
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemEmail()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetEmail("");

            return comando;
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorComEmailInvalido()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetEmail("alexandre@techdog");

            return comando;
            
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorSemDataDeNascimento()
        {
            try
            {
                return new CadastrarMoradorCommand
                 (Guid.NewGuid(), "Nome", "Sobrenome", "alexandre@techdog.com.br", Guid.NewGuid(), "Nome condominio",
                 Guid.NewGuid(), "101", "1", "Bloco A", "foto2.jpg", "fotoOriginal.jpg", "874541213", "689.560.890-78",
                 "(21) 99988-5241", "(21) 99988-5241", true, true, "logradouro", "lt 30", "S/N", "", "Bairro", "Rio de Janeiro",
                 "RJ");
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMoradorCPFInvalido()
        {
            var comando = CadastrarMoradorCommandFactoy();
            comando.SetCpf("689.560.890-77");

            return comando;
           
        }
    }
}