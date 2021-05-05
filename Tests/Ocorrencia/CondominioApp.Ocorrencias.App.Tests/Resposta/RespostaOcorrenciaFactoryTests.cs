using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Ocorrencias.App.Tests
{
   public class RespostaOcorrenciaFactoryTests
    {
        private static RespostaOcorrencia FactorySindico()
        {
            return new RespostaOcorrencia
                (Guid.NewGuid(), "Descrição da Resposta", TipoDoAutor.ADMINISTRACAO,
                Guid.NewGuid(), "Nome do Usuario", false, new Foto("imagem.jpg","imagem.jpg"));
        }
        private static RespostaOcorrencia FactoryMorador()
        {
            return new RespostaOcorrencia
                (Guid.NewGuid(), "Descrição da Resposta", TipoDoAutor.MORADOR,
                Guid.NewGuid(), "Nome do Usuario", false, new Foto("imagem.jpg", "imagem.jpg"));
        }

        public static RespostaOcorrencia Criar_RespostaOcorrencia_Sindico_Valida()
        {
            return FactorySindico();
        }

        public static RespostaOcorrencia Criar_RespostaOcorrencia_Morador_Valido()
        {
            return FactoryMorador();
        }

       
    }
}
