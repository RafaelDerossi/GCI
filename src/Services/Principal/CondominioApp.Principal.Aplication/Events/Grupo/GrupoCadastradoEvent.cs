using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoCadastradoEvent : GrupoEvent
    {

        public GrupoCadastradoEvent(Guid grupoId,
            string descricao, Guid condominioId, string condominioCnpj, string condominioNome,
            string condominioLogo)
        {
            GrupoId = grupoId;      
            Descricao = descricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioLogo = condominioLogo;
        }

    }
}
