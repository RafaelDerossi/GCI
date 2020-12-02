using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Events
{
    public class UnidadeEditadaEvent : UnidadeEvent
    {
        public UnidadeEditadaEvent(Guid id, DateTime dataDeAlteracao,
            string unidadeNumero, string unidadeAndar, int unidadeVagas, string unidadeTelefone,
            string unidadeRamal, string unidadeComplemento)
        {
            UnidadeId = id;
            DataDeAlteracao = dataDeAlteracao;           
            Numero = unidadeNumero;
            Andar = unidadeAndar;
            Vaga = unidadeVagas;
            Telefone = unidadeTelefone;
            Ramal = unidadeRamal;
            Complemento = unidadeComplemento;           
        }

    }
}
