using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
   public class CondominioDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string LogoMarca { get; set; }

        public string Telefone { get; set; }

        public CondominioDTO(Guid id, string nome, string descricao, string logoMarca, string telefone)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            Telefone = telefone;
        }
    }
}
