using System;
using Xunit;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class ReservasTests
    {
        [Fact(DisplayName = "Criar Reserva Valida - Web")]
        [Trait("Categoria", "Reservas - Reserva Valida WEB")]
        public void Criar_Reserva_Valida_Web()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaWeb();

            //act
            var resultado = areacomum.AdicionarReserva(reserva);

            //assert
            Assert.True(resultado.IsValid);
        }

        [Fact(DisplayName = "Criar Reserva Valida - Mobile")]
        [Trait("Categoria", "Reservas - Reserva Valida Mobile")]
        public void Criar_Reserva_Valida_Mobile()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile();

            //act
            var resultado = areacomum.AdicionarReserva(reserva);

            //assert
            Assert.True(resultado.IsValid);
        }

        [Fact(DisplayName = "Criar Reserva Valida - Mobile 08:00--12:00")]
        [Trait("Categoria", "Reservas - Reserva Valida Mobile 08:00--12:00")]
        public void Criar_Reserva_Valida_Mobile_08_12()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile0800_1200();

            //act
            var resultado = areacomum.AdicionarReserva(reserva);

            //assert
            Assert.True(resultado.IsValid);
        }

        [Fact(DisplayName = "Criar Reserva Valida - Mobile 13:00--17:00")]
        [Trait("Categoria", "Reservas - Reserva Valida Mobile 13:00--17:00")]
        public void Criar_Reserva_Valida_Mobile_13_17()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile1300_1700();

            //act
            var resultado = areacomum.AdicionarReserva(reserva);

            //assert
            Assert.True(resultado.IsValid);
        }




        [Fact(DisplayName = "Criar Reserva Valida - Com data Retroativa Web")]
        [Trait("Categoria", "Reservas - Reservar com data Retroativa Web")]
        public void Reservar_com_dataRetroativa_Web()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaRetroativaWeb();

            //act
            var resultado = Areacomum.AdicionarReserva(reserva);

            //assert
            Assert.True(resultado.IsValid);
        }
        

        [Fact(DisplayName = "Criar Reserva Inválida - Com data Retroativa Mobile")]
        [Trait("Categoria", "Reservas - Reservar com data Retroativa Mobile")]
        public void Reservar_com_dataRetroativa_Mobile()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaRetroativaMobile();

            //act
            var resultado = Areacomum.AdicionarReserva(reserva);

            //assert
            Assert.False(resultado.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Inválida - Não Permitir Para o mesmo horário (Sem sobreposicao)")]
        [Trait("Categoria", "Reservas - Reservar para o mesmo horário")]
        public void Reservar_para_o_mesmoHorario()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();

            areacomum.AdicionarReserva(reserva1);

            //act
            var result = areacomum.AdicionarReserva(reserva2);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Inválida - Não Permitir Para horários conflitantes")]
        [Trait("Categoria", "Reservas - horários conflitantes")]
        public void Reservar_para_o_Horario_conflitante()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile1000_1400();

            areacomum.AdicionarReserva(reserva1);

            //act
            var result = areacomum.AdicionarReserva(reserva2);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Criar Reserva Válida - Mesma Unidade dias Diferentes Com Limite Diario (Sem sobreposicao)")]
        [Trait("Categoria", "Reservas - Mesma Unidade dias Diferentes Com Limite Diario")]
        public void Reservar_Dias_Diferentes_limite_vagas_por_unidade()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe2ReservasPorUnidade();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            var reserva3 = ReservaFactory.CriarReservaValidaMobile();           

            var unidadeId = Guid.NewGuid();

            reserva1.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(1));

            reserva2.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva2.SetDataDeRealizacao(DateTime.Today.AddDays(2));

            reserva3.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva3.SetDataDeRealizacao(DateTime.Today.AddDays(3));

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);

            //act
            var result = areacomum.AdicionarReserva(reserva3);

            //assert
            Assert.True(result.IsValid);
        }
        
        
        [Fact(DisplayName = "Criar Reserva Inválida - Bloquear Limite Diario por Unidade e Area (Sem sobreposicao)")]
        [Trait("Categoria", "Reservas - Bloquear Limite Diario por Unidade e Area")]
        public void Bloquear_Limite_Diario_por_Unidade_e_Area()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe2ReservasPorUnidade();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();            

            var unidadeId = Guid.NewGuid();
            reserva1.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(1));
            reserva2.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva2.SetDataDeRealizacao(DateTime.Today.AddDays(1));
          

            areacomum.AdicionarReserva(reserva1);          

            //act
            var result = areacomum.AdicionarReserva(reserva2);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Válida - Permitir reservas para o mesmo horario (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - permitir horários sobrepostos")]
        public void Reservar_Permitir_Horario_sobreposto()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();          

            areacomum.AdicionarReserva(reserva1);

            //act
            var result = areacomum.AdicionarReserva(reserva2);

            //assert
            Assert.True(result.IsValid); 
        }


        [Fact(DisplayName = "Criar Reserva Inválida - Bloquear limite de Reservas por horario (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - limite de vagas no mesmo horario")]
        public void Reservar_bloquear_limite_vagas_mesmo_horario()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe3ReservasSobrepostas();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            var reserva3 = ReservaFactory.CriarReservaValidaMobile();
            var reserva4 = ReservaFactory.CriarReservaValidaMobile();            

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);
            areacomum.AdicionarReserva(reserva3);

            //act
            var result = areacomum.AdicionarReserva(reserva4);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Inválida - Bloquear limite de Reservas por unidade por horario (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - limite de vagas por unidade")]
        public void Reservar_bloquear_limite_vagas_por_unidade()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe3ReservasSobrepostas_E_2PorUnidade();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            var reserva3 = ReservaFactory.CriarReservaValidaMobile();           

            var unidadeId = Guid.NewGuid();
            reserva1.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva2.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva3.SetUnidade(unidadeId, "101", "1º", "Bloco 1");

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);

            //act
            var result = areacomum.AdicionarReserva(reserva3);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Válida - Horários Diferentes para uma area (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - diferentes para uma area")]
        public void Reservar_direfentes_para_sobreposta()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta_2HorariosFixos();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            var reserva3 = ReservaFactory.CriarReservaValidaMobile1300_1700();

            Areacomum.AdicionarReserva(reserva1);
            Areacomum.AdicionarReserva(reserva2);

            //act
            var result = Areacomum.AdicionarReserva(reserva3);

            //assert
            Assert.True(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Válida - Horários e dias Diferentes para uma area (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - diferentes para uma area")]
        public void Reservar_DiasDirefentes_para_Mesma_Area_sobreposta()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_1200();

            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(2).Date);
            reserva2.SetDataDeRealizacao(DateTime.Today.AddDays(3).Date);

            Areacomum.AdicionarReserva(reserva1);           

            //act
            var result = Areacomum.AdicionarReserva(reserva2);

            //assert
            Assert.True(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Inválida - Reservar fora do periodo. (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - Reservar fora do periodo")]
        public void Reservar_Fora_do_Periodo_sobreposta()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta_MeioPeriodo();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile1300_1700();
            
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(2).Date);
            
            //act
            var result = Areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva inválida - Antecedencia máxima de 5 Dias pra reservar")]
        [Trait("Categoria", "Bloquear Reserva - Antecedencia maxima de 5 Dias pra reservar")]
        public void Bloquear_Antecedencia_Maxima_5Dias()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima5Dias();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.AddDays(6).Date);

            //act
            var result = Areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva inválida - Antecedencia máxima de um Mes pra reservar")]
        [Trait("Categoria", "Bloquear Reserva - Antecedencia maxima de um mes pra reservar")]
        public void Bloquear_Antecedencia_Maxima_UmMes()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima1Mes();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.AddDays(45).Date);

            //act
            var result = Areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva inválida - Antecedencia mínima de um dia pra reservar")]
        [Trait("Categoria", "Bloquear Reserva - Antecedencia mínima de um dia pra reservar")]
        public void Bloquear_Antecedencia_Minima_UmDia()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMinima1Dia();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.Date);

            //act
            var result = Areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva inválida - Reservar em area bloqueada")]
        [Trait("Categoria", "Bloquear Reserva - Em area bloqueada")]
        public void Bloquear_Reserva_em_Area_Bloqueada()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_BloqueadaPor15Dias();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.Date.AddDays(2));

            //act
            var result = Areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva inválida - Em Dia não permitido")]
        [Trait("Categoria", "Bloquear Reserva - Em Dia não permitido")]
        public void Bloquear_Reserva_em_dia_nao_permitido()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_ApenasSabados();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.Date.AddDays(7));

            //act
            var result = Areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Criar Reserva Válida - Pra horário Fixo")]
        [Trait("Categoria", "Reservas - Horários Fixos")]
        public void Reservar_para_o_Horario_Fixo()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_HorarioFixo();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0900_1000();           

            //act
            var result = areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Criar Reserva Válida - Pra horário livre Pernoite")]
        [Trait("Categoria", "Reservas - Horários livres")]
        public void Reservar_para_o_Horario_pernoite()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_Pernoite_1700_0200();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile1700_0200();

            //act
            var result = areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Criar Reserva Inválida - Pra horário livre Pernoite")]
        [Trait("Categoria", "Reservas - Horários livres")]
        public void Reservar_para_pernoite_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_Pernoite_1700_0200();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile1500_2300();

            //act
            var result = areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }

        //[Fact(DisplayName = "Reserva data de realização Inválida SysWeb")]
        //[Trait("Categoria", "Reservas - data de realização Inválida SysWeb")]
        //public void Criar_reserva_com_data_RealizacaoInValidaWeb()
        //{
        //    var reserva = new Reserva("Teste", new DateTime(2020, 04, 30),
        //        "08:00", "12:00", true, "Sistema Web", 10, 2,
        //        20, 150);

        //    Assert.True(reserva != null);
        //}


        //[Fact(DisplayName = "Restaurar reserva da fila")]
        //[Trait("Categoria", "Reserva - restaurar reservas da fila")]
        //public void Resturar_reservas_da_fila()
        //{
        //    //Arrange
        //    var Areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomatica();

        //    var reserva1 = ReservaFactory.CriarReservaValidaMobile();
        //    var reserva2 = ReservaFactory.CriarReservaValidaMobile();
        //    var reserva3 = ReservaFactory.CriarReservaValidaMobile();

        //    reserva2.dataDeCadastro = DateTime.Now.AddMinutes(2);
        //    reserva3.dataDeCadastro = DateTime.Now.AddMinutes(5);

        //    reserva2.setUnidadeId(526);
        //    reserva3.setUnidadeId(527);

        //    Areacomum.AdicionarReservaParaEstaArea(reserva1);
        //    Areacomum.AdicionarReservaParaFila(reserva2);
        //    Areacomum.AdicionarReservaParaFila(reserva3);

        //    //act
        //    var result = Areacomum.RetornaProximaReservaDaFila();

        //    //assert
        //    Assert.True(result.apartamentoId == 526);
        //}
    }
}
