using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Events
{
   public class EnqueteCadastradaEvent : EnqueteEvent
    {

        public EnqueteCadastradaEvent(string descricao, DateTime dataInicio, DateTime dataFim,
            Guid condominioId, string condominioNome, Guid usuarioId, string usuarioNome,
            bool apenasProprietarios, IEnumerable<string> alternativas )
        {            
            Descricao = descricao;
            CondominioId = condominioId;
            CondominioNome = condominioNome;
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            ApenasProprietarios = apenasProprietarios;

            DataInicio = dataInicio;
            DataFim = dataFim;
            Alternativas = alternativas;
        }       

    }
}
