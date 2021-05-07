using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Enquetes.App.Models;
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

        public Guid FuncionarioId { get; protected set; }
        public string FuncionarioNome { get; protected set; }

        public IEnumerable<AlternativaEnquete> Alternativas { get; private set; }

        public void SetDataInicio(DateTime data)
        {
            if (data < DateTime.Now.Date)
                AdicionarErrosDeProcessamentoDoComando("Informe uma data inicial posterior ou igual a data de hoje!");            

            DataInicio = data;
        }

        public void SetDataFim(DateTime data)
        {
            if (data.Date < DataHoraDeBrasilia.Get().Date)
                AdicionarErrosDeProcessamentoDoComando("Informe uma data final posterior ou igual a data de hoje.");

            DataFim = data;
        }

        public void SetAlternativas(IEnumerable<AlternativaEnquete> alternativas)
        {
            Alternativas = new List<AlternativaEnquete>();

            if (alternativas==null || alternativas.Count() < 2) 
                AdicionarErrosDeProcessamentoDoComando("Uma enquete precisa ter pelo menos duas alternativas!");            
                       
            Alternativas = alternativas;
        }

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetCondominioId(Guid id) => CondominioId = id;

        public void SetFuncionarioId(Guid id) => FuncionarioId = id;

    }
}
