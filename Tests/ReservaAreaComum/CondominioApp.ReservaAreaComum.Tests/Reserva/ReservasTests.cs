using System;
using Xunit;
using Moq;
using Moq.AutoMock;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasGerais;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasParaAdministrador;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.RegrasParaMorador;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.RegrasParaAdministracao;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.RegrasParaCancelamento.Regras.Interfaces;

namespace CondominioApp.ReservaAreaComum.Tests
{
    public class ReservasTests
    {
        private readonly AutoMocker _mocker;
        private readonly RegrasDeReserva _regrasDeReserva;
        private readonly RegrasDeCriacaoDeReserva _regrasDeCriacao;
        
        private readonly RegrasGeraisParaReservar _regrasGerais;
        private readonly RegraIntervalosFixos _regraIntervalosFixos;
        private readonly RegraDuracaoLimite _regraDuracaoLimite;
        private readonly RegraHorarioDisponivelSemSobreposicao _regraSemSobreposicao;
        private readonly RegraHorarioDisponivelComSobreposicao _regraComSobreposicao;

        private readonly RegrasDeAdministradorParaReservar _regrasDeAdministradorParaReservar;
        private readonly RegraDataRetroativaPermitida _regraDaDataRetroativaPermitida;

        private readonly RegrasDeMoradorParaReservar _regrasDeMoradorParaReservar;
        private readonly RegraIntervaloParaMesmaUnidade _regraIntervaloParaMesmaUnidade;
        private readonly RegraDataRetroativaNaoPermitida _regraDataRetroativaNaoPermitida;
        private readonly RegraBloqueioDaAreaComum _regraBloqueioDaAreaComum;
        private readonly RegraAntecedenciaMaxima _regraAntecedenciaMaxima;
        private readonly RegraAntecedenciaMinima _regraAntecedenciaMinima;
        private readonly RegraDiasPermitidos _regraDiasPermitidos;
        private readonly RegraLimitePorUnidadePorDia _regraLimitePorUnidadePorDia;
        private readonly RegraHorarioDentroDosLimites _regraHorarioDentroDosLimites;


        private readonly RegrasDeCancelamentoDeReserva _regrasDeCancelamentoDeReserva;
        private readonly RegrasDeCancelamentoDeReservaPeloMorador _regrasDeCancelamentoDeReservaPeloMorador;
        private readonly RegrasDeCancelamentoDeReservaPelaAdministracao _regrasDeCancelamentoDeReservaPelaAdministracao;
        private readonly RegraDoPrazoMinimoPraCancelar _regraDoPrazoMinimoPraCancelar;
        private readonly RegraDoStatusPraCancelar _regraDoStatusPraCancelar;

