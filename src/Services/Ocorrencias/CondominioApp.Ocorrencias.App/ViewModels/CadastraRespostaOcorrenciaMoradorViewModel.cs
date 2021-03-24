using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class CadastraRespostaOcorrenciaMoradorViewModel
    {
        public Guid OcorrenciaId { get; set; }

        public string Descricao { get; set; }        

        public Guid UsuarioId { get; set; }                

        public string FotoNome { get; set; }

        public string FotoNomeOriginal { get; set; }        

    }
}
