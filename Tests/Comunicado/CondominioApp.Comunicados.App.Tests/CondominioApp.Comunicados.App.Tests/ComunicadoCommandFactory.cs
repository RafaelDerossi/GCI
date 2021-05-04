using CondominioApp.Comunicados.App.Aplication.Commands;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Comunicados.App.Tests
{
    public class ComunicadoCommandFactory
    {
        private static CadastrarComunicadoCommand CadastrarCondominioCommandFactory()
        {
            return new CadastrarComunicadoCommand(
               "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
               "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
               CategoriaComunicado.COMUNICADO, false, false, null);
        }
        private static EditarComunicadoCommand EditarComunicadoCommandFactory()
        {
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO, false,
                null);
        }



        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_Publico()
        {
            //Act
            return CadastrarCondominioCommandFactory();
        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_Proprietario()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS);

            //Act
            return comando;
        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_Unidade()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1")
            };

            comando.SetUnidades(unidades);

            //Act
            return comando;
        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_ProprietarioUnidade()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS_UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1")
            };

            comando.SetUnidades(unidades);

            //Act
            return comando;

        }


        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_Unidade_SemUnidades()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.UNIDADES);

            //Act
            return comando;

        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_Unidade_ComUnidadeRepetida()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1")
            };

            comando.SetUnidades(unidades);

            //Act
            return comando;

        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_ProprietarioUnidade_SemUnidades()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS_UNIDADES);

            //Act
            return comando;
        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_ProprietarioUnidade_ComUnidadeRepetida()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS_UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1")
            };

            //Act
            comando.SetUnidades(unidades);

            //Act
            return comando;

        }




        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_SemTitulo()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetTitulo("");

            //Act
            return comando;

        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_SemDescricao()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetDescricao("");

            //Act
            return comando;
            
        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_ComDescricaoGrandeDemais()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetDescricao("qwertyuiopasdfghjklçqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklqwertyu " +
                "qwertyuiopasdfghjklçqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklqwertyu");

            //Act
            return comando;

        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_SemCondominioId()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetCondominio(Guid.Empty, "");

            //Act
            return comando;

        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_SemNomeDoCondominio()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetCondominio(Guid.NewGuid(), "");

            //Act
            return comando;

        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_SemUsuarioId()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetFuncionario(Guid.Empty, "");

            //Act
            return comando;

        }
        public static CadastrarComunicadoCommand CriarComando_CadastroDeComunicado_SemNomeUsuario()
        {
            //Arrange
            var comando = CadastrarCondominioCommandFactory();
            comando.SetFuncionario(Guid.NewGuid(), "");

            //Act
            return comando;
        }
      



        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_Publico()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();

            //Act
            return comando;

        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_Proprietario()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS);

            //Act
            return comando;

        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_Unidade()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1")
            };

            comando.SetUnidades(unidades);

            //Act
            return comando;

        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_ProprietarioUnidade()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS_UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1")
            };

            comando.SetUnidades(unidades);

            //Act
            return comando;

        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_Unidade_SemUnidades()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.UNIDADES);

            //Act
            return comando;

        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_Unidade_ComUnidadeRepetida()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1")
            };

            comando.SetUnidades(unidades);

            //Act
            return comando;
        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_ProprietarioUnidade_SemUnidades()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS_UNIDADES);

            //Act
            return comando;

        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_ProprietarioUnidade_ComUnidadeRepetida()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetVisibilidade(VisibilidadeComunicado.PROPRIETARIOS_UNIDADES);

            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<UnidadeComunicado>
            {
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1"),
                new UnidadeComunicado(unidadeId, "101", "1", grupoId, "Bloco 1")
            };

            comando.SetUnidades(unidades);

            //Act
            return comando;

        }


        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_SemTitulo()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetTitulo("");

            //Act
            return comando;           
        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_SemDescricao()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetDescricao("");

            //Act
            return comando;
        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_SemFuncionarioId()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetFuncionario(Guid.Empty, "");

            //Act
            return comando;
        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_SemNomeDoFuncionario()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetFuncionario(Guid.NewGuid(), "");

            //Act
            return comando;
        }

        public static EditarComunicadoCommand CriarComando_EdicaoDeComunicado_ComDescricaoGrandeDemais()
        {
            //Arrange
            var comando = EditarComunicadoCommandFactory();
            comando.SetDescricao("qwertyuiopasdfghjklçqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklqwertyu " +
                "qwertyuiopasdfghjklçqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklçzxcvbnmqwertyuiopasdfghjklqwertyu");

            //Act
            return comando;

        }
    }
}