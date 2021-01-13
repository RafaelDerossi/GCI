using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Domain.FlatModel
{
    public class VisitaFlat : Entity
    {
        public const int Max = 200;       

        public DateTime DataDeEntrada { get; private set; }
        public bool Terminada { get; private set; }
        public DateTime DataDeSaida { get; private set; }


        public string NomeCondomino { get; private set; }
        public string Observacao { get; private set; }
        public StatusVisita Status
        {
            get
            {
                if (Status == StatusVisita.PENDENTE && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                    return StatusVisita.EXPIRADA;

                if (Status == StatusVisita.APROVADA && DataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
                    return StatusVisita.EXPIRADA;

                return Status;
            }
            private set
            { }
        }


        public Guid VisitanteId { get; private set; }
        public string NomeVisitante { get; private set; }
        public TipoDeDocumento TipoDeDocumentoVisitante { get; private set; }
        public string RgVisitante { get; private set; }
        public string CpfVisitante { get; private set; }
        public string EmailVisitante { get; private set; }
        public string FotoVisitante { get; private set; }
        public TipoDeVisitante TipoDeVisitante { get; private set; }
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





        /// Construtores       
        protected VisitaFlat()
        {                  
        }

        public VisitaFlat(
            DateTime dataDeEntrada, string nomeCondomino,
            string observacao, StatusVisita status, Guid visitanteId, string nomeVisitante,
            TipoDeDocumento tipoDeDocumentoVisitante, string rgVisitante, string cpfVisitante,
            string emailVisitante, string fotoVisitante,TipoDeVisitante tipoDeVisitante,
            string nomeEmpresaVisitante, Guid condominioId,
            string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string descricaoGrupoUnidade, bool temVeiculo,
            string placaVeiculo, string modeloVeiculo, string corVeiculo)
        {
            DataDeEntrada = dataDeEntrada;
            NomeCondomino = nomeCondomino;
            Observacao = observacao;
            Status = status;
            VisitanteId = visitanteId;
            NomeVisitante = nomeVisitante;
            TipoDeDocumentoVisitante = tipoDeDocumentoVisitante;
            RgVisitante = rgVisitante;
            CpfVisitante = cpfVisitante;
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
        }



        /// Metodos Set      
        public void AprovarVisita() => Status = StatusVisita.APROVADA;
        public void ReprovarVisita() => Status = StatusVisita.REPROVADA;


        public void IniciarVisita()
        {
            Status = StatusVisita.INICIADA;
            DataDeEntrada = DataHoraDeBrasilia.Get();
        }
        public void TerminarVisita()
        { 
            Status = StatusVisita.TERMINADA;
            DataDeSaida = DataHoraDeBrasilia.Get();
        }


        public void SetDataDeEntrada(DateTime dataDeEntrada) => DataDeEntrada = dataDeEntrada;
        public void SetNomeCondomino(string nome) => NomeCondomino = nome;
        public void SetNomeVisitante(string nome) => NomeVisitante = nome;
        public void SetTipoDocumentoVisitante(TipoDeDocumento tipoDeDocumento) => TipoDeDocumentoVisitante = tipoDeDocumento;
        public void SetRgVisitante(string rg) => RgVisitante = rg;
        public void SetCpfVisitante(string cpf) => CpfVisitante = cpf;
        public void SetEmailVisitante(string email) => EmailVisitante = email;
        public void SetFotoVisitante(string foto) => FotoVisitante = foto;
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
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

    }
}
