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
        private static RespostaOcorrencia FactoryAdministrador()
        {
            return new RespostaOcorrencia
                (Guid.NewGuid(), "Descrição da Resposta", TipoDoAutor.ADMINISTRACAO,
                Guid.NewGuid(), "Nome do Funcionario", false, new Foto("imagem.jpg"),
                new NomeArquivo("anexo.pdf", Guid.NewGuid()));
        }
        private static RespostaOcorrencia FactoryMorador()
        {
            return new RespostaOcorrencia
                (Guid.NewGuid(), "Descrição da Resposta", TipoDoAutor.MORADOR,
                 Guid.NewGuid(), "Nome do Usuario", false, new Foto("imagem.jpg"),
                 new NomeArquivo("anexo.pdf", Guid.NewGuid()));
        }

        public static RespostaOcorrencia Criar_RespostaOcorrencia_Sindico_Valida()
        {
            return FactoryAdministrador();
        }

        public static RespostaOcorrencia Criar_RespostaOcorrencia_Morador_Valido()
        {
            return FactoryMorador();
        }

       
    }
}
