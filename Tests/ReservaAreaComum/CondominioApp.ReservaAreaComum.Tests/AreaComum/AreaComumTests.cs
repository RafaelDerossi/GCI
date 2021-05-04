using System;
using Xunit;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class AreaComumTests
    {
        [Fact(DisplayName = "Criar Area Comum Aprovacao de Administracao")]       
        public void Criar_AreaComum_AprovacaoDeAdministracao()
        {
            //act
            AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
           
        }

        [Fact(DisplayName = "Criar Area Comum Aprovacao Automatica")]
        public void Criar_AreaComum_AprovacaoAutomatica()
        {
            //act
           AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

        }

        [Fact(DisplayName = "Criar Area Comum Aprovacao Automatica Permitir Reserva Sobreposta")]
        public void Criar_AreaComum_AprovacaoAutomatica_PermitirReservaSobreposta()
        {
            //act
           AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta();

        }

        [Fact(DisplayName = "Criar Area Comum Aprovacao Automatica Permitir Reserva Sobreposta Meio Periodo")]
        public void Criar_AreaComum_AprovacaoAutomatica_Permitir_Reserva_Sobreposta_MeioPeriodo()
        {
            //act
           AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta_2HorariosFixos();

        }

        [Fact(DisplayName = "Criar Area Comum Apenas Sabados")]
        public void Criar_AreaComum_Apenas_Sabado()
        {
            //act
            AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_ApenasSabados();

        }

        [Fact(DisplayName = "Criar Area Comum Aprovação Automática Antecedencia Maxima de 1 Mês")]
        public void Criar_AreaComum_AprovacaoAutomatica_AntecedenciaMaxima_1Mes()
        {
            //act
            AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima1Mes();

        }

        [Fact(DisplayName = "Criar Area Comum Aprovação Automática Antecedencia Maxima de 5 dias")]
        public void Criar_AreaComum_AprovacaoAutomatica_AntecedenciaMaxima_5Dias()
        {
            //act
            AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima5Dias();

        }

        [Fact(DisplayName = "Criar Area Comum Aprovação Automática Antecedencia Minima de 1 dia")]
        public void Criar_AreaComum_AprovacaoAutomatica_AntecedenciaMinima_1Dia()
        {
            //act
            AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMinima1Dia();

        }
    }
}