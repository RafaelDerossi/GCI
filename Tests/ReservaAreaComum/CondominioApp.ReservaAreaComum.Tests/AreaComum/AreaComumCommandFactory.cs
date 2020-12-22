using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class AreaComumCommandFactory
    {
      
        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemNome()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;

        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemCondominioId()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.Empty,
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemNomeDoCondominio()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemDiasPermitidos()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmMesesInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", -1, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmDiasInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, -1, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMinimaInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, -1, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, -1, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaPorUnidadeInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", -1, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, -1, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, -1, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoPernoite()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("17:00", "02:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoSemHoraInicio()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("", "12:00", 150, true);
            listaPeriodos.Add(periodo);
           
            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, -1, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoComHoraInicioInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("30:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, -1, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoSemHoraFim()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, -1, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoComHoraFimInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "30:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, -1, listaPeriodos);

            return areaComum;
        }



        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_SemNome()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_SemDiasPermitidos()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMaximaEmMesesInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", -1, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMaximaEmDiasInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, -1, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMinimaInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, -1, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, -1, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_NumeroLimiteDeReservaInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", -1, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, -1, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, -1, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoPernoite()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("17:00", "02:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoSemHoraInicio()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoComHoraInicioInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("30:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoSemHoraFim()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static EditarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoComHoraFimInvalida()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "30:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new EditarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static AtivarAreaComumCommand CriarComandoAtivacaoDeAreaComum()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new AtivarAreaComumCommand
                (Guid.NewGuid());

            return areaComum;
        }

        public static DesativarAreaComumCommand CriarComandoDesativacaoDeAreaComum()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var areaComum = new DesativarAreaComumCommand
                (Guid.NewGuid());

            return areaComum;
        }
    }

}
