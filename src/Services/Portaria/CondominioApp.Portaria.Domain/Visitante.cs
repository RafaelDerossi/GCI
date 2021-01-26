using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.ValueObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Domain
{
    public class Visitante : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Nome { get; private set; }
        public TipoDeDocumento TipoDeDocumento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }       
        public Email Email { get; private set; }
        public Foto Foto { get; private set; }

        public Guid CondominioId { get; private set; }
        public string NomeCondominio { get; private set; }

        public Guid UnidadeId { get; private set; }
        public string NumeroUnidade { get; private set; }
        public string AndarUnidade { get; private set; }
        public string GrupoUnidade { get; private set; }

        public bool VisitantePermanente { get; private set; }
        public string QrCode { get; private set; }
        public TipoDeVisitante TipoDeVisitante { get; private set; }
        public string NomeEmpresa { get; private set; }


        public bool TemVeiculo { get; private set; }



        private readonly List<Visita> _Visitas;
        public IReadOnlyCollection<Visita> Visitas => _Visitas;





        /// Construtores       
        protected Visitante()
        {
            _Visitas = new List<Visita>();
        }

        public Visitante(string nome, TipoDeDocumento tipoDeDocumento, Rg rg, Cpf cpf,
            Email email, Foto foto, Guid condominioId, string nomeCondominio, Guid unidadeId, string numeroUnidade,
            string andarUnidade, string grupoUnidade, bool visitantePermanente, string qrCode,
            TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo)
        {
            _Visitas = new List<Visita>();
            Nome = nome;
            TipoDeDocumento = tipoDeDocumento;
            Rg = rg;
            Cpf = cpf;
            Email = email;
            Foto = foto;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            VisitantePermanente = visitantePermanente;
            QrCode = qrCode;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;            
        }






        /// Metodos Set
        public void SetNome(string nome) => Nome = nome;
        public void SetTipoDeDocumento(TipoDeDocumento tipoDeDocumento) => TipoDeDocumento = tipoDeDocumento;
        public void SetRg(Rg rg) => Rg = rg;
        public void SetCpf(Cpf cpf) => Cpf = cpf;       
        public void SetEmail(Email email) => Email = email;
        public void SetFoto(Foto foto) => Foto = foto;
        public void SetQrCode(string qrCode) => QrCode = qrCode;
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
        public void SetNomeEmpresa(string nomeEmpresa) => NomeEmpresa = nomeEmpresa;
        public void MarcarTemVeiculo() => TemVeiculo = true;
        public void MarcarNaoTemVeiculo() => TemVeiculo = false;

        public void MarcarVisitanteComoPermanente() => VisitantePermanente = true;
        public void MarcarVisitanteComoTemporario() => VisitantePermanente = false;






        /// Outros Metodos 
    

    }
}
