using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaAtualizadaEvent : VisitaEvent
    {

        public VisitaAtualizadaEvent
            (Guid id,string observacao, string nomeVisitante, TipoDeDocumento tipoDeDocumento,
            string documento, Email email, Foto foto, TipoDeVisitante tipoDeVisitante, string nomeEmpresa,
            Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade, bool temVeiculo,
            Veiculo veiculo, Guid usuarioId, string nomeUsuario)
        {
            Id = id;
            Observacao = observacao;
            NomeVisitante = nomeVisitante;
            SetDocumentoVisitante(documento, tipoDeDocumento);
            SetEmailVisitante(email);
            SetFotoVisitante(foto);
            SetTipoDeVisitante(tipoDeVisitante);
            SetNomeEmpresaVisitante(nomeEmpresa);
            SetUnidadeId(unidadeId);
            SetNumeroUnidade(numeroUnidade);
            SetAndarUnidade(andarUnidade);
            SetGrupoUnidade(grupoUnidade);
            TemVeiculo = temVeiculo;
            SetVeiculo(veiculo);
            SetUsuario(usuarioId, nomeUsuario);
        }

    }
}
