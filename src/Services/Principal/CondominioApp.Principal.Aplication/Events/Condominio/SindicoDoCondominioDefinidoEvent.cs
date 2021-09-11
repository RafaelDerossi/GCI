using System;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class SindicoDoCondominioDefinidoEvent : CondominioEvent
    {
      
        public SindicoDoCondominioDefinidoEvent(Guid condominioId, Guid funcionarioIdDoSindico, string nomeDoSindico)            
        {
            CondominioId = condominioId;
            FuncionarioIdDoSindico = funcionarioIdDoSindico;
            NomeDoSindico = nomeDoSindico;
        }


    }
}