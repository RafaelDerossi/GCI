using System.Collections.Generic;
using System.Linq;
using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.ValueObjects;

namespace CondominioAppPreCadastro.App.Models
{
    public class Lead : Entity, IAggregateRoot   
    {
        public const int Max = 1000;

        public string Nome { get; private set; }

        public Email Email { get; private set; }

        public Telefone Telefone { get; private set; }

        public TipoDePlano TipoDePlano { get; private set; }

        public StatusPreCadastro Status { get; private set; }

        public string Motivo { get; private set; }

        
        private readonly List<Condominio> _condominios;

        public IReadOnlyCollection<Condominio> Condominios => _condominios;

        protected Lead() { }

        public Lead(string nome, Email email, Telefone telefone, TipoDePlano tipoDePlano)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoDePlano = tipoDePlano;
            Status = StatusPreCadastro.PENDENTE;
            _condominios = new List<Condominio>();
        }

        public void SetNome(string nome) => Nome = nome;

        public void SetEmail(Email email) => Email = email;

        public void SetTelefone(Telefone telefone) => Telefone = telefone;

        public void SetStatus(StatusPreCadastro statusPreCadastro) => Status = statusPreCadastro;

        public void SetMotivo(string motivo) => Motivo = motivo;

        public void SetPlano(TipoDePlano tipoDePlano) => TipoDePlano = tipoDePlano;

        public void AdicionarCondominio(Condominio condominio)
        {
            if (_condominios.Any(c =>
                c.NomeDoCondominio.Trim().ToUpper() == condominio.NomeDoCondominio.Trim().ToUpper())) return;

            _condominios.Add(condominio);
        }

    }
}