        public ReservasTests()
        {
            _mocker = new AutoMocker();
            _regrasDeReserva = _mocker.CreateInstance<RegrasDeReserva>();
            _regrasDeCriacao = _mocker.CreateInstance<RegrasDeCriacaoDeReserva>();
            _regrasGerais = _mocker.CreateInstance<RegrasGeraisParaReservar>();

            _regraIntervalosFixos = _mocker.CreateInstance<RegraIntervalosFixos>();
            _regraDuracaoLimite = _mocker.CreateInstance<RegraDuracaoLimite>();
            _regraSemSobreposicao = _mocker.CreateInstance<RegraHorarioDisponivelSemSobreposicao>();
            _regraComSobreposicao = _mocker.CreateInstance<RegraHorarioDisponivelComSobreposicao>();

            _regrasDeAdministradorParaReservar = _mocker.CreateInstance<RegrasDeAdministradorParaReservar>();
            _regraDaDataRetroativaPermitida = _mocker.CreateInstance<RegraDataRetroativaPermitida>();


            _regrasDeMoradorParaReservar = _mocker.CreateInstance<RegrasDeMoradorParaReservar>();
            _regraIntervaloParaMesmaUnidade = _mocker.CreateInstance<RegraIntervaloParaMesmaUnidade>();
            _regraDataRetroativaNaoPermitida = _mocker.CreateInstance<RegraDataRetroativaNaoPermitida>();
            _regraBloqueioDaAreaComum = _mocker.CreateInstance<RegraBloqueioDaAreaComum>();
            _regraAntecedenciaMaxima = _mocker.CreateInstance<RegraAntecedenciaMaxima>();
            _regraAntecedenciaMinima = _mocker.CreateInstance<RegraAntecedenciaMinima>();
            _regraDiasPermitidos = _mocker.CreateInstance<RegraDiasPermitidos>();
            _regraLimitePorUnidadePorDia = _mocker.CreateInstance<RegraLimitePorUnidadePorDia>();
            _regraHorarioDentroDosLimites = _mocker.CreateInstance<RegraHorarioDentroDosLimites>();


            _regrasDeCancelamentoDeReserva = _mocker.CreateInstance<RegrasDeCancelamentoDeReserva>();
            _regrasDeCancelamentoDeReservaPeloMorador = _mocker.CreateInstance<RegrasDeCancelamentoDeReservaPeloMorador>();
            _regrasDeCancelamentoDeReservaPelaAdministracao = _mocker.CreateInstance<RegrasDeCancelamentoDeReservaPelaAdministracao>();
            _regraDoPrazoMinimoPraCancelar = _mocker.CreateInstance<RegraDoPrazoMinimoPraCancelar>();
            _regraDoStatusPraCancelar = _mocker.CreateInstance<RegraDoStatusPraCancelar>();
        }

        private void SetMocksRegrasGerais(Reserva reserva, AreaComum areacomum)
        {
            var retIntervaloFixo = _regraIntervalosFixos.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraIntervalosFixos>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retIntervaloFixo);

            var retDuracaoLimite = _regraDuracaoLimite.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraDuracaoLimite>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retDuracaoLimite);

