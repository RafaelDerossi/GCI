using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitaAdicionadaEvent : VisitaEvent
    {

        public VisitaAdicionadaEvent
            (Guid id, DateTime dataDeEntrada, string observacao, StatusVisita status,
            Guid visitanteId, string nomeVisitante,TipoDeDocumento tipoDeDocumento, string documento, Email email,
            Foto foto,TipoDeVisitante tipoDeVisitante, string nomeEmpresa, Guid condominioId, string nomeCondominio,
            Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade, bool temVeiculo,
            Veiculo veiculo, Guid usuarioId, string nomeUsuario)
        {
            Id = id;
            SetDataDeEntrada(dataDeEntrada);
            Observacao = observacao;
            Status = status;
            SetVisitanteId(visitanteId);
            NomeVisitante = nomeVisitante;
            SetDocumentoVisitante(documento, tipoDeDocumento);            
            SetEmailVisitante(email);
            SetFotoVisitante(foto);
            SetTipoDeVisitante(tipoDeVisitante);
            SetNomeEmpresaVisitante(nomeEmpresa);
            SetCondominioId(condominioId);
            SetNomeDoCondominio(nomeCondominio);
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
