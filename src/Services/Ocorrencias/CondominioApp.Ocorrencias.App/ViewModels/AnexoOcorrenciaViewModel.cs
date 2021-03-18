using System;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class AnexoOcorrenciaViewModel
    {
        public string NomeOriginal { get; set; }

        public int Tamanho { get; set; }        

        public Guid UsuarioId { get; set; }        

        public string Titulo { get; set; }

        public string Descricao { get; set; }

    }
}
