using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MobileCommandFactory
    {
        public static RegistrarMoradorMobileCommand RegistrarMoradorMobileCommandFactory()
        {
            return new RegistrarMoradorMobileCommand
                ("ff94bc73-114f-4470-a0bb-e2864815bbdc", "0b2eb4f89990b6e3", "SM-A307GT (10)", "Android", "10", Guid.NewGuid());
        }

        public static RegistrarMoradorMobileCommand CriarComandoCadastroDeMobile()
        {
            return RegistrarMoradorMobileCommandFactory();
        }

        public static RegistrarMoradorMobileCommand CriarComandoCadastroDeMobile_SemDeviceKey()
        {
            var comando = RegistrarMoradorMobileCommandFactory();
            comando.SetDeviceKey("");

            return comando;
        }

        public static RegistrarMoradorMobileCommand CriarComandoCadastroDeMobile_SemMobileId()
        {
            var comando = RegistrarMoradorMobileCommandFactory();
            comando.SetMobileId("");

            return comando;
        }

        public static RegistrarMoradorMobileCommand CriarComandoCadastroDeMobile_SemUsuarioId()
        {
            var comando = RegistrarMoradorMobileCommandFactory();
            comando.SetUsuarioId(Guid.Empty);

            return comando;
        }
    }
}