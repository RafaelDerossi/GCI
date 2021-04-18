using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy
{
   public class RegrasDeReservaFactory
    {
        public static IRegrasDeReserva CriaRegrasDeReserva(Reserva reserva, AreaComum areaComum)
        {
            IRegrasDeReservaEspecificas regrasEspecificas;            
            if (reserva.CriadaPelaAdministracao)
                regrasEspecificas = new RegrasDeAdministradorParaReservar(reserva);
            else
                regrasEspecificas = new RegrasDeClienteParaReservar(reserva, areaComum);


            IRegrasDeReservaGlobais regrasGlobais;
            if (areaComum.PermiteReservaSobreposta && areaComum.TemHorariosEspecificos)
                regrasGlobais = new RegrasGlobaisParaReservar(reserva, areaComum, new RegraParaReservaComSobreposicao(areaComum, reserva));
            else
                regrasGlobais = new RegrasGlobaisParaReservar(reserva, areaComum, new RegrasParaReservaSemSobreposicao(reserva, areaComum));


            return new RegrasDeReserva(regrasEspecificas, regrasGlobais);

        }       

    }
}
