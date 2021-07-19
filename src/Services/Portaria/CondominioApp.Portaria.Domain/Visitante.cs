using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace CondominioApp.Portaria.Domain
{
    public class Visitante : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Nome { get; private set; }
        public TipoDeDocumento TipoDeDocumento { get; private set; }
        public string Documento { get; private set; }       
        public Email Email { get; private set; }
        public Foto Foto { get; private set; }
        public Guid CondominioId { get; private set; }
        public Guid UnidadeId { get; private set; }
        public bool VisitantePermanente { get; private set; }
        public string QrCode { get; private set; }
        public TipoDeVisitante TipoDeVisitante { get; private set; }
        public string NomeEmpresa { get; private set; }
        public bool TemVeiculo { get; private set; }
        public Guid CriadorId { get; set; }
        public string NomeDoCriador { get; set; }
        public TipoDeUsuario TipoDeUsuarioDoCriador { get; set; }


        private readonly List<Visita> _Visitas;
        public IReadOnlyCollection<Visita> Visitas => _Visitas;





        /// Construtores       
        protected Visitante()
        {
            _Visitas = new List<Visita>();
        }

        public Visitante(string nome, TipoDeDocumento tipoDeDocumento, string documento,
            Email email, Foto foto, Guid condominioId, Guid unidadeId, bool visitantePermanente,
            string qrCode, TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo)
        {
            _Visitas = new List<Visita>();
            Nome = nome;                      
            Email = email;
            Foto = foto;
            CondominioId = condominioId;
            UnidadeId = unidadeId;
            VisitantePermanente = visitantePermanente;
            QrCode = qrCode;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;
            SetDocumento(documento, tipoDeDocumento);
        }






        /// Metodos Set
        public void SetNome(string nome) => Nome = nome;                  
        public void SetEmail(Email email) => Email = email;
        public void SetFoto(Foto foto) => Foto = foto;
        public void SetQrCode(string qrCode) => QrCode = qrCode;
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
        public void SetNomeEmpresa(string nomeEmpresa) => NomeEmpresa = nomeEmpresa;
        
        public void MarcarTemVeiculo() => TemVeiculo = true;
        public void MarcarNaoTemVeiculo() => TemVeiculo = false;

        public void MarcarVisitanteComoPermanente() => VisitantePermanente = true;
        public void MarcarVisitanteComoTemporario() => VisitantePermanente = false;


        public void SetDocumento(string documento, TipoDeDocumento tipoDeDocumento)
        {
            TipoDeDocumento = tipoDeDocumento;
            Documento = documento;
        }

        /// Outros Metodos 


    }
}
