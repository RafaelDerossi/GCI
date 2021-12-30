using System;
using System.Collections.Generic;
using GCI.Core.Helpers;
using FluentValidation.Results;
using GCI.Core.Messages.CommonMessages;

namespace GCI.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDeAlteracao { get; private set; }
        public bool Lixeira { get; private set; }

        protected ValidationResult ValidationResult { get; private set; } = new ValidationResult();



        private List<DomainEvent> _notificacoes;
        public IReadOnlyCollection<DomainEvent> Notificacoes => _notificacoes?.AsReadOnly();

        public void AdicionarEventoDeDominio(DomainEvent evento)
        {
            _notificacoes = _notificacoes ?? new List<DomainEvent>();
            _notificacoes.Add(evento);
        }
        public void RemoverEventoDeDominio(DomainEvent eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }
        public void LimparEventosDeDominio()
        {
            _notificacoes?.Clear();
        }


        private List<Event> _mensagens;
        public IReadOnlyCollection<Event> Mensagens => _mensagens?.AsReadOnly();

        public void AdicionarEvento(Event evento)
        {
            _mensagens = _mensagens ?? new List<Event>();
            _mensagens.Add(evento);
        }
        public void RemoverEvento(Event eventItem)
        {
            _mensagens?.Remove(eventItem);
        }
        public void LimparEventos()
        {
            _mensagens?.Clear();
        }


        protected void AdicionarErrosDaEntidade(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty,mensagem));
        }

        public string DataDeAlteracaoFormatada
        {
            get
            {
                if (DataDeAlteracao != null)
                    return DataDeAlteracao.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public string DataDeCadastroFormatada
        {
            get
            {
                if (DataDeCadastro != null)
                    return DataDeCadastro.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public void SetEntidadeId(Guid NovoId) => Id = NovoId;

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public Entity()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DataHoraDeBrasilia.Get();
            DataDeAlteracao = DataHoraDeBrasilia.Get();
        }

        #region Comparações

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}
