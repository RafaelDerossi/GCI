using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.Core.Enumeradores;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasParaAdministrador;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasGerais;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaMorador;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaAdministracao;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras.Interfaces;

namespace CondominioApp.ReservaAreaComum.Tests
{
   public class ReservaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly ReservaCommandHandler _reservaCommandHandler;
        private readonly ReservaStrategy _regrasDeReserva;

        private RegrasDeCriacaoDeReserva _regrasDeCriacao;

        private RegrasGeraisParaReservar _regrasGerais;
        private RegraIntervalosFixos _regraIntervalosFixos;
        private RegraDuracaoLimite _regraDuracaoLimite;
        private RegraHorarioDisponivelSemSobreposicao _regraSemSobreposicao;
        private RegraHorarioDisponivelComSobreposicao _regraComSobreposicao;

        private RegrasDeAdministradorParaReservar _regrasDeAdministradorParaReservar;
        private RegraDataRetroativaPermitida _regraDaDataRetroativaPermitida;

        private RegrasDeMoradorParaReservar _regrasDeMoradorParaReservar;
        private RegraIntervaloParaMesmaUnidade _regraIntervaloParaMesmaUnidade;
        private RegraDataRetroativaNaoPermitida _regraDataRetroativaNaoPermitida;
        private RegraBloqueioDaAreaComum _regraBloqueioDaAreaComum;
        private RegraAntecedenciaMaxima _regraAntecedenciaMaxima;
        private RegraAntecedenciaMinima _regraAntecedenciaMinima;
        private RegraDiasPermitidos _regraDiasPermitidos;
        private RegraLimitePorUnidadePorDia _regraLimitePorUnidadePorDia;
        private RegraHorarioDentroDosLimites _regraHorarioDentroDosLimites;


        private RegrasDeCancelamentoDeReserva _regrasDeCancelamentoDeReserva;
        private RegrasDeCancelamentoDeReservaPeloMorador _regrasDeCancelamentoDeReservaPeloMorador;
        private RegrasDeCancelamentoDeReservaPelaAdministracao _regrasDeCancelamentoDeReservaPelaAdministracao;
        private RegraDoPrazoMinimoPraCancelar _regraDoPrazoMinimoPraCancelar;
        private RegraDoStatusPraCancelar _regraDoStatusPraCancelar;

