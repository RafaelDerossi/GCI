using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarEmailComunicadoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }        

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }
        
        public Guid FuncionarioId { get; private set; }        

        public VisibilidadeComunicado Visibilidade { get; private set; }

        public CategoriaComunicado Categoria { get; private set; }

        public bool TemAnexos { get; private set; }

        public Guid CondominioId { get; private set; }

        public IEnumerable<Guid> UnidadesIds { get; private set; }

        public EnviarEmailComunicadoIntegrationEvent
            (Guid id, string titulo, string descricao, Guid funcionarioId,
             VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
             bool temAnexos, Guid condominioId, IEnumerable<Guid> unidadesIds)
        {
            Id = id;            
            Titulo = titulo;
            Descricao = descricao;            
            FuncionarioId = funcionarioId;            
            Visibilidade = visibilidade;
            Categoria = categoria;
            TemAnexos = temAnexos;
            CondominioId = condominioId;
            UnidadesIds = unidadesIds;
        }

    }
}