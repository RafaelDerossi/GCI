using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Comunicados.App.Tests
{
    public class ComunicadoTests
    {
        [Fact(DisplayName = "Criar um Comunicado Publico Valido")]
        public void Criar_Comunicado_Publico_Valido()
        {
            //Act
            var comunicado = new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO,
                false, false);
        }

        [Fact(DisplayName = "Criar um Comunicado Para Proprietario Valido")]
        public void Criar_Comunicado_Proprietarios_Valido()
        {
            //Act
            var comunicado = new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS, CategoriaComunicado.COMUNICADO,
                false, false);
        }

       
        [Fact(DisplayName = "Criar um Comunicado Para Unidades Valido")]
        public void Criar_Comunicado_Unidade_Valido()
        {
            //Arrange
            var grupoId = Guid.NewGuid();

            //Act
            var comunicado = new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES, CategoriaComunicado.COMUNICADO,
                false, false);

            comunicado.AdicionarUnidade(new Unidade(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new Unidade(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));
        }


        [Fact(DisplayName = "Criar um Comunicado Para Proprietario de Unidades Valido")]
        public void Criar_Comunicado_ProprietarioUnidade_Valido()
        {
            //Arrange
            var grupoId = Guid.NewGuid();

            //Act
            var comunicado = new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidade(new Unidade(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            comunicado.AdicionarUnidade(new Unidade(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));
        }

    }
}
