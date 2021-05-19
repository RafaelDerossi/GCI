using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.Models;
using System;
using System.Collections.Generic;

namespace CondominioApp.Ocorrencias.App.ViewModels
{
    public class OcorrenciaViewModel 
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public bool Lixeira { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        public bool Publica { get; set; }

        public StatusDaOcorrencia Status { get; set; }                

        public DateTime? DataResolucao { get; set; }

        public Guid UnidadeId { get; set; }

        public Guid MoradorId { get; set; }

        public string NomeMorador { get; set; }

        public string FotoMorador { get; set; }

        public Guid CondominioId { get; set; }       
        
        public bool Panico { get;  set; }              

        public string StatusDescricao
        {
            get
            {
                if (Status == StatusDaOcorrencia.RESOLVIDA)
                    return "Resolvida";
                else if (Status == StatusDaOcorrencia.EM_ANDAMENTO)
                    return "Em andamento";
                else
                    return "Pendente";
            }
        }        

    }
}
