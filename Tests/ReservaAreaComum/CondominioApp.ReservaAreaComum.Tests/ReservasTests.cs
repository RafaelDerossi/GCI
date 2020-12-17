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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomatica();
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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomatica();
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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile08_12();

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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile13_17();

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
            var Areacomum = AreaComumFactory.CriarAreaComumAprovacaoDeAdministracao();
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
            var Areacomum = AreaComumFactory.CriarAreaComumAprovacaoDeAdministracao();
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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomatica();
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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomatica();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetHoraInicioEHoraFim("08:00", "12:00");
            reserva2.SetHoraInicioEHoraFim("10:00", "14:00");

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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomaticaPermitirReservaSobreposta();
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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomaticaPermitirReservaSobreposta();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            var reserva3 = ReservaFactory.CriarReservaValidaMobile();
            var reserva4 = ReservaFactory.CriarReservaValidaMobile();

            areacomum.SetNumeroLimiteDeReservaSobreposta(3);

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
            var areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomaticaPermitirReservaSobreposta();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            var reserva3 = ReservaFactory.CriarReservaValidaMobile();

            areacomum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(2);

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
            var Areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomaticaPermitirReservaSobrepostaMeioPeriodo();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile08_12();
            var reserva2 = ReservaFactory.CriarReservaValidaMobile08_12();
            var reserva3 = ReservaFactory.CriarReservaValidaMobile13_17();

            Areacomum.AdicionarReserva(reserva1);
            Areacomum.AdicionarReserva(reserva2);

            //act
            var result = Areacomum.AdicionarReserva(reserva3);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Criar Reserva inválida - Antecedencia mínima de um dia pra reservar")]
        [Trait("Categoria", "Bloquear Reserva - Antecedencia mínima de um dia pra reservar")]
        public void Bloquear_Antecedencia_Minima_UmDia()
        {
            //Arrange
            var Areacomum = AreaComumFactory.CriarAreaComumAprovacaoAutomaticaAntecedenciaMinima1Dia();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.Date);

            //act
            var result = Areacomum.AdicionarReserva(reserva1);

            //assert
            Assert.False(result.IsValid);
        }





        //[Fact(DisplayName = "Reserva válida ")]
        //[Trait("Categoria", "Reservas - reserva válida")]
        //public void Criar_reserva_deveEstar_Valido()
        //{
        //    //Arrange
        //    var reserva = new Reserva("Teste", new DateTime(2020, 12, 31), "08:00", "17:00", true, "Sistema Web", 10, 2,
        //        20, 150);

        //    //assert
        //    Assert.True(reserva != null);
        //}


        //[Fact(DisplayName = "Reserva horário invalido")]
        //[Trait("Categoria", "Reservas - reserva horario Inválido")]
        //public void Criar_reserva_horario_Invalido()
        //{
        //    var ex = Assert.Throws<Exception>(() => new Reserva("Teste", new DateTime(2020, 12, 31), "12:00", "09:00", true, "Sistema Web", 10, 2,
        //        20, 150)).Message;

        //   Assert.True(ex == "Hora inicial deve ser menor que a hora final");
        //}

        //[Fact(DisplayName = "Reserva sem horario definido")]
        //[Trait("Categoria", "Reservas - Sem horario definido")]
        //public void Criar_reserva_sem_horario_Definido()
        //{
        //    var ex = Assert.Throws<Exception>(() => new Reserva("Teste", new DateTime(2020, 12, 31), "", "", true, "Sistema Web", 10, 2,
        //        20, 150)).Message;

        //    Assert.True(ex == "É necessário informar Hora de Início e Fim da reserva");
        //}

        //[Fact(DisplayName = "Reserva data de realização inválida Mobile")]
        //[Trait("Categoria", "Reservas - data de realização inválida Mobile")]
        //public void Criar_reserva_com_data_RealizacaoInValidaMobile()
        //{
        //    var ex = Assert.Throws<Exception>(() => new Reserva("Teste", new DateTime(2020, 04, 30), 
        //        "08:00", "12:00", true, "Mobile", 10, 2,
        //        20, 150)).Message;

        //    Assert.True(ex == "A data de realização da reserva deve ser maior ou igual a de hoje");
        //}

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
