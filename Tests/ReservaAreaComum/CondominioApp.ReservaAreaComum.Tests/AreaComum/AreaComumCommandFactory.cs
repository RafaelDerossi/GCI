using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class AreaComumCommandFactory
    {
        public static CadastrarAreaComumCommand CadastrarAreaComumCommandFactory()
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

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum()
        {
            return CadastrarAreaComumCommandFactory();
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemNome()
        {

            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNome("");

            return comando;

        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemCondominioId()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetCondominioId(Guid.Empty);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemNomeDoCondominio()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNomeCondominio("");

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_SemDiasPermitidos()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetDiasPermitidos("");

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmMesesInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMaximaEmMeses(-1);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmDiasInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMaximaEmDias(-1);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMinimaInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMinimaEmDias(-1);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMinimaParaCancelamentoEmDias(-1);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaPorUnidadeInvalido()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaPorUnidade(-1);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalido()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaSobreposta(-1);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalido()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaSobrepostaPorUnidade(-1);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoPernoite()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("17:00", "02:00", 150, true);
            listaPeriodos.Add(periodo);          

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.SetPeriodos(listaPeriodos);

            return comando;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoSemHoraInicio()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("", "12:00", 150, true);
            listaPeriodos.Add(periodo);
           
            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

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
                true, "", 0, false, 0, 0, listaPeriodos);

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
                true, "", 0, false, 0, 0, listaPeriodos);

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
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosConflitantesInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo1 = new Periodo("07:00", "14:00", 150, true);
            listaPeriodos.Add(periodo1);

            var periodo2 = new Periodo("13:00", "18:00", 150, true);
            listaPeriodos.Add(periodo2);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosInvertidosConflitantesInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo1 = new Periodo("13:00", "18:00", 150, true);
            listaPeriodos.Add(periodo1);

            var periodo2 = new Periodo("07:00", "14:00", 150, true);
            listaPeriodos.Add(periodo2);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosPernoiteConflitantesInvalido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo1 = new Periodo("18:00", "02:00", 150, true);
            listaPeriodos.Add(periodo1);

            var periodo2 = new Periodo("15:00", "20:00", 150, true);
            listaPeriodos.Add(periodo2);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosValido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo1 = new Periodo("13:00", "18:00", 150, true);
            listaPeriodos.Add(periodo1);

            var periodo2 = new Periodo("07:00", "12:00", 150, true);
            listaPeriodos.Add(periodo2);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

            return areaComum;
        }

        public static CadastrarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosPernoiteValido()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo1 = new Periodo("20:00", "02:00", 150, true);
            listaPeriodos.Add(periodo1);

            var periodo2 = new Periodo("07:00", "18:00", 150, true);
            listaPeriodos.Add(periodo2);

            var areaComum = new CadastrarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, listaPeriodos);

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
