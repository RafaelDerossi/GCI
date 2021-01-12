using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class ReservaCommandFactory
    {

        public static CadastrarReservaCommand CadastrarReservaCommandFactory()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }


        
        /// CadastrarReservaCommand
        public static CadastrarReservaCommand CriarComandoCadastroDeReserva()
        {
            return CadastrarReservaCommandFactory();
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemAreaComumId()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetAreaComumId(Guid.Empty);

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemUnidadeId()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetUnidadeId(Guid.Empty);

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemNumeroDaUnidade()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetNumeroUnidade("");

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemAndarDaUnidade()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetAndarUnidade("");

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemGrupoDaUnidade()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetGrupoUnidade("");

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemUsuarioId()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetUsuarioId(Guid.Empty);

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemNomeDoUsuario()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetNomeUsuario("");

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemHoraInicio()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetHoraInicio("");

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaComHoraInicioInvalido()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetHoraInicio("30:00");

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemHoraFim()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetHoraFim("");

            return comando;
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaComHoraFimInvalido()
        {
            var comando = CadastrarReservaCommandFactory();

            comando.SetHoraFim("30:00");

            return comando;
        }

    }

}
