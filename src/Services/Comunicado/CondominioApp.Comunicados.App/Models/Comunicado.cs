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


        public Guid FuncionarioId { get; private set; }

        public string NomeFuncionario { get; private set; }

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
            Guid funcionarioId, string nomeFuncionario, VisibilidadeComunicado visibilidade,
            CategoriaComunicado categoria, bool temAnexos, bool criadoPelaAdministradora)
        {
            _Unidades = new List<UnidadeComunicado>();

            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Visibilidade = visibilidade;
            Categoria = categoria;
            TemAnexos = temAnexos;
            CriadoPelaAdministradora = criadoPelaAdministradora;
        }



        ///Metodos Set

        public void SetTitulo(string titulo) => Titulo = titulo;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetDataDeRealizacao(DateTime? dataDeRealizacao) => DataDeRealizacao = dataDeRealizacao;

        public void SetFuncionario(Guid funcionarioId, string nomeFuncionario)
        {
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
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


        public ValidationResult Editar(string titulo, string descricao, DateTime? dataDeRealizacao, Guid funcionarioId,
            string nomeFuncionario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            IEnumerable<UnidadeComunicado> unidades)
        {
            SetTitulo(titulo);
            SetDescricao(descricao);
            SetDataDeRealizacao(dataDeRealizacao);
            SetFuncionario(funcionarioId, nomeFuncionario);          
            SetVisibilidade(visibilidade);
            SetCategoria(categoria);

            RemoverTodasUnidade();

            AdicionarUnidades(unidades);
            
            return ValidationResult;
        }


        public void EnviarPushNovoComunicado()
        {
            var titulo = ObterTituloDoPush();
            var descricao = ObterDescricaoDoPush();


            if (Visibilidade == VisibilidadeComunicado.PUBLICO)
            {
                AdicionarEvento
                   (new EnviarPushParaCondominioIntegrationEvent(CondominioId, titulo, descricao));
                return;
            }               


            if (Visibilidade == VisibilidadeComunicado.UNIDADES)
            {
                var lista = ObterIdsDasUnidades();
                AdicionarEvento
                        (new EnviarPushParaUnidadesIntegrationEvent(lista, titulo, descricao));
                return;
            }


            if (Visibilidade == VisibilidadeComunicado.PROPRIETARIOS)
            {
                AdicionarEvento
                    (new EnviarPushParaProprietariosIntegrationEvent(CondominioId, titulo, descricao));
                return;
            }                
           

            if (Visibilidade == VisibilidadeComunicado.PROPRIETARIOS_UNIDADES)
            {
                var lista = ObterIdsDasUnidades();
                AdicionarEvento
                   (new EnviarPushParaProprietariosPorUnidadeIntegrationEvent(lista, titulo, descricao));
            }
               
         

        }

        private string ObterTituloDoPush()
        {
            switch (Categoria)
            {
                case CategoriaComunicado.COMUNICADO:
                    return "COMUNICADO";
                case CategoriaComunicado.ATA:
                    return "ATA";
                case CategoriaComunicado.URGENCIA:
                    return "URGÊNCIA";
                case CategoriaComunicado.BALANCETE:
                    return "BALANCETE";
                case CategoriaComunicado.COBRANÇA:
                    return "COBRANÇA";
                case CategoriaComunicado.MANUTENÇÃO:
                    return "MANUTENÇÃO";
                case CategoriaComunicado.AVISO:
                    return "AVISO";
                case CategoriaComunicado.OBRA_REFORMA:
                    return "OBRA/REFORMA";                    
                default:
                    return Titulo;
            }
        }
        private string ObterDescricaoDoPush()
        {
            switch (Categoria)
            {   
                case CategoriaComunicado.OUTROS:
                    return Descricao;
                default:
                    return $"{Titulo} - {Descricao}";
            }
        }
        private IEnumerable<Guid> ObterIdsDasUnidades()
        {
            var lista = new List<Guid>();
            foreach (var item in Unidades)
            {
                lista.Add(item.UnidadeId);
            }
            return lista;
        }
    }
}
