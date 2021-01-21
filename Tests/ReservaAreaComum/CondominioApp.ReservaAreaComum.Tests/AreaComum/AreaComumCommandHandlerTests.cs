using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain;
using System.Linq;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;

namespace CondominioApp.ReservaAreaComum.Tests
{
   public class AreaComumCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly AreaComumCommandHandler _areaComumCommandHandler;

        public AreaComumCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _areaComumCommandHandler = _mocker.CreateInstance<AreaComumCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AdicionarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum();

                     
            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);           
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.Adicionar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Area Comum Válido - Periodos")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AdicionarAreaComum_Periodos_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodosValido();


            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.Adicionar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Area Comum Válido - Periodos Pernoite")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AdicionarAreaComum_PeriodosPernoite_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodosPernoiteValido();


            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.Adicionar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Periodos Conflitantes")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AdicionarAreaComum_PeriodosConflitantes_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodosConflitantesInvalido();


            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
            
        }

        [Fact(DisplayName = "Adicionar Area Comum Inválido - Periodos Invertidos Conflitantes")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AdicionarAreaComum_PeriodosInvertidosConflitantes_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodosInvertidosConflitantesInvalido();


            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);

        }


        [Fact(DisplayName = "Adicionar Area Comum Inválido - Periodos Pernoite Conflitantes")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AdicionarAreaComum_PeriodosPernoiteConflitantes_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = AreaComumCommandFactory.CriarComandoCadastroDeAreaComum_PeriodosPernoiteConflitantesInvalido();


            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);

        }

        



        [Fact(DisplayName = "Editar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task EditarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();

            var command = new EditarAreaComumCommand
              (areaComum.Id, areaComum.Nome, areaComum.Descricao, areaComum.TermoDeUso,
               areaComum.Capacidade, areaComum.DiasPermitidos, areaComum.AntecedenciaMaximaEmMeses,
               areaComum.AntecedenciaMaximaEmDias, areaComum.AntecedenciaMinimaEmDias,
               areaComum.AntecedenciaMinimaParaCancelamentoEmDias , areaComum.RequerAprovacaoDeReserva,
               areaComum.TemHorariosEspecificos, areaComum.TempoDeIntervaloEntreReservas, areaComum.TempoDeDuracaoDeReserva,
               areaComum.NumeroLimiteDeReservaPorUnidade, areaComum.PermiteReservaSobreposta, areaComum.NumeroLimiteDeReservaSobreposta,
               areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade,areaComum.TempoDeIntervaloEntreReservasPorUsuario,
               areaComum.Periodos.ToList());


            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.AdicionarPeriodo(It.IsAny<Periodo>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.Atualizar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Ativar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task AtivarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            areaComum.DesativarAreaComum();

            var command = AreaComumCommandFactory.CriarComandoAtivacaoDeAreaComum();

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.Atualizar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Desativar Area Comum Válido")]
        [Trait("Categoria", "Area Comum -AreaComumCommandHandler")]
        public async Task DesativarAreaComum_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var areaComum = AreaComumFactory.CriarAreaComum_AprovacaoAutomatica();
            areaComum.AtivarAreaComum();

            var command = AreaComumCommandFactory.CriarComandoDesativacaoDeAreaComum();

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(areaComum));

            _mocker.GetMock<IReservaAreaComumRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _areaComumCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.Atualizar(It.IsAny<AreaComum>()), Times.Once);
            _mocker.GetMock<IReservaAreaComumRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


    }
}
