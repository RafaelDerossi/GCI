using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.ViewModels
{
   public class CadastraVisitanteViewModel
    {
        public string Nome { get; set; }       
        public string Documento { get; set; }       
        public string Email { get; set; }
        public string Foto { get; set; }
        public string NomeOriginalFoto { get; set; }

        public Guid CondominioId { get; set; }
        public string NomeCondominio { get; set; }

        public Guid UnidadeId { get; set; }
        public string NumeroUnidade { get; set; }
        public string AndarUnidade { get; set; }
        public string GrupoUnidade { get; set; }

        public bool VisitantePermanente { get; set; }
        public string QrCode { get; set; }
        public TipoDeVisitante TipoDeVisitante { get; set; }
        public string NomeEmpresa { get; set; }

        public bool TemVeiculo { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
    }
}
