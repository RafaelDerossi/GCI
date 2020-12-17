using CondominioApp.ReservaAreaComum.Domain;
using System;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public static class ReservaFactory
    {
        public static Reserva Factory()
        {
            return new Reserva
                (Guid.NewGuid(),"Obs",Guid.NewGuid(),"101","1º","Bloco 1",Guid.NewGuid(), "Usuario", 
                 DateTime.Now.AddDays(30).Date, "08:00", "17:00", 150, false, "Mobile", false);
        }

        public static Reserva CriarReservaValidaWeb()
        {
            var reserva = Factory();
            reserva.SetOrigem("Sistema Web");
            return reserva;
        }

        public static Reserva CriarReservaValidaMobile()
        {
            var reserva = Factory();
            reserva.SetOrigem("Mobile");
            return reserva;
        }

        public static Reserva CriarReservaValidaMobile08_12()
        {
            var reserva = Factory();
            reserva.SetOrigem("Mobile");
            reserva.SetHoraInicioEHoraFim("08:00","12:00");
            return reserva;
            
        }

        public static Reserva CriarReservaValidaMobile13_17()
        {
            var reserva = Factory();
            reserva.SetOrigem("Mobile");
            reserva.SetHoraInicioEHoraFim("13:00", "17:00");
            return reserva;
        }

        public static Reserva CriarReservaRetroativaWeb()
        {
            var reserva = Factory();
            reserva.SetOrigem("Sistema Web");
            reserva.SetHoraInicioEHoraFim("08:00", "17:00");
            reserva.SetDataDeRealizacao(DateTime.Now.AddDays(-30).Date);
            return reserva;
        }

        public static Reserva CriarReservaRetroativaMobile()
        {
            var reserva = Factory();
            reserva.SetOrigem("Mobile");
            reserva.SetHoraInicioEHoraFim("08:00", "17:00");
            reserva.SetDataDeRealizacao(DateTime.Now.AddDays(-30).Date);
            return reserva;
        }
    }
}