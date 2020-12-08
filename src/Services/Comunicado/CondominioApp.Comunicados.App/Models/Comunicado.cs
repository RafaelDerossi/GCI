using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;

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


        private readonly List<Unidade> _Unidades;
        public IReadOnlyCollection<Unidade> Unidades => _Unidades;


        /// Construtores
        public Comunicado()
        {
            _Unidades = new List<Unidade>();
        }

        public Comunicado
            (string titulo, string descricao, DateTime? dataDeRealizacao, Guid condominioId, string nomeCondominio,
            Guid usuarioId, string nomeUsuario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            bool temAnexos, bool criadoPelaAdministradora)
        {
            _Unidades = new List<Unidade>();

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

        public void SetDataDeRealizacao(DateTime dataDeRealizacao) => DataDeRealizacao = dataDeRealizacao;

        public void SetVisibilidade(VisibilidadeComunicado visibilidade) => Visibilidade = visibilidade;

        public void SetCategoria(CategoriaComunicado categoria) => Categoria = categoria;

        public void SetTemAnexos() => TemAnexos = true;

        public void SetNaoTemAnexos() => TemAnexos = false;

        public void SetCriadoPelaAdministradora() => CriadoPelaAdministradora = true;


        public ValidationResult AdicionarUnidade(Unidade unidade)
        {

            if (_Unidades.Any(u => u.Numero == unidade.Numero && u.Andar == unidade.Andar &&
                                   u.GrupoId == unidade.GrupoId))
            {
                AdicionarErrosDaEntidade("Esta unidade ja esta na lista!");
                return ValidationResult;
            }

            _Unidades.Add(unidade);

            return ValidationResult;
        }

        public ValidationResult AlterarUnidade(Unidade unidade)
        {
            if (_Unidades.Any(u => u.Numero == unidade.Numero && u.Andar == unidade.Andar &&
                                   u.GrupoId == unidade.GrupoId && u.Id != unidade.Id))
            {
                AdicionarErrosDaEntidade("Esta unidade ja esta na lista!");
                return ValidationResult;
            }


            _Unidades.Remove(unidade);
            _Unidades.Add(unidade);

            return ValidationResult;

        }
    }
}
