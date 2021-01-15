using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
   public class VisitanteEditadoEvent : VisitanteEvent
    {

        public VisitanteEditadoEvent
            (Guid id, string nome, TipoDeDocumento tipoDeDocumento, Cpf cpf, Rg rg, Email email, Foto foto, bool visitantePermanente,
            TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo, Veiculo veiculo)
        {
            Id = id;
            SetTipoDeDocumento(tipoDeDocumento);
            SetNome(nome);
            SetCPF(cpf);
            SetRg(rg);
            SetEmail(email);
            SetFoto(foto);
            VisitantePermanente = visitantePermanente;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;          
            SetVeiculo(veiculo);
        }

    }
}
