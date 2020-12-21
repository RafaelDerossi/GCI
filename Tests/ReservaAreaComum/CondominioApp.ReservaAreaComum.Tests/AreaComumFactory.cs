

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
                           false, "", true, "", 1, false, 0, 0);
        }

        public static AreaComum CriarAreaComum_AprovacaoDeAdministracao()
        {
            var areaComum = Factory();

            areaComum.HabilitarAprovacaoDeReserva();

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

      
        public static AreaComum CriarAreaComum_AprovacaoAutomatica()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta()
        {
            var areaComum = Factory();


            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarReservaSobreposta();

            areaComum.SetNumeroLimiteDeReservaSobreposta(3);

            areaComum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(2);


            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta_2HorariosFixos()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarReservaSobreposta();

            areaComum.SetNumeroLimiteDeReservaSobreposta(3);

            areaComum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(2);

            areaComum.HabilitarHorariosEspecifcos();

            areaComum.AdicionarPeriodo(new Periodo("08:00", "12:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("13:00", "18:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta_MeioPeriodo()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarReservaSobreposta();

            areaComum.SetNumeroLimiteDeReservaSobreposta(3);

            areaComum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(2);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "12:00", Guid.Empty, 155, true));           

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_ApenasSabados()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetDiasPermitidos("SATURDAY");

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima1Mes()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetAntecedenciaMaximaEmMeses(1);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima5Dias()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetAntecedenciaMaximaEmDias(5);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_AntecedenciaMinima1Dia()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetAntecedenciaMinimaEmDias(1);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_AntecedenciaMinimaParaCancelamento1Dia()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetAntecedenciaMinimaParaCancelamentoEmDias(1);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_BloqueadaPor15Dias()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetDataInicioBloqueio(DateTime.Today.AddDays(-7));

            areaComum.SetDataFimBloqueio(DateTime.Today.AddDays(7));

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_LimiteDe2ReservasPorUnidade()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();          

            areaComum.SetNumeroLimiteDeReservaPorUnidade(2);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_LimiteDe3ReservasSobrepostas()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarReservaSobreposta();            

            areaComum.SetNumeroLimiteDeReservaSobreposta(3);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_LimiteDe3ReservasSobrepostas_E_2PorUnidade()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarReservaSobreposta();

            areaComum.SetNumeroLimiteDeReservaSobreposta(3);

            areaComum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(2);

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_HorarioFixo()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.HabilitarHorariosEspecifcos();

            areaComum.AdicionarPeriodo(new Periodo("08:00", "09:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("09:00", "10:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("10:00", "11:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("11:00", "12:00", Guid.Empty, 155, true));

            areaComum.AdicionarPeriodo(new Periodo("13:00", "14:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("14:00", "15:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("15:00", "16:00", Guid.Empty, 155, true));
            areaComum.AdicionarPeriodo(new Periodo("16:00", "17:00", Guid.Empty, 155, true));


            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_Pernoite_1700_0200()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();           

            areaComum.AdicionarPeriodo(new Periodo("17:00", "02:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_IntervaloFixo_0030()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetTempoDeIntervaloEntreReservas("00:30");

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }

        public static AreaComum CriarAreaComum_AprovacaoAutomatica_Duracao_0100()
        {
            var areaComum = Factory();

            areaComum.DesabilitarAprovacaoDeReserva();

            areaComum.SetTempoDeDuracaoDeReserva("01:00");

            areaComum.AdicionarPeriodo(new Periodo("08:00", "17:00", Guid.Empty, 155, true));

            return areaComum;
        }
    }
}