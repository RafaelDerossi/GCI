using System;
using CondominioApp.Principal.Domain.ValueObjects;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioEditadoEvent : CondominioEvent
    {
      
        public CondominioEditadoEvent(Guid id,
           Cnpj cnpj, string nome, string descricao, Telefone telefone, Endereco endereo)            
        {
            CondominioId = id;        
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;            
            Telefone = telefone;
            Endereco = endereo;            
        }
    }
}