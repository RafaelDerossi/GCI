using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitanteAtualizadoEvent : VisitanteEvent
    {

        public VisitanteAtualizadoEvent
            (Guid id, string nome, TipoDeDocumento tipoDeDocumento, string documento, Email email, Foto foto,
            bool visitantePermanente, TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo)
        {
            Id = id;
            SetDocumento(documento, tipoDeDocumento);
            SetNome(nome);           
            SetEmail(email);
            SetFoto(foto);
            VisitantePermanente = visitantePermanente;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;           
        }

    }
}
