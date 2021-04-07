using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarEmailComunicadoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime? DataDeRealizacao { get; private set; }

        public Guid FuncionarioId { get; private set; }

        public string NomeFuncionario { get; private set; }

        public VisibilidadeComunicado Visibilidade { get; private set; }

        public CategoriaComunicado Categoria { get; private set; }

        public bool TemAnexos { get; private set; }

        public Guid CondominioId { get; private set; }

        public IEnumerable<Guid> UnidadesIds { get; private set; }

        public EnviarEmailComunicadoIntegrationEvent
            (Guid id, DateTime dataDeCadastro, string titulo, string descricao, DateTime? dataDeRealizacao,
             Guid funcionarioId, string nomeFuncionario, VisibilidadeComunicado visibilidade,
             CategoriaComunicado categoria, bool temAnexos, Guid condominioId, IEnumerable<Guid> unidadesIds)
        {
            Id = id;
            DataDeCadastro = dataDeCadastro;
            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Visibilidade = visibilidade;
            Categoria = categoria;
            TemAnexos = temAnexos;
            CondominioId = condominioId;
            UnidadesIds = unidadesIds;
        }

    }
}