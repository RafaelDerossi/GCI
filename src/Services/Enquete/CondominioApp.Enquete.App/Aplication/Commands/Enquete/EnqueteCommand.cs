using CondominioApp.Core.Messages;
using CondominioApp.Enquetes.App.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
    public abstract class EnqueteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }


        public Guid CondominioId { get; protected set; }
        public string CondominioNome { get; protected set; }

        public bool ApenasProprietarios { get; protected set; }

        public Guid UsuarioId { get; protected set; }
        public string UsuarioNome { get; protected set; }

        public IEnumerable<CadastraAlternativaEnqueteViewModel> Alternativas { get; private set; }

        public void SetDataInicio(DateTime data)
        {
            if (data < DateTime.Now.Date) AdicionarErrosDeProcessamentoDoComando("Data inicial não pode ser menor que a data de hoje!");

            DataInicio = data;
        }

        public void SetDataFim(DateTime data)
        {
            if (data < DateTime.Now.Date) AdicionarErrosDeProcessamentoDoComando("Data final não pode ser menor que a data de hoje!");

            DataFim = data;
        }

        public void SetAlternativas(IEnumerable<CadastraAlternativaEnqueteViewModel> alternativas)
        {
            Alternativas = new List<CadastraAlternativaEnqueteViewModel>();

            if (alternativas==null || alternativas.Count() < 2) 
                AdicionarErrosDeProcessamentoDoComando("Uma enquete precisa ter pelo menos duas alternativas!");            
                       
            Alternativas = alternativas;
        }
    }
}
