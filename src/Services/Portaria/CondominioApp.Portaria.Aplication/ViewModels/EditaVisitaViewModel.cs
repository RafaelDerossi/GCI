using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Portaria.Aplication.ViewModels
{
   public class EditaVisitaViewModel
    {
        public Guid Id { get; set; }              
        public string Observacao { get; set; }

        public Guid VisitanteId { get; set; }
        public string NomeVisitante { get; set; }
        public TipoDeDocumento TipoDoDocumento { get; set; }
        public string Documento { get; set; }       
        public string EmailVisitante { get; set; }
        public string FotoVisitante { get; set; }
        public string NomeOriginalFotoVisitante { get; set; }
        public TipoDeVisitante TipoDeVisitante { get; set; }
        public string NomeEmpresaVisitante { get; set; }
                
        public Guid UnidadeId { get; set; }
        public string NumeroUnidade { get; set; }
        public string AndarUnidade { get; set; }
        public string GrupoUnidade { get; set; }

        public bool TemVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string CorVeiculo { get; set; }

        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }

    }
}
