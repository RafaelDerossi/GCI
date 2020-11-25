using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class UnidadeCadastradaEvent : UnidadeEvent
    {
        public UnidadeCadastradaEvent(Guid id, DateTime dataDeCadastro, DateTime dataDeAlteracao, bool lixeira,
            string unidadeCodigo, string unidadeNumero, string unidadeAndar,
            int unidadeVagas, string unidadeTelefone, string unidadeRamal, string unidadeComplemento,
            Guid grupoId, string grupoDescricao, Guid condominioId, string condominioCnpj, string condominioNome,
            string condominioLogoMarca)
        {
            UnidadeId = id;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeAlteracao;
            Lixeira = lixeira;
            Codigo = unidadeCodigo;
            Numero = unidadeNumero;
            Andar = unidadeAndar;
            Vaga = unidadeVagas;
            Telefone = unidadeTelefone;
            Ramal = unidadeRamal;
            Complemento = unidadeComplemento;
            GrupoId = grupoId;
            GrupoDescricao = grupoDescricao;
            CondominioId = condominioId;
            CondominioCnpj = condominioCnpj;
            CondominioNome = condominioNome;
            CondominioLogoMarca = condominioLogoMarca;
        }

    }
}
