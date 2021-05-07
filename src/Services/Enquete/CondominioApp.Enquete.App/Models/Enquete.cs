using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Enquete;
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
                
        public Guid FuncionarioId { get; private set; }
        public string FuncionarioNome { get; set; }


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
                       Guid funcionarioId,
                       string funcionarioNome)
        {
            _Alternativas = new List<AlternativaEnquete>();
            ApenasProprietarios = apenasProprietarios;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            CondominioId = condominioId;
            CondominioNome = condominioNome;
            FuncionarioId = funcionarioId;
            FuncionarioNome = funcionarioNome;           
        }

        public void SetDataInicial(DateTime data) => DataInicio = data;

        public ValidationResult SetDataFim(DateTime data)
        {
            if (DataFim.Date < DataHoraDeBrasilia.Get().Date)
                AdicionarErrosDaEntidade("Data de término não pode ser alterada pois a enquete já foi encerrada");            

            if (ValidationResult.IsValid)
                DataFim = data;

            return ValidationResult;
        }

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFuncionarioId(Guid id) => FuncionarioId = id;

        public void SetFuncionarioNome(string nome) => FuncionarioNome = nome;

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
            
            _Alternativas.RemoveAll(a=>a.Id == alternativa.Id);
            _Alternativas.Add(alternativa);

            return ValidationResult;
        }

        public ValidationResult RemoverAlternativa(AlternativaEnquete alternativa)
        {
            if (Alternativas.Where(a => !a.Lixeira).Count() < 3)
            {
                AdicionarErrosDaEntidade("Uma enquete precisa ter pelo menos duas alternativas.");
                return ValidationResult;
            }             

            _Alternativas.Remove(alternativa);          

            return ValidationResult;
        }

        public void RemoverTodasAsAlternativa()
        {           
            _Alternativas.Clear();
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

        public bool UsuarioJaVotou(Guid usuarioId)
        {
            foreach (AlternativaEnquete alternativa in _Alternativas)
            {
                if (alternativa.Respostas.Any(r => r.UsuarioId == usuarioId))
                    return true;
            }
            return false;
        }

        public ValidationResult Editar
            (string descricao, DateTime dataInicio, DateTime dataFim, bool apenasProprietarios)
        {
            if (ObterQuantidadeDeVotos > 0)
                AdicionarErrosDaEntidade("A descrição, data de início, se é ou não apenas para proprietários e as alternativas não podem mais serem editados pois a enquete já tem voto(s)!");
                             

            SetDescricao(descricao);
            SetDataInicial(dataInicio);
            SetDataFim(dataFim);
            SetApenasProprietarios(apenasProprietarios);            

            return ValidationResult;
        }


        public void EnviarEmailNovaEnquete()
        {
            List<string> AlternativaS_STR = new List<string>();
            var alternativasOrdenadas =_Alternativas.OrderBy(a => a.Ordem);
            foreach (var item in alternativasOrdenadas)
            {
                AlternativaS_STR.Add(item.Descricao);
            }
            AdicionarEvento
                (new EnviarEmailEnqueteIntegrationEvent
                (Descricao, DataInicio.ToShortDateString(), DataFim.ToShortDateString(), CondominioId,
                 FuncionarioNome, ApenasProprietarios, AlternativaS_STR));
            return;
        }
    }
}
