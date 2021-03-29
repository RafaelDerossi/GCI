using CondominioApp.Ocorrencias.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Ocorrencias.App.Tests
{
   public class OcorrenciaFactoryTests
    {
        private static Ocorrencia Factory()
        {
            return new Ocorrencia
                ("Descrição da ocorrencia", new App.ValueObjects.Foto("foto.jpg", "foto.jpg"),
                false, Guid.NewGuid(), Guid.NewGuid(), "Nome do Morador", Guid.NewGuid(), false);
        }

        public static Ocorrencia Criar_Ocorrencia_Valida()
        {
            return Factory();
        }

        public static Ocorrencia Criar_Ocorrencia_EmAndamento_Valido()
        {
            var ocorrencia = Factory();
            
            ocorrencia.ColocarEmAndamento();

            return ocorrencia;
        }

        public static Ocorrencia Criar_Ocorrencia_Resolvida_Valido()
        {
            var ocorrencia = Factory();

            ocorrencia.MarcarComoResolvida();

            return ocorrencia;
        }
    }
}
