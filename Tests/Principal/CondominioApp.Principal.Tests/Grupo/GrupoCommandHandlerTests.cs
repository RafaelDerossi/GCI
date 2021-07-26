using CondominioApp.Principal.Aplication.Commands;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Domain;

namespace CondominioApp.Principal.Tests
{
    public class GrupoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly GrupoCommandHandler _grupoCommandHandler;

        public GrupoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _grupoCommandHandler = _mocker.CreateInstance<GrupoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Grupo Válido")]
        [Trait("Categoria", "Grupos - GrupoCommandHandler")]
        public async Task AdicionarGrupo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = GrupoCommandFactory.CriarComandoCadastroDeGrupo();

            var condominio = CondominioFactoryTests.Criar_Condominio_Valido();

            condominio.SetEntidadeId(command.CondominioId);

           

            //_mocker.GetMock<ICondominioRepository>().Setup(r => r.GrupoJaExiste(command.Descricao,command.CondominioId,command.GrupoId))
            //    .Returns(Task.FromResult(true));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterPorId(command.CondominioId))
               .Returns(Task.FromResult(condominio));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _grupoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.AdicionarGrupo(It.IsAny<Grupo>()), Times.Once);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }



        [Fact(DisplayName = "Editar Grupo Válido")]
        [Trait("Categoria", "Grupos - GrupoCommandHandler")]
        public async Task EditarGrupo_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = GrupoCommandFactory.CriarComandoEdicaoDeGrupo();

            var grupo = new Grupo(command.Descricao, command.CondominioId);
            grupo.SetEntidadeId(command.GrupoId);

            var condominio = CondominioFactoryTests.Criar_Condominio_Valido();

            condominio.SetEntidadeId(command.CondominioId);

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterGrupoPorId(grupo.Id))
                .Returns(Task.FromResult(grupo));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterPorId(command.CondominioId))
               .Returns(Task.FromResult(condominio));

            //_mocker.GetMock<ICondominioRepository>().Setup(r => r.GrupoJaExiste(grupo.Descricao, grupo.CondominioId, grupo.Id))
            //  .Returns(Task.FromResult(false));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _grupoCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.Atualizar(It.IsAny<Condominio>()), Times.Once);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}
