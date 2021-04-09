using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using Xunit;

namespace CondominioApp.Comunicados.App.Tests
{
    public class ComunicadoFactoryTests
    {
        public static Comunicado Criar_Comunicado_Publico_Valido()
        {
           return new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PUBLICO, CategoriaComunicado.COMUNICADO,
                false, false);
            
        }

        public static Comunicado Criar_Comunicado_Proprietarios_Valido()
        {
            return new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS, CategoriaComunicado.COMUNICADO,
                false, false);
        }       
       
        public static Comunicado Criar_Comunicado_Unidade_Valido()
        {           
            var grupoId = Guid.NewGuid();
            var listaUnidades = new List<UnidadeComunicado>();
            listaUnidades.Add(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            listaUnidades.Add(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));

            var comunicado = new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.UNIDADES, CategoriaComunicado.COMUNICADO,
                false, false);
            comunicado.AdicionarUnidades(listaUnidades);
            return comunicado;
        }

        public static Comunicado Criar_Comunicado_ProprietarioUnidade_Valido()
        {
            var grupoId = Guid.NewGuid();
            var listaUnidades = new List<UnidadeComunicado>();
            listaUnidades.Add(new UnidadeComunicado(Guid.NewGuid(), "101", "1", grupoId, "Bloco 1"));
            listaUnidades.Add(new UnidadeComunicado(Guid.NewGuid(), "102", "1", grupoId, "Bloco 1"));

            var comunicado = new Comunicado(
                "Titulo do Comunicado", "Descrição do Comunicado", null, Guid.NewGuid(), "Nome do Condominio",
                Guid.NewGuid(), "Nome do Usuario", VisibilidadeComunicado.PROPRIETARIOS_UNIDADES,
                CategoriaComunicado.COMUNICADO, false, false);

            comunicado.AdicionarUnidades(listaUnidades);
            return comunicado;
        }

    }
}
