using CondominioApp.Core.DomainObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Enquetes.App.Models
{
   public class AlternativaEnquete : Entity
    {
        public string Descricao { get; private set; }   
        
        public Guid EnqueteId { get; private set; }

        
        private readonly List<RespostaEnquete> _Respostas;
        public IReadOnlyCollection<RespostaEnquete> Respostas => _Respostas;

        public AlternativaEnquete()
        {
            _Respostas = new List<RespostaEnquete>();
        }
        public AlternativaEnquete(string descricao, Guid enqueteId)
        {
            _Respostas = new List<RespostaEnquete>();
            Descricao = descricao;
            EnqueteId = enqueteId;
        }

        public void SetDescricao(string descricao) => Descricao = descricao;
                
        public ValidationResult AdicionarResposta(RespostaEnquete resposta)
        {
            _Respostas.Add(resposta);
            return ValidationResult;
        }

        public ValidationResult AlterarResposta(RespostaEnquete resposta)
        {
            _Respostas.Remove(resposta);
            _Respostas.Add(resposta);

            return ValidationResult;
        }
    }
}