        public ReservaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _reservaCommandHandler = _mocker.CreateInstance<ReservaCommandHandler>();
            _regrasDeReserva = _mocker.CreateInstance<ReservaStrategy>();
        }

        private void SetMocksRegrasGerais(Reserva reserva, AreaComum areacomum)
        {
            _regraIntervalosFixos = _mocker.CreateInstance<RegraIntervalosFixos>();
            _regraDuracaoLimite = _mocker.CreateInstance<RegraDuracaoLimite>();
            _regraSemSobreposicao = _mocker.CreateInstance<RegraHorarioDisponivelSemSobreposicao>();
            _regraComSobreposicao = _mocker.CreateInstance<RegraHorarioDisponivelComSobreposicao>();

            _regrasGerais = _mocker.CreateInstance<RegrasGeraisParaReservar>();

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
            _regrasDeAdministradorParaReservar = _mocker.CreateInstance<RegrasDeAdministradorParaReservar>();
            _regraDaDataRetroativaPermitida = _mocker.CreateInstance<RegraDataRetroativaPermitida>();

            var retRegraDataRetroativaPermitida = _regraDaDataRetroativaPermitida.Validar(reserva);
            _mocker.GetMock<IRegraDataRetroativaPermitida>().Setup(r => r.Validar(reserva))
               .Returns(retRegraDataRetroativaPermitida);

            var retRegrasDeAdministradorParaReservar = _regrasDeAdministradorParaReservar.Validar(reserva);
            _mocker.GetMock<IRegrasDeAdministradorParaReservar>().Setup(r => r.Validar(reserva))
               .Returns(retRegrasDeAdministradorParaReservar);
        }

        private void SetMocksRegrasDeMoradorParaReservar(Reserva reserva, AreaComum areacomum)
        {
            _regrasDeMoradorParaReservar = _mocker.CreateInstance<RegrasDeMoradorParaReservar>();
            _regraIntervaloParaMesmaUnidade = _mocker.CreateInstance<RegraIntervaloParaMesmaUnidade>();
            _regraDataRetroativaNaoPermitida = _mocker.CreateInstance<RegraDataRetroativaNaoPermitida>();
            _regraBloqueioDaAreaComum = _mocker.CreateInstance<RegraBloqueioDaAreaComum>();
            _regraAntecedenciaMaxima = _mocker.CreateInstance<RegraAntecedenciaMaxima>();
            _regraAntecedenciaMinima = _mocker.CreateInstance<RegraAntecedenciaMinima>();
            _regraDiasPermitidos = _mocker.CreateInstance<RegraDiasPermitidos>();
            _regraLimitePorUnidadePorDia = _mocker.CreateInstance<RegraLimitePorUnidadePorDia>();
            _regraHorarioDentroDosLimites = _mocker.CreateInstance<RegraHorarioDentroDosLimites>();

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

            _regrasDeCriacao = _mocker.CreateInstance<RegrasDeCriacaoDeReserva>();

            var retRegrasDeCriacao = _regrasDeCriacao.Validar(reserva, areacomum);
            _mocker.GetMock<IRegrasDeCriacaoDeReserva>().Setup(r => r.Validar(reserva, areacomum))
               .Returns(retRegrasDeCriacao);

            var retVerificaReservasAprovadas = _regrasDeCriacao.VerificaReservasAprovadas(reserva, areacomum);
            _mocker.GetMock<IRegrasDeCriacaoDeReserva>().Setup(r => r.VerificaReservasAprovadas(reserva, areacomum))
               .Returns(retVerificaReservasAprovadas);

            var retVerificaReservasAprovadas2 = _regrasDeReserva.VerificaReservasAprovadas(reserva, areacomum);
            _mocker.GetMock<IReservaStrategy>().Setup(r => r.VerificaReservasAprovadas(reserva, areacomum))
              .Returns(retVerificaReservasAprovadas2);

            var retValidarRegrasParaCiracao = _regrasDeReserva.ValidarRegrasParaCriacao(reserva, areacomum);
            _mocker.GetMock<IReservaStrategy>().Setup(r => r.ValidarRegrasParaCriacao(reserva, areacomum))
              .Returns(retValidarRegrasParaCiracao);
        }

        private void SetMocksRegrasDeCancelamento(Reserva reserva, AreaComum areacomum)
        {
            _regraDoPrazoMinimoPraCancelar = _mocker.CreateInstance<RegraDoPrazoMinimoPraCancelar>();
            _regraDoStatusPraCancelar = _mocker.CreateInstance<RegraDoStatusPraCancelar>();
            _regrasDeCancelamentoDeReservaPelaAdministracao = _mocker.CreateInstance<RegrasDeCancelamentoDeReservaPelaAdministracao>();
            _regrasDeCancelamentoDeReservaPeloMorador = _mocker.CreateInstance<RegrasDeCancelamentoDeReservaPeloMorador>();
            _regrasDeCancelamentoDeReserva = _mocker.CreateInstance<RegrasDeCancelamentoDeReserva>();

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


            var retRegrasDeReservaCancelamentoPelaAdm = _regrasDeCancelamentoDeReserva.ValidarCancelamentoPelaAdministracao(reserva);
            _mocker.GetMock<IReservaStrategy>().Setup(r => r.ValidarRegrasParaCancelamentoPelaAdministracao(reserva))
               .Returns(retRegrasDeReservaCancelamentoPelaAdm);

            var retRegrasDeReservaCancelamentoPeloMorador = _regrasDeCancelamentoDeReserva.ValidarCancelamentoPeloMorador(reserva, areacomum);
            _mocker.GetMock<IReservaStrategy>().Setup(r => r.ValidarRegrasParaCancelamentoPeloMorador(reserva, areacomum))
               .Returns(retRegrasDeReservaCancelamentoPeloMorador);
        }



        [Fact(DisplayName = "Adicionar Reserva Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task AdicionarReserva_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var command = ReservaCommandFactory.CriarComandoCadastroDeReserva();
            command.SetAreaComumId(areaComum.Id);            

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(command.AreaComumId))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.AdicionarReserva(It.IsAny<Reserva>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Aprovar Reserva Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task AprovarReserva_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange            
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoDeAdministracao();
            var reserva = ReservaFactory.CriarReservaValidaMobile();
            reserva.SetAreaComumId(areaComum.Id);
            reserva.AguardarAprovacao("");
            areaComum.AdicionarReserva(reserva);

            var command = new AprovarReservaPelaAdministracaoCommand(reserva.Id);

            SetMocksRegrasDeCriacao(reserva, areaComum);            

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(command.Id))
               .Returns(Task.FromResult(reserva));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva.AreaComumId))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));
            
            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);            
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Cancelar Reserva Como Usuario Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task CancelarReserva_ComoUsuario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile();
            areaComum.AdicionarReserva(reserva);
            reserva.SetAreaComumId(areaComum.Id);

            var command = new CancelarReservaComoUsuarioCommand
                (reserva.Id, "Justificativa");

            SetMocksRegrasDeCancelamento(reserva, areaComum);

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(reserva.Id))
              .Returns(Task.FromResult(reserva));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva.AreaComumId))
               .Returns(Task.FromResult(areaComum));           

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);           
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Cancelar Reserva Como Administrador Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task CancelarReserva_ComoAdministrador_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva = ReservaFactory.CriarReservaValidaMobile();
            areaComum.AdicionarReserva(reserva);
            reserva.SetAreaComumId(areaComum.Id);

            var command = new CancelarReservaComoAdministradorCommand
                (reserva.Id, "Justificativa");

            SetMocksRegrasDeCancelamento(reserva, areaComum);

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(reserva.Id))
              .Returns(Task.FromResult(reserva));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva.AreaComumId))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Retirar Reserva da Fila Válido")]
        [Trait("Categoria", "Reserva -ReservaCommandHandler")]
        public async Task RetirarReservaDaFila_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            var reserva1 = ReservaFactory.CriarReservaValidaMobile();
            reserva1.SetAreaComumId(areaComum.Id);
            reserva1.Cancelar("Justificativa");

            var reserva2 = ReservaFactory.CriarReservaValidaMobile();
            reserva2.SetAreaComumId(areaComum.Id);
            reserva2.EnviarParaFila("");

            areaComum.AdicionarReserva(reserva1);
            areaComum.AdicionarReserva(reserva2);

            var command = new RetirarReservaDaFilaCommand(reserva1.Id);

            SetMocksRegrasDeCriacao(reserva2, areaComum);

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterReservaPorId(reserva1.Id))
              .Returns(Task.FromResult(reserva1));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(reserva1.AreaComumId))
               .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _reservaCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid && reserva2.Status != StatusReserva.NA_FILA);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

    }
}
