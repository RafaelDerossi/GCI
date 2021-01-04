using System;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioEditadoEvent : CondominioEvent
    {
      
        public CondominioEditadoEvent(Guid id,
           Cnpj cnpj, string nome, string descricao, Foto logoMarca,
           Telefone telefone, Endereco endereo)            
        {
            CondominioId = id;        
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
            Endereco = endereo;            
        }


    }
}