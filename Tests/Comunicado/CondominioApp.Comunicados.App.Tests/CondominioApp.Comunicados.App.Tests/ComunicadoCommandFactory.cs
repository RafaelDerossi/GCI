using CondominioApp.Comunicados.App.Aplication.Commands;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;

namespace CondominioApp.Comunicados.App.Tests
{
    public class ComunicadoCommandFactory
    {
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoPublico()
        {          
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }

        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoProprietario()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }

        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoUnidade()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));

            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false, unidades);
        }

        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoProprietarioUnidade()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));

            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false, unidades);
        }


        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoPraUnidadeSemUnidades()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoUnidadeComUnidadeRepetida()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));

            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false, unidades);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoPraProprietarioDeUnidadeSemUnidades()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoPraProprietarioDeUnidadeComUnidadeRepetida()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));

            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false, unidades);
        }





        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoSemTitulo()
        {
            //Act
            return new CadastrarComunicadoCommand(
               "", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoSemDescricao()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoSemCondominioId()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.Empty,
                "Nome do Condominio", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoSemNomeDoCondominio()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "", Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoSemUsuarioId()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.Empty, "Nome do Usuario", VisibilidadeComunicado.PUBLICO,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
        public static CadastrarComunicadoCommand CriarComandoCadastroDeComunicadoSemNomeUsuario()
        {
            //Act
            return new CadastrarComunicadoCommand(
                "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Condominio", Guid.NewGuid(), null, VisibilidadeComunicado.PUBLICO,
                CategoriaComunicado.COMUNICADO, false, false, null);
        }
      



        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoPublico()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(),"Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO, false,
                null);
        }

        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoProprietario()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS, CategoriaComunicado.COMUNICADO, false,
                null);
        }

        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoUnidade()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));

            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.UNIDADES, CategoriaComunicado.COMUNICADO, 
                false, unidades);
        }

        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoProprietarioUnidade()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));

            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES, CategoriaComunicado.COMUNICADO,
                false, unidades);
        }


        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoPraUnidadeSemUnidades()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.UNIDADES, CategoriaComunicado.COMUNICADO,
                false, null);
        }
        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoPraUnidadeComUnidadeRepetida()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));

            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.UNIDADES, CategoriaComunicado.COMUNICADO,
                false, unidades);
        }
        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoPraProprietarioDeUnidadeSemUnidades()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES, CategoriaComunicado.COMUNICADO,
                false, null);
        }
        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoPraProprietarioDeUnidadeComUnidadeRepetida()
        {
            //Arrange
            var grupoId = Guid.NewGuid();
            var unidadeId = Guid.NewGuid();
            var unidades = new List<Unidade>();
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));
            unidades.Add(new Unidade(unidadeId, "101", "1", grupoId, "Bloco 1"));

            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES, CategoriaComunicado.COMUNICADO,
                false, unidades);
        }


        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoSemTitulo()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "", "Descricao do Comunicado", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO, false,
                null);
        }

        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoSemDescricao()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "", null, Guid.NewGuid(),
                "Nome do Usuario", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO, false,
                null);
        }

        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoSemUsuarioId()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.Empty,
                "Nome do Usuario", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO, false,
                null);
        }

        public static EditarComunicadoCommand CriarComandoEdicaoDeComunicadoSemNomeDoUsuario()
        {
            //Act
            return new EditarComunicadoCommand(
                Guid.NewGuid(), "Titulo do Comunicado", "Descricao do Comunicado", null, Guid.NewGuid(),
                "", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO, false,
                null);
        }
    }
}