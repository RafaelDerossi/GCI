using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Models;
using System;

namespace CondominioApp.Ocorrencias.App.Tests
{
   public class OcorrenciaFactoryTests
    {
        private static Ocorrencia Factory()
        {
            return new Ocorrencia
                ("Descrição da ocorrencia", new App.ValueObjects.Foto("foto.jpg"),
                false, Guid.NewGuid(), Guid.NewGuid(), "Nome do Morador", Guid.NewGuid(), false);
        }

        public static Ocorrencia Criar_Ocorrencia_Valida()
        {
            return Factory();
        }

        public static Ocorrencia Criar_Ocorrencia_EmAndamento_Valido()
        {
            var ocorrencia = Factory();

            var resposta = RespostaOcorrenciaFactoryTests.Criar_RespostaOcorrencia_Sindico_Valida();
            ocorrencia.AdicionarRespostaDeSindico(resposta, StatusDaOcorrencia.EM_ANDAMENTO);

            return ocorrencia;
        }

        public static Ocorrencia Criar_Ocorrencia_Resolvida_Valido()
        {
            var ocorrencia = Factory();

            var resposta = RespostaOcorrenciaFactoryTests.Criar_RespostaOcorrencia_Sindico_Valida();
            ocorrencia.AdicionarRespostaDeSindico(resposta, StatusDaOcorrencia.RESOLVIDA);

            return ocorrencia;
        }
    }
}
