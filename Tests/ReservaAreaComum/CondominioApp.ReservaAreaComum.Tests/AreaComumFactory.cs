

using CondominioApp.ReservaAreaComum.Domain;
using System;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public static class AreaComumFactory
    {
        private static AreaComum Factory()
        {
           return new AreaComum("Area comum Teste", "Descrição", "", Guid.NewGuid(), "Nome do Condominio",
                           150, "|SUNDAY|MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY", 0, 0, 0, 0, false,
                           true, "", true, "", 1, false, 0, 0);
        }

        public static AreaComum CriarAreaComumAprovacaoDeAdministracao()
        {
            var areaComum = Factory();

            areaComum.HabilitarAprovacaoDeReserva();

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComumAprovacaoAutomatica()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComumAprovacaoAutomaticaPermitirReservaSobreposta()
        {
            var areaComum = Factory();


            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarReservaSobreposta();

            areaComum.SetNumeroLimiteDeReservaSobreposta(3);

            areaComum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(2);


            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComumAprovacaoAutomaticaPermitirReservaSobrepostaMeioPeriodo()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarReservaSobreposta();

            areaComum.SetNumeroLimiteDeReservaSobreposta(3);

            areaComum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(2);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "12:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("13:00", "18:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComumApenasSabado()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetDiasPermitidos("SATURDAY");

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComumAprovacaoAutomaticaAntecedenciaMaxima1Mes()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetAntecedenciaMaximaEmMeses(1);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComumAprovacaoAutomaticaAntecedenciaMaxima5Dias()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetAntecedenciaMaximaEmDias(5);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComumAprovacaoAutomaticaAntecedenciaMinima1Dia()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetAntecedenciaMinimaEmDias(1);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }
    }
}