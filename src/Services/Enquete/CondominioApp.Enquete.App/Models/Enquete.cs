using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Enquetes.App.Models
{
   public class Enquete : Entity, IAggregateRoot
    {
        public const int Max = 200;
        public string Descricao { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }


        public Guid CondominioId { get; private set; }
        public string CondominioNome { get; set; }

        public bool ApenasProprietarios { get; set; }
                
        public Guid UsuarioId { get; private set; }
        public string UsuarioNome { get; set; }


        private readonly List<AlternativaEnquete> _Alternativas;
        public IReadOnlyCollection<AlternativaEnquete> Alternativas => _Alternativas;
        

        public Enquete()
        {
            _Alternativas = new List<AlternativaEnquete>();
        }
        public Enquete(string descricao,
                       DateTime dataInicio,
                       DateTime dataFim,
                       Guid condominioId,
                       string condominioNome,
                       bool apenasProprietarios,
                       Guid usuarioId,
                       string usuarioNome,
                       IEnumerable<string> alternativas)
        {
            _Alternativas = new List<AlternativaEnquete>();
            ApenasProprietarios = apenasProprietarios;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            CondominioId = condominioId;
            CondominioNome = condominioNome;
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;           
        }

        public void SetDataInicial(DateTime data) => DataInicio = data;

        public void SetDataFim(DateTime data) => DataFim = data;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;

        public void SetUsuarioNome(string usuarioNome) => UsuarioNome = usuarioNome;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetCondominioNome(string condominioNome) => CondominioNome = condominioNome;

        public void SetApenasProprietarios(bool apenasProprietarios) => ApenasProprietarios = apenasProprietarios;        

        public ValidationResult AdicionarAlternativa(AlternativaEnquete alternativa)
        {           
            if (_Alternativas.Any(g => g.Descricao.Trim().ToUpper() == alternativa.Descricao.Trim().ToUpper()))
            {
                AdicionarErrosDaEntidade("Alternativas Repetidas!");
                return ValidationResult;
            }
            
            _Alternativas.Add(alternativa);
            return ValidationResult;
        }

        public ValidationResult AlterarAlternativa(AlternativaEnquete alternativa)
        {
            if (_Alternativas.Any(g => g.Descricao.Trim().ToUpper() == alternativa.Descricao.Trim().ToUpper() && g.Id != alternativa.Id))
            {
                AdicionarErrosDaEntidade("Ja existe uma alternativa com esta descrição!");
                return ValidationResult;
            }
            
            _Alternativas.Remove(alternativa);
            _Alternativas.Add(alternativa);

            return ValidationResult;
        }


        public int ObterQuantidadeDeVotos
        {
            get{
                int qtdVotos = 0;
                foreach (AlternativaEnquete alternativa in _Alternativas)
                {
                    if (alternativa.Respostas != null)
                        qtdVotos += alternativa.Respostas.Count;
                }
                return qtdVotos;
            }            
        }

        public bool EnqueteAtiva
        {
            get
            {
                if (DataInicio <= DataHoraDeBrasilia.Get() && DataFim >= DataHoraDeBrasilia.Get())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }
    }
}
