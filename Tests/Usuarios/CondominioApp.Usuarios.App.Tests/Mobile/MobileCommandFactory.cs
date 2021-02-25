using System;
using CondominioApp.Usuarios.App.Aplication.Commands;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MobileCommandFactory
    {
        public static CadastrarMobileCommand CadastrarMobileCommandFactory()
        {
            return new CadastrarMobileCommand
                ("ff94bc73-114f-4470-a0bb-e2864815bbdc", "0b2eb4f89990b6e3", "SM-A307GT (10)", "Android", "10", Guid.NewGuid());
        }

        public static CadastrarMobileCommand CriarComandoCadastroDeMobile()
        {
            return CadastrarMobileCommandFactory();
        }

        public static CadastrarMobileCommand CriarComandoCadastroDeMobile_SemDeviceKey()
        {
            var comando = CadastrarMobileCommandFactory();
            comando.SetDeviceKey("");

            return comando;
        }

       
    }
}