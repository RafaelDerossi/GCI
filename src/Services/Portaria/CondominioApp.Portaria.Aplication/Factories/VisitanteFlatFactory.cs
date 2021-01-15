using CondominioApp.Portaria.Aplication.Events;
using CondominioApp.Portaria.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.Factories
{
   public class VisitanteFlatFactory : IVisitanteFlatFactory
    {
        public VisitanteFlat Fabricar(VisitanteEvent notification)
        {
            return new VisitanteFlat
               (notification.Id, notification.Nome, notification.TipoDeDocumento, notification.Rg.Numero,
               notification.Cpf.Numero, notification.Email.Endereco, notification.Foto.NomeDoArquivo,
               notification.CondominioId, notification.NomeCondominio, notification.UnidadeId,
               notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
               notification.VisitantePermanente, notification.QrCode, notification.TipoDeVisitante,
               notification.NomeEmpresa, notification.TemVeiculo, notification.Veiculo.Placa,
               notification.Veiculo.Modelo, notification.Veiculo.Cor);
        }

        public VisitanteFlat Fabricar(VisitaEvent notification)
        {
            return new VisitanteFlat
                (notification.VisitanteId, notification.NomeVisitante, notification.TipoDeDocumentoVisitante,
                notification.RgVisitante.Numero, notification.CpfVisitante.Numero, notification.EmailVisitante.Endereco,
                notification.FotoVisitante.NomeDoArquivo, notification.CondominioId, notification.NomeCondominio,
                notification.UnidadeId, notification.NumeroUnidade, notification.AndarUnidade, notification.GrupoUnidade,
                false, "", notification.TipoDeVisitante, notification.NomeEmpresaVisitante, notification.TemVeiculo,
                notification.Veiculo.Placa, notification.Veiculo.Modelo, notification.Veiculo.Cor);
        }

       
    }
}
