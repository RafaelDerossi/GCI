using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class GrupoCadastradoEvent : GrupoEvent
    {

        public GrupoCadastradoEvent(Guid grupoId, DateTime dataDeCadastro, DateTime dataDeAlteracao,
            string descricao, Guid condominioId, string condominioCnpj, string condominioNome,
            string condominioLogoMarca)
        {
            GrupoId = grupoId;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeAlteracao;           
            Descricao = descricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioLogoMarca = condominioLogoMarca;
        }

    }
}
