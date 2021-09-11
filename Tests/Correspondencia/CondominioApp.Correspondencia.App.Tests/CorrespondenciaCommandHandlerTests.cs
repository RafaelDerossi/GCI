﻿using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using System.Collections.Generic;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;

namespace CondominioApp.Correspondencias.App.Tests
{
   public class CorrespondenciaCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly CorrespondenciaCommandHandler _correspondenciaCommandCommandHandler;

        public CorrespondenciaCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _correspondenciaCommandCommandHandler = _mocker.CreateInstance<CorrespondenciaCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Correspondencia Válido")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task AdicionarCorrespondencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoCadastroDeCorrespondencia();          
           
            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.Adicionar(It.IsAny<Correspondencia>()), Times.Once);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }




        [Fact(DisplayName = "Marcar Correspondencia Vista Válido")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task MarcarCorrespondenciaVista_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaVista();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.Atualizar(It.IsAny<Correspondencia>()), Times.Once);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }




        [Fact(DisplayName = "Marcar Correspondencia Retirada Válido")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task MarcarCorrespondenciaRetirada_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaRetirada();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.Atualizar(It.IsAny<Correspondencia>()), Times.Once);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Marcar Correspondencia Retirada Invalido - Ja Retirada")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task MarcarCorrespondenciaRetiradaJaRetirada_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaRetirada();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            correspondencia.MarcarComRetirada("Rafael", "", Guid.NewGuid(), "Funcionario", null);

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Marcar Correspondencia Retirada Invalido - Ja Devolvida")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task MarcarCorrespondenciaRetiradaJaDevolvida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaRetirada();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            correspondencia.MarcarComDevolvida("", Guid.NewGuid(), "Funcionario");

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
          }




        [Fact(DisplayName = "Marcar Correspondencia Devolvida Válido")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task MarcarCorrespondenciaDevolvida_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaDevolvida();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.Atualizar(It.IsAny<Correspondencia>()), Times.Once);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Marcar Correspondencia Devolvida Inválido - Ja Retirada")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task MarcarCorrespondenciaDevolvidaJaRetirada_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaDevolvida();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            correspondencia.MarcarComRetirada("Rafael", "", Guid.NewGuid(), "Funcionario", null);

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Marcar Correspondencia Devolvida Inválido - Ja Devolvida")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task MarcarCorrespondenciaDevolvidaJaDevolvida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoMarcarCorrespondenciaDevolvida();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();
            correspondencia.SetDevolvido();

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
       }


        [Fact(DisplayName = "Disparar Alerta De Correspondencia Válido")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task DispararAlertaDeCorrespondencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoDispararAlertaDeCorrespondencia();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.Atualizar(It.IsAny<Correspondencia>()), Times.Once);
            _mocker.GetMock<ICorrespondenciaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Disparar Alerta De Correspondencia Inválido - Ja Retirado")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task DispararAlertaDeCorrespondenciaJaRetirado_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoDispararAlertaDeCorrespondencia();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            correspondencia.SetRetirado();

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
         }
       
        [Fact(DisplayName = "Disparar Alerta De Correspondencia Inválido - Ja Devolvido")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task DispararAlertaDeCorrespondenciaJaDevolvido_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandoDispararAlertaDeCorrespondencia();

            var correspondencia = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();

            correspondencia.SetDevolvido();

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorId(command.CorrespondenciaId))
                .Returns(Task.FromResult(correspondencia));

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        

        [Fact(DisplayName = "Gerar Excel De Correspondencia Valido")]
        [Trait("Categoria", "Correspondencias - CorrespondenciaCommandHandler")]
        public async Task GerarExcelDeCorrespondencia_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CorrespondenciaCommandFactory.CriarComandGerarExcelDeCorrespondencia();

            var correspondencia1 = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();
            var correspondencia2 = CorrespondenciaFactoryTests.Criar_Correspondencia_Valida();
            var correspondencias = new List<Correspondencia>
            {
                correspondencia1,
                correspondencia2
            };

            IEnumerable<Correspondencia> listaDeCorrespondencia = correspondencias;

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.ObterPorIds(command.ListaCorrespondenciaId))
             .Returns(Task.FromResult(listaDeCorrespondencia));            

            _mocker.GetMock<ICorrespondenciaRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _correspondenciaCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
        }

    }
}