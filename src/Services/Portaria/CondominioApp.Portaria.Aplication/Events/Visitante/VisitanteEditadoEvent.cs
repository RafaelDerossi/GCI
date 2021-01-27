using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitanteEditadoEvent : VisitanteEvent
    {

        public VisitanteEditadoEvent
            (Guid id, string nome, TipoDeDocumento tipoDeDocumento, string documento, Email email, Foto foto, bool visitantePermanente,
            TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo)
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
