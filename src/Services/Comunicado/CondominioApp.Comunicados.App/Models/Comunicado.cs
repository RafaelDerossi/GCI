using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;

namespace CondominioApp.Comunicados.App.Models
{
   public class Comunicado : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime? DataDeRealizacao { get; private set; }

        public Guid CondominioId { get; private set; }

        public string NomeCondominio { get; private set; }


        public Guid UsuarioId { get; private set; }

        public string NomeUsuario { get; private set; }

        public VisibilidadeComunicado  Visibilidade { get; private set; }

        public CategoriaComunicado Categoria { get; private set; }

        public bool TemAnexos { get; private set; }       

        public bool CriadoPelaAdministradora { get; private set; }


        private readonly List<UnidadeComunicado> _Unidades;
        public IReadOnlyCollection<UnidadeComunicado> Unidades => _Unidades;


        /// Construtores
        protected Comunicado()
        {
            _Unidades = new List<UnidadeComunicado>();
        }

        public Comunicado
            (string titulo, string descricao, DateTime? dataDeRealizacao, Guid condominioId, string nomeCondominio,
            Guid usuarioId, string nomeUsuario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            bool temAnexos, bool criadoPelaAdministradora)
        {
            _Unidades = new List<UnidadeComunicado>();

            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Visibilidade = visibilidade;
            Categoria = categoria;
            TemAnexos = temAnexos;
            CriadoPelaAdministradora = criadoPelaAdministradora;
        }



        ///Metodos Set

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetDataDeRealizacao(DateTime? dataDeRealizacao) => DataDeRealizacao = dataDeRealizacao;

        public void SetUsuario(Guid usuarioId, string nomeUsuario)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
        }

        public void SetVisibilidade(VisibilidadeComunicado visibilidade) => Visibilidade = visibilidade;

        public void SetCategoria(CategoriaComunicado categoria) => Categoria = categoria;

        public void SetCriadoPelaAdministradora() => CriadoPelaAdministradora = true;


        public ValidationResult AdicionarUnidades(IEnumerable<UnidadeComunicado> unidades)
        {
            if (Visibilidade == VisibilidadeComunicado.UNIDADES || Visibilidade == VisibilidadeComunicado.PROPRIETARIOS_UNIDADES)
            {
                if (unidades == null || unidades.Count() == 0)
                {
                    AdicionarErrosDaEntidade("Informe uma ou mais unidades.");
                    return ValidationResult;
                }

                foreach (UnidadeComunicado unidade in unidades)
                {
                    var resultado = AdicionarUnidade(unidade);
                    if (!resultado.IsValid)
                        return resultado;
                }
            }
            return ValidationResult;
        }

        private ValidationResult AdicionarUnidade(UnidadeComunicado unidade)
        {

            if (_Unidades.Any(u => u.UnidadeId == unidade.UnidadeId))
            {
                AdicionarErrosDaEntidade("Unidade repetida!");
                return ValidationResult;
            }

            _Unidades.Add(unidade);

            return ValidationResult;
        }

        private void RemoverTodasUnidade()
        {
            _Unidades.Clear();
        }


        public ValidationResult Editar(string titulo, string descricao, DateTime? dataDeRealizacao, Guid usuarioId,
            string nomeUsuario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            IEnumerable<UnidadeComunicado> unidades)
        {
            SetTitulo(titulo);
            SetDescricao(descricao);
            SetDataDeRealizacao(dataDeRealizacao);
            SetUsuario(usuarioId, nomeUsuario);          
            SetVisibilidade(visibilidade);
            SetCategoria(categoria);

            RemoverTodasUnidade();

            AdicionarUnidades(unidades);
            
            return ValidationResult;
        }


        public void EnviarPushNovoComunicado()
        {
            var titulo = "NOVO COMUNICADO";
            var descricao = $"{Titulo} - {Descricao}";

            if (Visibilidade == VisibilidadeComunicado.PUBLICO)
                AdicionarEvento
                    (new EnviarPushParaCondominioIntegrationEvent(CondominioId, titulo, descricao));

            if (Visibilidade == VisibilidadeComunicado.UNIDADES)
            {
                foreach (var item in Unidades)
                {
                    AdicionarEvento
                        (new EnviarPushParaUnidadeIntegrationEvent(item.UnidadeId, titulo, descricao));
                }
            }

            if (Visibilidade == VisibilidadeComunicado.PROPRIETARIOS)
                AdicionarEvento
                    (new EnviarPushParaProprietariosIntegrationEvent(CondominioId, titulo, descricao));
           

            if (Visibilidade == VisibilidadeComunicado.PROPRIETARIOS_UNIDADES)
            {
                foreach (var item in Unidades)
                {
                    AdicionarEvento
                        (new EnviarPushParaProprietariosPorUnidadeIntegrationEvent(item.UnidadeId, titulo, descricao));
                }
            }

        }
    }
}
