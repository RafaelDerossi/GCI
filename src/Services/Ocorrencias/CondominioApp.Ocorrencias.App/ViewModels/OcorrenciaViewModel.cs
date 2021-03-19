using CondominioApp.Ocorrencias.App.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Ocorrencias.App.Models
{
    public class OcorrenciaViewModel 
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public bool Lixeira { get; set; }

        public string Descricao { get; set; }

        public Foto Foto { get; set; }

        public bool Publica { get; set; }

        public bool EmAndamento { get; set; }

        public DateTime? DataResposta { get; set; }

        public bool Resolvida { get; set; }        

        public string Parecer { get; set; }

        public DateTime? DataResolucao { get; set; }

        public Guid UnidadeId { get; set; }

        public Guid UsuarioId { get; set; }    
        
        public Guid CondominioId { get; set; }       
        
        public bool Panico { get;  set; }              

        public string status
        {
            get
            {
                if (!EmAndamento && !Resolvida)
                    return "Pendente";
                else if (Resolvida)
                    return "Resolvida";
                else
                    return "Em andamento";
            }
        }
    }
}
