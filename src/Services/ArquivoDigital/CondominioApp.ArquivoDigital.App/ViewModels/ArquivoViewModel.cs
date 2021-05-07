using CondominioApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.ArquivoDigital.App.Models
{
  public class ArquivoViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public bool Lixeira { get; set; }

        public string NomeArquivo { get; set; }

        public string NomeOriginal { get; set; }

        public string Extensao { get; set; }

        public int Tamanho { get; set; }

        public Guid CondominioId { get; set; }

        public Guid PastaId { get; set; }

        public bool Publico { get; set; }

        public Guid FuncionarioId { get; set; }

        public string NomeFuncionario { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

    }
}
