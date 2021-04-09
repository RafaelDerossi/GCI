using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Domain;
using System;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Tests
{
   public class UnidadeCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly UnidadeCommandHandler _unidadeCommandHandler;

        public UnidadeCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _unidadeCommandHandler = _mocker.CreateInstance<UnidadeCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Unidade Válido")]
        [Trait("Categoria", "Unidades - UnidadeCommandHandler")]
        public async Task AdicionarUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = UnidadeCommandFactory.CriarComandoCadastroDeUnidade();

            var grupo = new Grupo("Bloco 1", Guid.NewGuid());
            grupo.SetEntidadeId(command.GrupoId);

            var condominio = new Condominio(new Cnpj("26585345000148"), "Condominio TU",
               "Condominio Teste Unitario", new Foto("Foto.jpg", "Foto.jpg"), new Telefone("(21) 99796-7038"),
                new Endereco("Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ"),
               0, null, null, null, false, false, false, false, false, false, false, false, false, false, false,
               false, false, false, false);
            condominio.SetEntidadeId(grupo.CondominioId);

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterGrupoPorId(command.GrupoId))
              .Returns(Task.FromResult(grupo));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterPorId(grupo.CondominioId))
              .Returns(Task.FromResult(condominio));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _unidadeCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.AdicionarUnidade(It.IsAny<Unidade>()), Times.Once);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Editar Unidade Válido")]
        [Trait("Categoria", "Unidades - UnidadeCommandHandler")]
        public async Task EditarUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = UnidadeCommandFactory.CriarComandoEdicaoDeUnidade();

            var grupo = new Grupo("Bloco 1", Guid.NewGuid());
            grupo.SetEntidadeId(command.GrupoId);

            var unidade = new Unidade(command.Numero, command.Andar, command.Vaga, command.Telefone,
                command.Ramal,command.Complemento, command.GrupoId, grupo.CondominioId);
            unidade.SetEntidadeId(command.UnidadeId);
            unidade.ResetCodigo();

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterUnidadePorId(unidade.Id))
             .Returns(Task.FromResult(unidade));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterGrupoPorId(unidade.GrupoId))
              .Returns(Task.FromResult(grupo));           

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _unidadeCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);           
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Reset Codigo da Unidade Válido")]
        [Trait("Categoria", "Unidades - UnidadeCommandHandler")]
        public async Task ResetarCodigoDaUnidade_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = UnidadeCommandFactory.CriarComandoResetarCodigoDaUnidade();          

            var unidade = new Unidade(command.Numero, command.Andar, command.Vaga, command.Telefone,
                command.Ramal, command.Complemento, Guid.NewGuid(), Guid.NewGuid());

            unidade.SetEntidadeId(command.UnidadeId);
            unidade.ResetCodigo();

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterUnidadePorId(unidade.Id))
             .Returns(Task.FromResult(unidade));            

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _unidadeCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}
