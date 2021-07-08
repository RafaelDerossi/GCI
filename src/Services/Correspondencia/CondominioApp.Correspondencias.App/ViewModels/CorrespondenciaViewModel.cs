using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class CorrespondenciaViewModel
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public Guid CondominioId { get; set; }

        public Guid UnidadeId { get; set; }

        public string NumeroUnidade { get; set; }

        public string Bloco { get; set; }

        public bool Visto { get; set; }

        public string Observacao { get; set; }       

        public Guid FuncionarioId { get; set; }

        public string NomeFuncionario { get; set; }

        public string NomeArquivoFoto { get;  set; }

        public string NomeOriginalFoto { get; set; }

        public string NumeroRastreamentoCorreio { get; set; }

        public string DataDeChegada { get; set; }

        public int QuantidadeDeAlertasFeitos { get; set; }

        public string TipoDeCorrespondencia { get; set; }

        public string Status { get; set; }

        public string NomeRetirante { get; set; }

        public string NomeArquivoFotoRetirante { get; set; }

        public string NomeOriginalFotoRetirante { get; set; }

        public string DataDaRetirada { get; private set; }

        public string Localizacao { get; set; }       

        public bool EnviarNotificacao { get; set; }

        public bool Lixeira { get; set; }

    }
}
