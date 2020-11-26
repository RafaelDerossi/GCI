using System;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.ValueObjects;
using FluentValidation;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioAlteradoEvent : CondominioEvent
    {
      
        public CondominioAlteradoEvent(Guid id, DateTime dataDeCadastro, DateTime dataDeAlteracao,
           Cnpj cnpj, string nome, string descricao, Foto logoMarca,
           Telefone telefone, Endereco endereo)            
        {
            CondominioId = id;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeAlteracao;          
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
            Endereco = endereo;            
        }


    }
}