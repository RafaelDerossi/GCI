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

        public StatusVisita Status { get; private set; }
        public string DescricaoStatus
        {
            get
            {
                if (Status == StatusVisita.PENDENTE && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                    return "Expirada";

                if (Status == StatusVisita.APROVADA && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                    return "Expirada";

                if (Status == StatusVisita.PENDENTE)
                    return "Pendente";

                return DescricaoStatus;
            }
            private set { }
        }    

        public string Observacao { get; private set; }
        
        

        public Guid VisitanteId { get; private set; }
        public string NomeVisitante { get; private set; }

        public TipoDeDocumento TipoDeDocumentoVisitante { get; private set; }
        public string DescricaoTipoDeDocumentoVisitante { get; private set; }

        public string DocumentoVisitante { get; private set; }       
        public string EmailVisitante { get; private set; }
        public string FotoVisitante { get; private set; }

        public TipoDeVisitante TipoDeVisitante { get; private set; }
        public string DescricaoTipoDeVisitante { get; private set; }

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

        public VisitaFlat
            (Guid id, DateTime dataDeEntrada, string observacao, Guid visitanteId, string nomeVisitante,
             TipoDeDocumento tipoDeDocumentoVisitante, string documentoVisitante, string emailVisitante,
             string fotoVisitante, TipoDeVisitante tipoDeVisitante, string nomeEmpresaVisitante,
             Guid condominioId, string nomeCondominio, Guid unidadeId, string numeroUnidade, 
             string andarUnidade, string grupoUnidade, bool temVeiculo, string placaVeiculo,
             string modeloVeiculo, string corVeiculo, Guid usuarioId, string nomeUsuario)
        {
            Id = id;
            DataDeEntrada = dataDeEntrada;
            Observacao = observacao;
            VisitanteId = visitanteId;
            NomeVisitante = nomeVisitante;            
            EmailVisitante = emailVisitante;
            FotoVisitante = fotoVisitante;            
            NomeEmpresaVisitante = nomeEmpresaVisitante;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            TemVeiculo = temVeiculo;
            PlacaVeiculo = placaVeiculo;
            ModeloVeiculo = modeloVeiculo;
            CorVeiculo = corVeiculo;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;

            SetDocumentoVisitante(documentoVisitante, tipoDeDocumentoVisitante);
            SetTipoDeVisitante(tipoDeVisitante);
        }

        


        /// Metodos Set    

        public void EnviarParaLixeira() => Lixeira = true;
        public void RestaurarDaLixeira() => Lixeira = false;


        public void MarcarVisitaComoPendente()
        {
            Status = StatusVisita.PENDENTE;
            DescricaoStatus = "Pendente";
        }

        public void AprovarVisita()
        {
            Status = StatusVisita.APROVADA;
            DescricaoStatus = "Aprovada";
        }
        public void ReprovarVisita()
        {
            Status = StatusVisita.REPROVADA;
            DescricaoStatus = "Reprovada";
        }


        public void IniciarVisita(DateTime dataDeEntrada)
        {
            Status = StatusVisita.INICIADA;
            DescricaoStatus = "Iniciada";
            DataDeEntrada = dataDeEntrada;
        }
        public void TerminarVisita(DateTime dataDeSaida)
        { 
            Status = StatusVisita.TERMINADA;
            DescricaoStatus = "Terminada";
            DataDeSaida = dataDeSaida;
        }


        public void SetVisitanteId(Guid id) => VisitanteId = id;
        public void SetObservacao(string observacao) => Observacao = observacao;
        public void SetDataDeEntrada(DateTime dataDeEntrada) => DataDeEntrada = dataDeEntrada;       
        public void SetNomeVisitante(string nome) => NomeVisitante = nome;

        public void SetDocumentoVisitante(string documento,TipoDeDocumento tipoDeDocumento)
        {
            DocumentoVisitante = documento;
            TipoDeDocumentoVisitante = tipoDeDocumento;
            DescricaoTipoDeDocumentoVisitante = tipoDeDocumento switch
            {
                TipoDeDocumento.CPF => "CPF",
                TipoDeDocumento.CNPJ => "CNPJ",
                TipoDeDocumento.RG => "RG",
                TipoDeDocumento.OUTROS => "Outros",
                _ => "Outros",
            };
        }

        public void SetEmailVisitante(string email) => EmailVisitante = email;
        public void SetFotoVisitante(string foto) => FotoVisitante = foto;

        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante)
        {
            TipoDeVisitante = tipoDeVisitante;
            switch (tipoDeVisitante)
            {
                case TipoDeVisitante.PARTICULAR:
                    DescricaoTipoDeVisitante = "Particular";
                    break;
                case TipoDeVisitante.SERVICO:
                    DescricaoTipoDeVisitante = "Serviço";
                    break;
                default:
                    break;
            }
        }
        
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

    }
}
