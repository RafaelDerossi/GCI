using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MoradorCommandFactory
    {
        public static AdicionarMoradorCommand CadastrarMoradorCommandFactoy()
        {
            return new AdicionarMoradorCommand
                (Guid.NewGuid(), Guid.NewGuid(), "NomeCondominio", Guid.NewGuid(),
                "101", "1", "Bloco A", true, true, true);
        }

        public static AdicionarMoradorCommand CriarComandoCadastroDeMorador()
        {
            return CadastrarMoradorCommandFactoy();
        }

        public static AdicionarMoradorCommand CriarComandoCadastroDeMoradorPeloApp()
        {
            var comando = CadastrarMoradorCommandFactoy();

            comando.DesmarcarComoCriadoPelaAdministracao();

            return comando;
        }

        public static MarcarComoUnidadePrincipalCommand CriarComandoMarcarComoUnidadePrincipal()
        {
            return new MarcarComoUnidadePrincipalCommand(Guid.NewGuid());
        }

        public static MarcarComoProprietarioCommand CriarComandoMarcarComoProprietario()
        {
            return new MarcarComoProprietarioCommand(Guid.NewGuid());
        }

        public static DesmarcarComoProprietarioCommand CriarComandoDesmarcarComoProprietario()
        {
            return new DesmarcarComoProprietarioCommand(Guid.NewGuid());
        }

    }
}