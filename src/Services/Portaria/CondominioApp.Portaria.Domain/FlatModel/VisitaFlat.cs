using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Domain.FlatModel
{
    public class VisitaFlat
    {
        public const int Max = 200;

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public DateTime DataDeEntrada { get; private set; }       
        public DateTime DataDeSaida { get; private set; }
        public string Status { get; private set; }
        public string Observacao { get; private set; }
        
        

        public Guid VisitanteId { get; private set; }
        public string NomeVisitante { get; private set; }
        public string TipoDeDocumentoVisitante { get; private set; }
        public string DocumentoVisitante { get; private set; }       
        public string EmailVisitante { get; private set; }
        public string FotoVisitante { get; private set; }
        public string TipoDeVisitante { get; private set; }
        public string NomeEmpresaVisitante { get; private set; }


        public Guid CondominioId { get; private set; }
        public string NomeCondominio { get; private set; }

        public Guid UnidadeId { get; private set; }
        public string NumeroUnidade { get; private set; }
        public string AndarUnidade { get; private set; }
        public string GrupoUnidade { get; private set; }

        public bool TemVeiculo { get; private set; }
        public string PlacaVeiculo { get; private set; }
        public string ModeloVeiculo { get; private set; }
        public string CorVeiculo { get; private set; }


        public Guid UsuarioId { get; private set; }

        public string NomeUsuario { get; private set; }



        /// Construtores       
        protected VisitaFlat()
        {                  
        }

        public VisitaFlat(
            Guid id, DateTime dataDeEntrada, string observacao, string status,
            Guid visitanteId, string nomeVisitante, string tipoDeDocumentoVisitante,
            string documentoVisitante, string emailVisitante, string fotoVisitante,
            string tipoDeVisitante, string nomeEmpresaVisitante, Guid condominioId,
            string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string descricaoGrupoUnidade, bool temVeiculo,
            string placaVeiculo, string modeloVeiculo, string corVeiculo,
            Guid usuarioId, string nomeUsuario)
        {
            Id = id;
            DataDeEntrada = dataDeEntrada;            
            Observacao = observacao;
            Status = status;
            VisitanteId = visitanteId;
            NomeVisitante = nomeVisitante;            
            EmailVisitante = emailVisitante;
            FotoVisitante = fotoVisitante;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresaVisitante = nomeEmpresaVisitante;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = descricaoGrupoUnidade;
            TemVeiculo = temVeiculo;
            PlacaVeiculo = placaVeiculo;
            ModeloVeiculo = modeloVeiculo;
            CorVeiculo = corVeiculo;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            SetDocumentoVisitante(documentoVisitante, tipoDeDocumentoVisitante);
        }



        /// Metodos Set    

        public void EnviarParaLixeira() => Lixeira = true;
        public void RestaurarDaLixeira() => Lixeira = false;


        public void AprovarVisita() => Status = StatusVisita.APROVADA.ToString();
        public void ReprovarVisita() => Status = StatusVisita.REPROVADA.ToString();


        public void IniciarVisita(DateTime dataDeEntrada)
        {
            Status = StatusVisita.INICIADA.ToString();
            DataDeEntrada = dataDeEntrada;
        }
        public void TerminarVisita(DateTime dataDeSaida)
        { 
            Status = StatusVisita.TERMINADA.ToString();
            DataDeSaida = dataDeSaida;
        }

        public void SetVisitanteId(Guid id) => VisitanteId = id;
        public void SetObservacao(string observacao) => Observacao = observacao;
        public void SetDataDeEntrada(DateTime dataDeEntrada) => DataDeEntrada = dataDeEntrada;       
        public void SetNomeVisitante(string nome) => NomeVisitante = nome;
        public void SetDocumentoVisitante(string documento, string tipoDeDocumento)
        {
            TipoDeDocumentoVisitante = tipoDeDocumento;
            DocumentoVisitante = documento;
        }
        public void SetEmailVisitante(string email) => EmailVisitante = email;
        public void SetFotoVisitante(string foto) => FotoVisitante = foto;
        public void SetTipoDeVisitante(string tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
        public void SetNomeEmpresaVisitante(string nomeEmpresa) => NomeEmpresaVisitante = nomeEmpresa;

        public void MarcarTemVeiculo() => TemVeiculo = true;
        public void MarcarNaoTemVeiculo() => TemVeiculo = false;
        public void SetPlacaVeiculo(string placa) => PlacaVeiculo = placa;
        public void SetModeloVeiculo(string modelo) => ModeloVeiculo = modelo;
        public void SetCorVeiculo(string cor) => CorVeiculo = cor;


        public void SetUnidadeId(Guid id) => UnidadeId = id;
        public void SetNumeroUnidade(string numero) => NumeroUnidade = numero;
        public void SetAndarUnidade(string andar) => AndarUnidade = andar;
        public void SetGrupoUnidade(string grupo) => GrupoUnidade = grupo;

        public void SetUsuario(Guid id, string nome)
        {
            UsuarioId = id;
            NomeUsuario = nome;
        }

        public string ObterStatus()
        {
            if (Status == "PENDENTE" && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                return "EXPIRADA";

            if (Status == "APROVADA" && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                return "EXPIRADA";

            return Status;
        }
    }
}
