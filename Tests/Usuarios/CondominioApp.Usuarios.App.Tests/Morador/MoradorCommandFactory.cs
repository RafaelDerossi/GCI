using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MoradorCommandFactory
    {
        public static CadastrarMoradorCommand CadastrarMoradorCommandFactoy()
        {
            return new CadastrarMoradorCommand
                (Guid.NewGuid(), Guid.NewGuid(), "NomeCondominio", Guid.NewGuid(),
                "101", "1", "Bloco A", true, true);
        }

        public static CadastrarMoradorCommand CriarComandoCadastroDeMorador()
        {
            return CadastrarMoradorCommandFactoy();
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