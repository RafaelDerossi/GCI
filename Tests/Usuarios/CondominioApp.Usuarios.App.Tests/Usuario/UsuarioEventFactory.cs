using System;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioEventFactory
    {
        public static MoradorCadastradoEvent MoradorCadastradoEventFactory()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), Guid.NewGuid(), "Nome", "Sobrenome", new Email("alexandre@techdog.com.br"),
                Guid.NewGuid(), "Nome condominio", Guid.NewGuid(),"101", "1", "Bloco A", new Foto("foto2.jpg", "foto2.jpg"),
                "874541213", new Cpf("689.560.890-78"), new Telefone("(21) 99988-5241"), new Telefone("(21) 99988-5241"),
                true, true, new Endereco("Logradouro", "Complemento", "numero", "", "Bairro", "Cidade", "RJ"),
                new DateTime(1985, 05, 10));
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMorador()
        {
            return MoradorCadastradoEventFactory();
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemFoto()
        {
            var comando = MoradorCadastradoEventFactory();
            comando.SetFoto(new Foto("",""));
            return comando;
        }

        public static MoradorCadastradoEvent CriarEventoadastroDeMoradorSemNome()
        {
            var comando = MoradorCadastradoEventFactory();
            comando.SetNome("");
            return comando;
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemEmail()
        {
            var comando = MoradorCadastradoEventFactory();
            comando.SetEmail(new Email(""));
            return comando;
        }

        public static MoradorCadastradoEvent CriarEventoCadastroDeMoradorSemDataDeNascimento()
        {
            return new MoradorCadastradoEvent(Guid.NewGuid(), Guid.NewGuid(), "Nome", "Sobrenome", new Email("alexandre@techdog.com.br"),
                Guid.NewGuid(), "Nome condominio", Guid.NewGuid(), "101", "1", "Bloco A", new Foto("foto2.jpg", "foto2.jpg"),
                "874541213", new Cpf("689.560.890-78"), new Telefone("(21) 99988-5241"), new Telefone("(21) 99988-5241"),
                true, true, new Endereco("Logradouro", "Complemento", "numero", "", "Bairro", "Cidade", "RJ"));
        }
    }
}