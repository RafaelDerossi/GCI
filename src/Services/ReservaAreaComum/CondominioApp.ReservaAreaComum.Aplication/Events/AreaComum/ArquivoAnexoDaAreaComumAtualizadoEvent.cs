using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
    public class ArquivoAnexoDaAreaComumAtualizadoEvent : AreaComumEvent
    {
        public ArquivoAnexoDaAreaComumAtualizadoEvent(
            Guid id, string nomeOriginalArquivoAnexo, string nomeArquivoAnexo)
        {
            Id = id;
            NomeOriginalArquivoAnexo = nomeOriginalArquivoAnexo;
            NomeArquivoAnexo = nomeArquivoAnexo;
        }

    }
}
