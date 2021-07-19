using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitanteAdicionadoEvent : VisitanteEvent
    {

        public VisitanteAdicionadoEvent
            (Guid id, string nome,TipoDeDocumento tipoDeDocumento, string documento, Email email, Foto foto, Guid condominioId,
            string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade,
            bool visitantePermanente, string qrCode, TipoDeVisitante tipoDeVisitante, string nomeEmpresa,
            bool temVeiculo)
        {
            Id = id;
            SetNome(nome);
            SetDocumento(documento, tipoDeDocumento);
            SetEmail(email);
            SetFoto(foto);
            SetCondominioId(condominioId);
            SetNomeCondominio(nomeCondominio);
            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarDaUnidade(andarUnidade);
            SetGrupoDaUnidade(grupoUnidade);
            VisitantePermanente = visitantePermanente;
            QrCode = qrCode;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;           
        }

    }
}
