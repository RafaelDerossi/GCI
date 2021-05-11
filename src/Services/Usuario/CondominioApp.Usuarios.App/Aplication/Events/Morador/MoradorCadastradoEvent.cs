using System;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class MoradorCadastradoEvent : MoradorEvent
    {        
        public MoradorCadastradoEvent(Guid id, Guid usuarioId, Guid condominioId, string nomeCondominio,
            Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade,
            bool proprietario = false, bool principal = false)
        {
            Id = id;
            UsuarioId = usuarioId;            

            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;

            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;

            Proprietario = proprietario;
            Principal = principal;                                     
        }
    }
}