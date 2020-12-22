using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class ReservaCommandFactory
    {
      
        public static CadastrarReservaCommand CriarComandoCadastroDeReserva()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario",DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false); 
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemAreaComumId()
        {
            return new CadastrarReservaCommand
                (Guid.Empty, "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemUnidadeId()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.Empty, "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemNumeroDaUnidade()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemAndarDaUnidade()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemDescricaoDoGrupo()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemUsuarioId()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.Empty, "Usuario", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemNomeDoUsuario()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "", DateTime.Now.Date, "08:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemHoraInicio()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaComHoraInicioInvalido()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "30:00", "09:00",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaSemHoraFim()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "",
                150, false, "Mobile", false);
        }

        public static CadastrarReservaCommand CriarComandoCadastroDeReservaComHoraFimInvalido()
        {
            return new CadastrarReservaCommand
                (Guid.NewGuid(), "Observacao", Guid.NewGuid(), "101", "1º",
                "Bloco 1", Guid.NewGuid(), "Usuario", DateTime.Now.Date, "08:00", "30:00",
                150, false, "Mobile", false);
        }

    }

}
