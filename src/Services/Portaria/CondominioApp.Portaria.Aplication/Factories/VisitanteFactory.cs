using CondominioApp.Portaria.Aplication.Commands;
using CondominioApp.Portaria.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.Factories
{
   public class VisitanteFactory : IVisitanteFactory
    {
        public Visitante Fabricar(VisitanteCommand request)
        {
            return new Visitante
                (request.Nome, request.TipoDeDocumento, request.Rg, request.Cpf, request.Email,
                 request.Foto, request.CondominioId, request.NomeCondominio, request.UnidadeId,
                 request.NumeroUnidade, request.AndarUnidade, request.GrupoUnidade, request.VisitantePermanente,
                 request.QrCode, request.TipoDeVisitante, request.NomeEmpresa, request.Veiculo);
        }

        public Visitante Fabricar(VisitaCommand request)
        {
            return new Visitante
                (request.NomeVisitante, request.TipoDeDocumentoVisitante, request.RgVisitante,
                request.CpfVisitante, request.EmailVisitante, request.FotoVisitante, request.CondominioId,
                request.NomeCondominio, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                request.GrupoUnidade, false, "", request.TipoDeVisitante, request.NomeEmpresaVisitante, request.Veiculo);
        }

       
    }
}
