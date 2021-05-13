using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class AreaComumCommandFactory
    {
        public static AdicionarAreaComumCommand CadastrarAreaComumCommandFactory()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var comando = new AdicionarAreaComumCommand
                ("Area Comum", "Descricao da area comum", "Termo de Uso", Guid.NewGuid(),
                "Nome do condominio", 10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "",
                true, "", 0, false, 0, 0, "", listaPeriodos);

            return comando;
        }
        public static AtualizarAreaComumCommand EditarAreaComumCommandFactory()
        {
            var listaPeriodos = new List<Periodo>();

            var periodo = new Periodo("08:00", "12:00", 150, true);
            listaPeriodos.Add(periodo);
            periodo = new Periodo("13:00", "17:00", 150, true);
            listaPeriodos.Add(periodo);

            var comando = new AtualizarAreaComumCommand
                (Guid.NewGuid(), "Area Comum", "Descricao da area comum", "Termo de Uso",
                10, "SATURDAY|SUNDAY", 0, 0, 0, 0, false, true, "", "", 0, false, 0, 0,
                "", listaPeriodos);

            return comando;
        }


        
        /// CadastrarAreaComumCommand        
        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum()
        {
            return CadastrarAreaComumCommandFactory();
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_SemNome()
        {

            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNome("");

            return comando;

        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_SemCondominioId()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetCondominioId(Guid.Empty);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_SemNomeDoCondominio()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNomeCondominio("");

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_SemDiasPermitidos()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetDiasPermitidos("");

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmMesesInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMaximaEmMeses(-1);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMaximaEmDiasInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMaximaEmDias(-1);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMinimaInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMinimaEmDias(-1);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetAntecedenciaMinimaParaCancelamentoEmDias(-1);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaPorUnidadeInvalido()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaPorUnidade(-1);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalido()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaSobreposta(-1);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalido()
        {
            var comando = CadastrarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaSobrepostaPorUnidade(-1);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoPernoite()
        {
            var periodo = new Periodo("17:00", "02:00", 150, true);              

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoSemHoraInicio()
        {
            var periodo = new Periodo("", "12:00", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoComHoraInicioInvalido()
        {
            var periodo = new Periodo("30:00", "12:00", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoSemHoraFim()
        {
            var periodo = new Periodo("08:00", "", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodoComHoraFimInvalido()
        {
            var periodo = new Periodo("08:00", "30:00", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosConflitantesInvalido()
        {
            var periodo1 = new Periodo("07:00", "14:00", 150, true);
            var periodo2 = new Periodo("13:00", "18:00", 150, true);           

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo1);
            comando.AdicionarPeriodo(periodo2);

            return comando;

        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosInvertidosConflitantesInvalido()
        {
            var periodo1 = new Periodo("13:00", "18:00", 150, true);
            var periodo2 = new Periodo("07:00", "14:00", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo1);
            comando.AdicionarPeriodo(periodo2);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosPernoiteConflitantesInvalido()
        {
            var periodo1 = new Periodo("18:00", "02:00", 150, true);
            var periodo2 = new Periodo("15:00", "20:00", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo1);
            comando.AdicionarPeriodo(periodo2);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosValido()
        {
            var periodo1 = new Periodo("13:00", "18:00", 150, true);
            var periodo2 = new Periodo("07:00", "12:00", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo1);
            comando.AdicionarPeriodo(periodo2);

            return comando;
        }

        public static AdicionarAreaComumCommand CriarComandoCadastroDeAreaComum_PeriodosPernoiteValido()
        {
            var periodo1 = new Periodo("20:00", "02:00", 150, true);
            var periodo2 = new Periodo("07:00", "18:00", 150, true);

            var comando = CadastrarAreaComumCommandFactory();

            comando.LimparPeriodos();

            comando.AdicionarPeriodo(periodo1);
            comando.AdicionarPeriodo(periodo2);

            return comando;
        }





        
        /// EditarAreaComumCommand        
        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum()
        {
            var comando = EditarAreaComumCommandFactory();
            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_SemNome()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetNome("");
           
            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_SemDiasPermitidos()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetDiasPermitidos("");

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMaximaEmMesesInvalida()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetAntecedenciaMaximaEmMeses(-1);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMaximaEmDiasInvalida()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetAntecedenciaMaximaEmDias(-1);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMinimaInvalida()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetAntecedenciaMinimaEmDias(-1);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_AntecedenciaMinimaParaCancelamentoInvalida()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetAntecedenciaMinimaParaCancelamentoEmDias(-1);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_NumeroLimiteDeReservaInvalida()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaPorUnidade(-1);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_NumeroLimiteDeReservaSobrepostaInvalida()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaSobreposta(-1);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_NumeroLimiteDeReservaSobrepostaPorUnidadeInvalida()
        {
            var comando = EditarAreaComumCommandFactory();

            comando.SetNumeroLimiteDeReservaSobrepostaPorUnidade(-1);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoPernoite()
        {
            var periodo = new Periodo("17:00", "02:00", 150, true);
            
            var comando = EditarAreaComumCommandFactory();

            comando.LimparPeriodos();
            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoSemHoraInicio()
        {
            var periodo = new Periodo("", "17:00", 150, true);          

            var comando = EditarAreaComumCommandFactory();

            comando.LimparPeriodos();
            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoComHoraInicioInvalida()
        {
            var periodo = new Periodo("30:00", "17:00", 150, true);

            var comando = EditarAreaComumCommandFactory();

            comando.LimparPeriodos();
            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoSemHoraFim()
        {
            var periodo = new Periodo("08:00", "", 150, true);

            var comando = EditarAreaComumCommandFactory();

            comando.LimparPeriodos();
            comando.AdicionarPeriodo(periodo);

            return comando;
        }

        public static AtualizarAreaComumCommand CriarComandoEdicaoDeAreaComum_PeriodoComHoraFimInvalida()
        {
            var periodo = new Periodo("08:00", "30:00", 150, true);

            var comando = EditarAreaComumCommandFactory();

            comando.LimparPeriodos();
            comando.AdicionarPeriodo(periodo);

            return comando;
        }


       
        /// AtivarAreaComumCommand        
        public static AtivarAreaComumCommand CriarComandoAtivacaoDeAreaComum()
        {
            var areaComum = new AtivarAreaComumCommand
                (Guid.NewGuid());

            return areaComum;
        }

       
        /// DesativarAreaComumCommand       
        public static DesativarAreaComumCommand CriarComandoDesativacaoDeAreaComum()
        {
            var areaComum = new DesativarAreaComumCommand
                (Guid.NewGuid());

            return areaComum;
        }
    }

}
