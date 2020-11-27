using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Enquetes.App.Models;
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

        public IEnumerable<string> Alternativas { get; private set; }

        protected void SetDataInicio(DateTime data)
        {
            if (data < DateTime.Now.Date) AdicionarErrosDeProcessamentoDoComando("Data inicial não pode ser menor que a data de hoje!");

            DataInicio = data;
        }

        protected void SetDataFim(DateTime data)
        {
            if (data < DateTime.Now.Date) AdicionarErrosDeProcessamentoDoComando("Data final não pode ser menor que a data de hoje!");

            DataFim = data;
        }

        protected void SetAlternativas(IEnumerable<string> alternativas)
        {
            if (alternativas==null || alternativas.Count() < 2) 
                AdicionarErrosDeProcessamentoDoComando("Uma enquete precisa ter pelo menos duas alternativas!");            

            foreach (string alternativa in alternativas)
            {
                if (Alternativas.Any(g => g.Trim().ToUpper() == alternativa.Trim().ToUpper()))
                    AdicionarErrosDeProcessamentoDoComando("Há alternativas repetidas!");                
            }

            Alternativas = alternativas;
        }
    }
}
