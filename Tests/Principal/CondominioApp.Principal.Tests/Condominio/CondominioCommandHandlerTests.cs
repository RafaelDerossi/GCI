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

namespace CondominioApp.Principal.Tests
{
   public class CondominioCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly CondominioCommandHandler _condominioCommandHandler;

        public CondominioCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _condominioCommandHandler = _mocker.CreateInstance<CondominioCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Condominio Válido")]
        [Trait("Categoria", "Condominios - CondominioCommandHandler")]
        public async Task AdicionarCondominio_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CondominioCommandFactory.CriarComandoCadastroDeCondominio();

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.CnpjCondominioJaCadastrado(command.Cnpj, command.Id))
                .Returns(Task.FromResult(false));               

           
            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _condominioCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.Adicionar(It.IsAny<Condominio>()), Times.Once);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Editar Condominio Válido")]
        [Trait("Categoria", "Condominios - CondominioCommandHandler")]
        public async Task EditarCondominio_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CondominioCommandFactory.CriarComandoEdicaoDeCondominio();
            
            var condominio = CondominioFactoryTests.Criar_Condominio_Valido();

            condominio.SetEntidadeId(command.Id);
            condominio.SetCNPJ(command.Cnpj);
            condominio.SetNome(command.Nome);
            condominio.SetDescricao(command.Descricao);
            condominio.SetLogo(command.Logo);
            condominio.SetTelefone(command.Telefone);
            condominio.SetEndereco(command.Endereco);

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(condominio));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.CnpjCondominioJaCadastrado(condominio.Cnpj, command.Id))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _condominioCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.Atualizar(It.IsAny<Condominio>()), Times.Once);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Editar Configuracao Condominio Válido")]
        [Trait("Categoria", "Condominios - CondominioCommandHandler")]
        public async Task EditarConfiguracaoCondominio_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var command = CondominioCommandFactory.CriarComandoEdicaoDeCondominio();

            var condominio = CondominioFactoryTests.Criar_Condominio_Valido();

            condominio.SetEntidadeId(command.Id);
            condominio.SetCNPJ(command.Cnpj);
            condominio.SetNome(command.Nome);
            condominio.SetDescricao(command.Descricao);
            condominio.SetLogo(command.Logo);
            condominio.SetTelefone(command.Telefone);
            condominio.SetEndereco(command.Endereco);

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.ObterPorId(command.Id))
                .Returns(Task.FromResult(condominio));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.CnpjCondominioJaCadastrado(condominio.Cnpj, command.Id))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IPrincipalRepository>().Setup(r => r.UnitOfWork.Commit())
               .Returns(Task.FromResult(true));

            //Act
            var result = await _condominioCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.Atualizar(It.IsAny<Condominio>()), Times.Once);
            _mocker.GetMock<IPrincipalRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }
    }
}