            var retSemSobreposicao = _regraSemSobreposicao.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraHorarioDisponivelSemSobreposicao>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retSemSobreposicao);

            var retComSobreposicao = _regraComSobreposicao.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraHorarioDisponivelComSobreposicao>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retComSobreposicao);

            var retRegrasGerais = _regrasGerais.Validar(reserva, areacomum);
            _mocker.GetMock<IRegrasGeraisParaReservar>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegrasGerais);

            var retVerificaReservasAprovadas = _regrasGerais.VerificaReservasAprovadas(reserva, areacomum);
            _mocker.GetMock<IRegrasGeraisParaReservar>().Setup(r => r.VerificaReservasAprovadas(reserva, areacomum))
               .Returns(retVerificaReservasAprovadas);
        }

        private void SetMocksRegrasDeAdministradorParaReservar(Reserva reserva)
        {
            var retRegraDataRetroativaPermitida = _regraDaDataRetroativaPermitida.Validar(reserva);
            _mocker.GetMock<IRegraDataRetroativaPermitida>().Setup(r => r.Validar(reserva))
               .Returns(retRegraDataRetroativaPermitida);

            var retRegrasDeAdministradorParaReservar = _regrasDeAdministradorParaReservar.Validar(reserva);
            _mocker.GetMock<IRegrasDeAdministradorParaReservar>().Setup(r => r.Validar(reserva))
               .Returns(retRegrasDeAdministradorParaReservar);
        }

        private void SetMocksRegrasDeMoradorParaReservar(Reserva reserva, AreaComum areacomum)
        {            
            var retRegraIntervaloParaMesmaUnidade = _regraIntervaloParaMesmaUnidade.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraIntervaloParaMesmaUnidade>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraIntervaloParaMesmaUnidade);

            
            var retRegraDataRetroativaNaoPermitida = _regraDataRetroativaNaoPermitida.Validar(reserva);
            _mocker.GetMock<IRegraDataRetroativaNaoPermitida>().Setup(r => r.Validar(reserva))
               .Returns(retRegraDataRetroativaNaoPermitida);

            
            var retRegraBloqueioDaAreaComum = _regraBloqueioDaAreaComum.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraBloqueioDaAreaComum>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraBloqueioDaAreaComum);

            
            var retRegraAntecedenciaMaxima = _regraAntecedenciaMaxima.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraAntecedenciaMaxima>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraAntecedenciaMaxima);

            
            var retRegraAntecedenciaMinima = _regraAntecedenciaMinima.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraAntecedenciaMinima>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraAntecedenciaMinima);

            
            var retRegraDiasPermitidos = _regraDiasPermitidos.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraDiasPermitidos>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraDiasPermitidos);

            
            var retRegraLimitePorUnidadePorDia = _regraLimitePorUnidadePorDia.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraLimitePorUnidadePorDia>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraLimitePorUnidadePorDia);

            
            var retRegraHorarioDentroDosLimites = _regraHorarioDentroDosLimites.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraHorarioDentroDosLimites>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraHorarioDentroDosLimites);

            
            var retRegrasDeMoradorParaReservar = _regrasDeMoradorParaReservar.Validar(reserva, areacomum);
            _mocker.GetMock<IRegrasDeMoradorParaReservar>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegrasDeMoradorParaReservar);
        }

        private void SetMocksRegrasDeCriacao(Reserva reserva, AreaComum areacomum)
        {
            SetMocksRegrasGerais(reserva, areacomum);

            SetMocksRegrasDeAdministradorParaReservar(reserva);

            SetMocksRegrasDeMoradorParaReservar(reserva, areacomum);            


            var retRegrasDeCriacao = _regrasDeCriacao.Validar(reserva, areacomum);
            _mocker.GetMock<IRegrasDeCriacaoDeReserva>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegrasDeCriacao);

            var retVerificaReservasAprovadas = _regrasDeCriacao.VerificaReservasAprovadas(reserva, areacomum);
            _mocker.GetMock<IRegrasDeCriacaoDeReserva>().Setup(r => r.VerificaReservasAprovadas(reserva, areacomum))
               .Returns(retVerificaReservasAprovadas);
        }

        private void SetMocksRegrasDeCancelamento(Reserva reserva, AreaComum areacomum)
        {            
            var reRegraDoStatusPraCancelar = _regraDoStatusPraCancelar.Validar(reserva);
            _mocker.GetMock<IRegraDoStatusPraCancelar>().Setup(r => r.Validar(reserva))
               .Returns(reRegraDoStatusPraCancelar);
            
            var retRegraDoPrazoMinimoPraCancelar = _regraDoPrazoMinimoPraCancelar.Validar(reserva, areacomum);
            _mocker.GetMock<IRegraDoPrazoMinimoPraCancelar>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegraDoPrazoMinimoPraCancelar);

                        
            var retRegrasDeCancelamentoDeReservaPeloMorador = _regrasDeCancelamentoDeReservaPeloMorador.Validar(reserva, areacomum);
            _mocker.GetMock<IRegrasDeCancelamentoDeReservaPeloMorador>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegrasDeCancelamentoDeReservaPeloMorador);

            
            var retRegrasDeCancelamentoDeReservaPelaAdministracao = _regrasDeCancelamentoDeReservaPelaAdministracao.Validar(reserva);
            _mocker.GetMock<IRegrasDeCancelamentoDeReservaPelaAdministracao>().Setup(r => r.Validar(reserva))
               .Returns(retRegrasDeCancelamentoDeReservaPelaAdministracao);

            
            var retRegrasDeCancelamentoDeReserva = _regrasDeCancelamentoDeReserva.ValidarCancelamentoPelaAdministracao(reserva);
            _mocker.GetMock<IRegrasDeCancelamentoDeReserva>().Setup(r => r.ValidarCancelamentoPelaAdministracao(reserva))
               .Returns(retRegrasDeCancelamentoDeReserva);

            var retRegrasDeCancelamentoDeReservaMorador = _regrasDeCancelamentoDeReserva.ValidarCancelamentoPeloMorador(reserva, areacomum);
            _mocker.GetMock<IRegrasDeCancelamentoDeReserva>().Setup(r => r.ValidarCancelamentoPeloMorador(reserva, areacomum))
               .Returns(retRegrasDeCancelamentoDeReservaMorador);

        }



        [Fact(DisplayName = "Reserva - Criar Reserva Valida - Web")]
        [Trait("Categoria", "Reservas - Reserva Valida WEB")]
        public void Criar_Reserva_Valida_Web()         
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaWeb();


            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            //var resultado = areacomum.ValidarReserva(reserva, _reagrasDeReserva);
            var resultado = _regrasDeReserva.ValidarRegrasParaCriacao(reserva, areacomum);

            //assert
            Assert.True(resultado.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Valida - Mobile")]
        [Trait("Categoria", "Reservas - Reserva Valida Mobile")]
        public void Criar_Reserva_Valida_Mobile()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile();

            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            var resultado = areacomum.ValidarReserva(reserva, _regrasDeReserva);

            //assert
            Assert.True(resultado.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Valida - Mobile 08:00--12:00")]
        [Trait("Categoria", "Reservas - Reserva Valida Mobile 08:00--12:00")]
        public void Criar_Reserva_Valida_Mobile_08_12()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile0800_1200();

            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            var resultado = areacomum.ValidarReserva(reserva, _regrasDeReserva);

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

            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            var resultado = areacomum.ValidarReserva(reserva, _regrasDeReserva);

            //assert
            Assert.True(resultado.IsValid);
        }




        [Fact(DisplayName = "Reserva - Criar Reserva Valida - Com data Retroativa - Web")]
        [Trait("Categoria", "Reservas - Reservar com data Retroativa Web")]
        public void Reservar_com_dataRetroativa_Web()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaRetroativaWeb();

            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            var resultado = areacomum.ValidarReserva(reserva, _regrasDeReserva);

            //assert
            Assert.True(resultado.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Com data Retroativa - Web")]
        [Trait("Categoria", "Reservas - Reservar com data Retroativa Web")]
        public void Reservar_com_dataRetroativa_Web_Invalida()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaRetroativaWebInvalida();

            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            var resultado = areacomum.ValidarReserva(reserva, _regrasDeReserva);

            //assert
            Assert.False(resultado.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Com data de Realizacao - Web")]
        [Trait("Categoria", "Reservas - Reservar com data de Realizacao Web")]
        public void Reservar_com_dataRealizacao_Web_Invalida()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaWebDataRealizacaoInvalida();

            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            var resultado = areacomum.ValidarReserva(reserva, _regrasDeReserva);

            //assert
            Assert.False(resultado.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Com data Retroativa Mobile")]
        [Trait("Categoria", "Reservas - Reservar com data Retroativa Mobile")]
        public void Reservar_com_dataRetroativa_Mobile()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaRetroativaMobile();

            SetMocksRegrasDeCriacao(reserva, areacomum);

            //act
            var resultado = areacomum.ValidarReserva(reserva, _regrasDeReserva);

            //assert
            Assert.False(resultado.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Não Permitir Para o mesmo horário (Sem sobreposicao)")]
        [Trait("Categoria", "Reservas - Reservar para o mesmo horário")]
        public void Reservar_para_o_mesmoHorario()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Não Permitir Para horários conflitantes")]
        [Trait("Categoria", "Reservas - horários conflitantes")]
        public void Reservar_para_o_Horario_conflitante()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile1000_1400();

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Mesma Unidade dias Diferentes Com Limite Diario (Sem sobreposicao)")]
        [Trait("Categoria", "Reservas - Mesma Unidade dias Diferentes Com Limite Diario")]
        public void Reservar_Dias_Diferentes_limite_vagas_por_unidade()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe2ReservasPorUnidade();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            reserva2.Aprovar("");
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

            SetMocksRegrasDeCriacao(reserva3, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva3, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }
        
        
        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Bloquear Limite Diario por Unidade e Area (Sem sobreposicao)")]
        [Trait("Categoria", "Reservas - Bloquear Limite Diario por Unidade e Area")]
        public void Bloquear_Limite_Diario_por_Unidade_e_Area()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe2ReservasPorUnidade();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();            

            var unidadeId = Guid.NewGuid();
            reserva1.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(1));
            reserva2.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva2.SetDataDeRealizacao(DateTime.Today.AddDays(1));
          

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Permitir reservas para o mesmo horario (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - permitir horários sobrepostos")]
        public void Reservar_Permitir_Horario_sobreposto()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_1200();          

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid); 
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Bloquear limite de Reservas por horario (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - limite de vagas no mesmo horario")]
        public void Reservar_bloquear_limite_vagas_mesmo_horario()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe3ReservasSobrepostas();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            reserva2.Aprovar("");
            var reserva3 = ReservaFactory.CriarReservaValidaMobile();
            reserva3.Aprovar("");
            var reserva4 = ReservaFactory.CriarReservaValidaMobile();            

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);
            areacomum.AdicionarReserva(reserva3);

            SetMocksRegrasDeCriacao(reserva4, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva4, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Bloquear limite de Reservas por unidade por horario (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - limite de vagas por unidade")]
        public void Reservar_bloquear_limite_vagas_por_unidade()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_LimiteDe3ReservasSobrepostas_E_2PorUnidade();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            reserva2.Aprovar("");
            var reserva3 = ReservaFactory.CriarReservaValidaMobile();           

            var unidadeId = Guid.NewGuid();
            reserva1.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva2.SetUnidade(unidadeId, "101", "1º", "Bloco 1");
            reserva3.SetUnidade(unidadeId, "101", "1º", "Bloco 1");

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);

            SetMocksRegrasDeCriacao(reserva3, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva3, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Horários Diferentes para uma area (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - diferentes para uma area")]
        public void Reservar_direfentes_para_sobreposta()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta_2HorariosFixos();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva2.Aprovar("");
            var reserva3 = ReservaFactory.CriarReservaValidaMobile1300_1700();

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);


            SetMocksRegrasDeCriacao(reserva3, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva3, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Horários e dias Diferentes para uma area (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - diferentes para uma area")]
        public void Reservar_DiasDirefentes_para_Mesma_Area_sobreposta()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_1200();

            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(2).Date);
            reserva2.SetDataDeRealizacao(DateTime.Today.AddDays(3).Date);

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Reservar fora do periodo. (Com sobreposicao)")]
        [Trait("Categoria", "Reservas - Reservar fora do periodo")]
        public void Reservar_Fora_do_Periodo_sobreposta()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_PermitirReservaSobreposta_MeioPeriodo();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile1300_1700();
            
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(2).Date);

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva inválida - Antecedencia máxima de 5 Dias pra reservar")]
        [Trait("Categoria", "Bloquear Reserva - Antecedencia maxima de 5 Dias pra reservar")]
        public void Bloquear_Antecedencia_Maxima_5Dias()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima5Dias();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.AddDays(6).Date);

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva inválida - Antecedencia máxima de um Mes pra reservar")]
        [Trait("Categoria", "Bloquear Reserva - Antecedencia maxima de um mes pra reservar")]
        public void Bloquear_Antecedencia_Maxima_UmMes()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMaxima1Mes();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.AddDays(45).Date);

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva inválida - Antecedencia mínima de um dia pra reservar")]
        [Trait("Categoria", "Bloquear Reserva - Antecedencia mínima de um dia pra reservar")]
        public void Bloquear_Antecedencia_Minima_UmDia()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMinima1Dia();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.Date);

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva inválida - Reservar em area bloqueada")]
        [Trait("Categoria", "Bloquear Reserva - Em area bloqueada")]
        public void Bloquear_Reserva_em_Area_Bloqueada()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_BloqueadaPor15Dias();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.Date.AddDays(2));

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva inválida - Em Dia não permitido")]
        [Trait("Categoria", "Bloquear Reserva - Em Dia não permitido")]
        public void Bloquear_Reserva_em_dia_nao_permitido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_ApenasSabados();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile();

            reserva1.SetDataDeRealizacao(DateTime.Now.Date.AddDays(7));

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

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

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Pra horário livre Pernoite")]
        [Trait("Categoria", "Reservas - Horários livres")]
        public void Reservar_para_o_Horario_pernoite()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_Pernoite_1700_0200();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile1700_0200();

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Pra horário livre Pernoite")]
        [Trait("Categoria", "Reservas - Horários livres")]
        public void Reservar_para_pernoite_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_Pernoite_1700_0200();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile1500_2300();

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Pra Intervalo Fixo")]
        [Trait("Categoria", "Reservas - Intervalo Fixo")]
        public void Reservar_para_o_Intervalo_Fixo()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_IntervaloFixo_0030();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_0900();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0930_1030();

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Pra Intervalo Fixo Invertido")]
        [Trait("Categoria", "Reservas - Intervalo Fixo")]
        public void Reservar_para_o_Intervalo_Fixo_Invertido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_IntervaloFixo_0030();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0930_1030();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_0900();
          

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Pra Intervalo Fixo")]
        [Trait("Categoria", "Reservas - Intervalo Fixo")]
        public void Reservar_para_o_Intervalo_Fixo_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_IntervaloFixo_0030();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0900_1000();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile1000_1400();

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Pra Intervalo Fixo Invertido")]
        [Trait("Categoria", "Reservas - Intervalo Fixo")]
        public void Reservar_para_o_Intervalo_Fixo_Invertido_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_IntervaloFixo_0030();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile1000_1400();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0900_1000();           

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Pra Intervalo Fixo com Sobreposicao")]
        [Trait("Categoria", "Reservas - Intervalo Fixo")]
        public void Reservar_para_o_Intervalo_Fixo_Sobreposicao_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_IntervaloFixo_0030_Sobreposicao();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_0900();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0930_1030();
            reserva2.Aprovar("");
            var reserva3 = ReservaFactory.CriarReservaValidaMobile0930_1030();           

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);

            SetMocksRegrasDeCriacao(reserva3, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva3, _regrasDeReserva);           

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Pra Intervalo Fixo com Sobreposicao Invertido")]
        [Trait("Categoria", "Reservas - Intervalo Fixo")]
        public void Reservar_para_o_Intervalo_Fixo_Sobreposicao_Invertido_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_IntervaloFixo_0030_Sobreposicao();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0930_1030();
            reserva1.Aprovar("");
            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_0900();
            reserva2.Aprovar("");
            var reserva3 = ReservaFactory.CriarReservaValidaMobile0800_0900();

            areacomum.AdicionarReserva(reserva1);
            areacomum.AdicionarReserva(reserva2);

            SetMocksRegrasDeCriacao(reserva3, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva3, _regrasDeReserva);           

            //assert
            Assert.False(result.IsValid);
        }



        [Fact(DisplayName = "Reserva - Criar Reserva Válida - Pra Duracao da Reserva")]
        [Trait("Categoria", "Reservas -Duracao da Rerserva")]
        public void Reservar_para_o_Duracao_Reserva()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_Duracao_0100();            
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0930_1030();

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Criar Reserva Inválida - Pra Duracao da Reserva")]
        [Trait("Categoria", "Reservas -Duracao da Rerserva")]
        public void Reservar_para_o_Duracao_Reserva_Invalida()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_Duracao_0100();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva1, _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }


        [Fact(DisplayName = "Reserva - Colocar na Fila Válido")]
        [Trait("Categoria", "Reservas - Colocar na Fila")]
        public void Colocar_Reserva_na_Fila()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");
            areacomum.AdicionarReserva(reserva1);

            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_1200();

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act
            var result = areacomum.ValidarReserva(reserva2, _regrasDeReserva);
            reserva2.EnviarParaFila("");
            areacomum.AdicionarReserva(reserva2);
            
            //assert
            Assert.False(result.IsValid);            
          
        }
        

        [Fact(DisplayName = "Reserva - Aprovar Reserva Pendente Válido")]
        [Trait("Categoria", "Reserva - Aprovar Reserva Pendente")]
        public void Aprovar_Reserva_Pendente()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.AguardarAprovacao("");
            
            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCriacao(reserva1, areacomum);

            //act
            var result = areacomum.AprovarReservaPelaAdministracao(reserva1.Id, _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar Reserva Válido - Usuario")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Usuario")]
        public void Cancelar_Reserva_Usuario()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");

            areacomum.AdicionarReserva(reserva1);
            
            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var result = areacomum.CancelarReservaComoUsuario(reserva1, "Justificativa", _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar Reserva Inválido - Usuario")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Usuario")]
        public void Cancelar_Reserva_Usuario_Invalida()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Cancelar("");

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var result = areacomum.CancelarReservaComoUsuario(reserva1, "Justificativa", _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar Reserva Válido - Administrador")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Administrador")]
        public void Cancelar_Reserva_Administrador()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var result = areacomum.CancelarReservaComoAdministrador(reserva1, "Justificativa", _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar Reserva Inválido - Administrador")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Administrador")]
        public void Cancelar_Reserva_Administrador_Invalida()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Cancelar("");

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var result = areacomum.CancelarReservaComoAdministrador(reserva1, "Justificativa", _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar Reserva Com Antecedencia Minima Válido - Usuario")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Usuario")]
        public void Cancelar_Reserva_com_Antecedencia_minima_Usuario()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMinimaParaCancelamento1Dia();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(2));
            reserva1.Aprovar("");

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var result = areacomum.CancelarReservaComoUsuario(reserva1, "Justificativa", _regrasDeReserva);

            //assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar Reserva Com Antecedencia Minima Inválido - Usuario")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Usuario")]
        public void Cancelar_Reserva_com_Antecedencia_minima_Usuario_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_AntecedenciaMinimaParaCancelamento1Dia();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(1));
            reserva1.Aprovar("");

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var result = areacomum.CancelarReservaComoUsuario(reserva1, "Justificativa", _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar Reserva Apos a Data de Realização - Usuario")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Usuario")]
        public void Cancelar_Reserva_apos_DataRealizacao_Usuario_Invalido()
        {
            //Arrange
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var reserva1 = ReservaFactory.CriarReservaRetroativaWeb();
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(-1));
            reserva1.Aprovar("");

            areacomum.AdicionarReserva(reserva1);

            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var result = areacomum.CancelarReservaComoUsuario(reserva1, "Justificativa", _regrasDeReserva);

            //assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Reserva - Cancelar e Retirar Proxima (Primeira) da fila - Usuario")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Usuario")]
        public void Cancelar_Reserva_E_Retirar_Proxima_Da_Fila_Usuario()
        {
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Cancelar("");
            areacomum.AdicionarReserva(reserva1);

            var reserva2 = ReservaFactory.CriarReservaValidaMobile0800_0900();
            reserva2.EnviarParaFila("");
            areacomum.AdicionarReserva(reserva2);

            var reserva3 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva3.EnviarParaFila("");
            areacomum.AdicionarReserva(reserva3);                       
            
            
            SetMocksRegrasDeCriacao(reserva2, areacomum);
            SetMocksRegrasDeCriacao(reserva3, areacomum);

            reserva1.Aprovar("");

            SetMocksRegrasDeCancelamento(reserva1, areacomum);
            //act
            areacomum.CancelarReservaComoUsuario(reserva1, "Justificativa", _regrasDeReserva);
            var reservaRetiradaDaFila = areacomum.RetirarProximaReservaDaFila(reserva1, _regrasDeReserva);

            //assert
            Assert.True(reservaRetiradaDaFila.Id==reserva2.Id);
            
        }

        [Fact(DisplayName = "Reserva - Cancelar e Retirar Proxima (segunda) da fila - Usuario")]
        [Trait("Categoria", "Reserva - Cancelar Reserva Usuario")]
        public void Cancelar_Reserva_E_Retirar_Proxima_Segunda_Da_Fila_Usuario()
        {
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Cancelar("");
            areacomum.AdicionarReserva(reserva1);

            var reserva2 = ReservaFactory.CriarReservaValidaMobile1300_1700();
            reserva2.Aprovar("");
            areacomum.AdicionarReserva(reserva2);

            var reserva3 = ReservaFactory.CriarReservaValidaMobile1000_1400();
            reserva3.EnviarParaFila("");
            areacomum.AdicionarReserva(reserva3);

            var reserva4 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva4.EnviarParaFila("");            
            areacomum.AdicionarReserva(reserva4);

            SetMocksRegrasDeCriacao(reserva3, areacomum);
            SetMocksRegrasDeCriacao(reserva4, areacomum);

            reserva1.Aprovar("");

            SetMocksRegrasDeCancelamento(reserva1, areacomum);

            //act
            var retorno = areacomum.CancelarReservaComoUsuario(reserva1, "Justificativa", _regrasDeReserva);
            var reservaRetiradaDaFila = areacomum.RetirarProximaReservaDaFila(reserva1, _regrasDeReserva);

            //assert
            Assert.True(reservaRetiradaDaFila.Id == reserva4.Id);

        }

        [Fact(DisplayName = "Reserva - Com intervalo entre reservas por unidade")]
        [Trait("Categoria", "Reserva - CadastrarReserva")]
        public void Cadastrar_Com_Intervalo_Entre_Reservas_Por_Unidade()
        {
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_TempoDeIntervaloEntreReservasPorUnidade_2400();
            
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.SetDataDeRealizacao(DateTime.Today.AddDays(1).Date);
            reserva1.Aprovar("");
            areacomum.AdicionarReserva(reserva1);

            var reserva2 = ReservaFactory.CriarReservaValidaMobile1300_1700();
            reserva2.SetUnidade(reserva1.UnidadeId, reserva1.NumeroUnidade, reserva1.AndarUnidade, reserva1.DescricaoGrupoUnidade);
            reserva2.SetDataDeRealizacao(DateTime.Today.AddDays(2).Date);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act            
            var retorno = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.True(retorno.IsValid);

        }

        [Fact(DisplayName = "Reserva - Com intervalo entre reservas por unidade invalido")]
        [Trait("Categoria", "Reserva - CadastrarReserva")]
        public void Cadastrar_Com_Intervalo_Entre_Reservas_Por_Unidade_Invalido()
        {
            var areacomum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica_TempoDeIntervaloEntreReservasPorUnidade_2400();
            
            var reserva1 = ReservaFactory.CriarReservaValidaMobile0800_1200();
            reserva1.Aprovar("");
            areacomum.AdicionarReserva(reserva1);

            var reserva2 = ReservaFactory.CriarReservaValidaMobile1300_1700();
            reserva2.SetUnidade(reserva1.UnidadeId, reserva1.NumeroUnidade, reserva1.AndarUnidade, reserva1.DescricaoGrupoUnidade);

            SetMocksRegrasDeCriacao(reserva2, areacomum);

            //act            
            var retorno = areacomum.ValidarReserva(reserva2, _regrasDeReserva);

            //assert
            Assert.False(retorno.IsValid);

        }

    }
}
