using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Comunicados.App.Aplication.Commands;
using CondominioApp.Comunicados.App.Tests;
using CondominioApp.Comunicados.App.Models;

namespace CondominioApp.Correspondencias.App.Tests
{
   public class ComunicadoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly ComunicadoCommandHandler _comunicadoCommandCommandHandler;

        public ComunicadoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _comunicadoCommandCommandHandler = _mocker.CreateInstance<ComunicadoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Comunicado Publico Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoPublico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoPublico();          
           
            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Adicionar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Comunicado Proprietario Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoProprietario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoProprietario();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Adicionar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Comunicado Unidade Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoUnidade();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Adicionar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Comunicado Proprietario-Unidade Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoProprietarioUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoProprietarioUnidade();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Adicionar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }



        [Fact(DisplayName = "Adicionar Comunicado pra Unidade Inválido - Sem Unidades")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoPraUnidadeSemUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoPraUnidadeSemUnidades();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Comunicado pra Unidade Inválido - Com Unidade Repetida")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoPraUnidadeComUnidadeRepetida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoUnidadeComUnidadeRepetida();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Comunicado pra Proprietario de Unidade Inválido - Sem Unidades")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoPraProprietarioDeUnidadeSemUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoPraProprietarioDeUnidadeSemUnidades();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Comunicado pra Proprietario de Unidade Inválido - Com Unidade Repetida")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoPraProprietarioDeUnidadeComUnidadeRepetida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoPraProprietarioDeUnidadeComUnidadeRepetida();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }




        [Fact(DisplayName = "Adicionar Comunicado Inválido - Sem Titulo")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoSemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoSemTitulo();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);          
        }

        [Fact(DisplayName = "Adicionar Comunicado Inválido - Sem Descrição")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoSemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoSemDescricao();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Comunicado Inválido - Sem Condominio Id")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoSemCondominioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoSemCondominioId();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Comunicado Inválido - Sem Nome do Condominio")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoSemNomeDoCondominio_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoSemNomeDoCondominio();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Comunicado Inválido - Sem Usuario Id")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoSemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoSemUsuarioId();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Comunicado Inválido - Sem Nome do Usuario")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task AdicionarComunicadoSemNomeDoUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoCadastroDeComunicadoSemNomeUsuario();

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }






        [Fact(DisplayName = "Editar Comunicado Publico Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoPublico_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoPublico();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
               CategoriaComunicado.COMUNICADO, false, false);           
            

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Atualizar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Editar Comunicado Proprietario Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoProprietario_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoProprietario();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS,
               CategoriaComunicado.COMUNICADO, false, false);

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Atualizar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Editar Comunicado Unidade Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoUnidade();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
               CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Atualizar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Editar Comunicado Proprietario-Unidade Válido")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoProprietarioUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoProprietarioUnidade();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES,
               CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.Atualizar(It.IsAny<Comunicado>()), Times.Once);
            _mocker.GetMock<IComunidadoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }




        [Fact(DisplayName = "Editar Comunicado pra Unidade Invalido -  Sem Unidades")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoPraUnidadeSemUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoPraUnidadeSemUnidades();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
               CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Editar Comunicado pra Unidade Invalido -  Com Unidade Repetida")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoPraUnidadeComUnidadeRepetida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoPraUnidadeComUnidadeRepetida();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
               CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Editar Comunicado pra Proprietario de Unidade Invalido -  Sem Unidades")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoPraProprietarioDeUnidadeSemUnidade_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoPraProprietarioDeUnidadeSemUnidades();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
               CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Editar Comunicado pra Proprietario De Unidade Invalido -  Com Unidade Repetida")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoPraProprietarioDeUnidadeComUnidadeRepetida_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoPraProprietarioDeUnidadeComUnidadeRepetida();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
               CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }



        [Fact(DisplayName = "Editar Comunicado Publico Inválido - Sem Titulo")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoSemTitulo_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoSemTitulo();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
               CategoriaComunicado.COMUNICADO, false, false);


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
           
        }

        [Fact(DisplayName = "Editar Comunicado Publico Inválido - Sem Descricao")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoSemDescricao_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoSemDescricao();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
               CategoriaComunicado.COMUNICADO, false, false);


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);

        }


        [Fact(DisplayName = "Editar Comunicado Publico Inválido - Sem UsuarioId")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoSemUsuarioId_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoSemUsuarioId();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
               CategoriaComunicado.COMUNICADO, false, false);


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);

        }


        [Fact(DisplayName = "Editar Comunicado Publico Inválido - Sem Nome do Usuario")]
        [Trait("Categoria", "Comunicados - ComunicadoCommandHandler")]
        public async Task EditarComunicadoSemNomeDoUsuario_CommandoInvalido_NaoDevePassarNaValidacao()
        {
            //Arrange

            var command = ComunicadoCommandFactory.CriarComandoEdicaoDeComunicadoSemNomeDoUsuario();

            var grupoId = Guid.NewGuid();
            var comunicado = new Comunicado(
               "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
               Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
               CategoriaComunicado.COMUNICADO, false, false);


            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.ObterPorId(command.ComunicadoId))
                .Returns(Task.FromResult(comunicado));

            _mocker.GetMock<IComunidadoRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _comunicadoCommandCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);

        }



    }
}
