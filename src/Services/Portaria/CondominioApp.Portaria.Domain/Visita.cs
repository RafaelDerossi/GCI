using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Domain
{
    public class Visita : Entity
    {
        public const int Max = 200;       

        public DateTime DataDeEntrada { get; private set; }      
        public DateTime DataDeSaida { get; private set; }
        public StatusVisita Status { get; private set; }
        public string Observacao { get; private set; }
      

        public Guid VisitanteId { get; private set; }
        public string NomeVisitante { get; private set; }
        public TipoDeDocumento TipoDeDocumentoVisitante { get; private set; }
        public string Documento { get; private set; }       
        public Email EmailVisitante { get; private set; }
        public Foto FotoVisitante { get; private set; }
        public TipoDeVisitante TipoDeVisitante { get; private set; }
        public string NomeEmpresaVisitante { get; private set; }


        public Guid CondominioId { get; private set; }
        public string NomeCondominio { get; private set; }

        public Guid UnidadeId { get; private set; }
        public string NumeroUnidade { get; private set; }
        public string AndarUnidade { get; private set; }
        public string GrupoUnidade { get; private set; }

        public Veiculo Veiculo { get; private set; }


        public Guid UsuarioId { get; private set; }
        public string NomeUsuario { get; private set; }


        /// Construtores       
        protected Visita()
        {                  
        }

        public Visita(
            DateTime dataDeEntrada, string observacao, StatusVisita status, Guid visitanteId,
            string nomeVisitante, TipoDeDocumento tipoDeDocumentoVisitante, string documento,
            Email emailVisitante, Foto fotoVisitante,TipoDeVisitante tipoDeVisitante,
            string nomeEmpresaVisitante, Guid condominioId, string nomeCondominio, Guid unidadeId,
            string numeroUnidade, string andarUnidade, string descricaoGrupoUnidade, Veiculo veiculo,
            Guid usuarioId, string nomeUsuario)
        {
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
            Veiculo = veiculo;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            SetDocumentoVisitante(documento, tipoDeDocumentoVisitante);
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


        public void SetObservacao(string observacao) => Observacao = observacao;
        public void SetDataDeEntrada(DateTime dataDeEntrada) => DataDeEntrada = dataDeEntrada;
        public void SetVisitanteId(Guid id) => VisitanteId = id;
        public void SetNomeVisitante(string nome) => NomeVisitante = nome;
        public void SetDocumentoVisitante(string documento, TipoDeDocumento tipoDeDocumento)
        {
            TipoDeDocumentoVisitante = tipoDeDocumento;
            Documento = documento;
        }       
        public void SetEmailVisitante(Email email) => EmailVisitante = email;
        public void SetFotoVisitante(Foto foto) => FotoVisitante = foto;
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
        public void SetNomeEmpresaVisitante(string nomeEmpresa) => NomeEmpresaVisitante = nomeEmpresa;
        public void SetVeiculo(Veiculo veiculo) => Veiculo = veiculo;

        public void SetUnidadeId(Guid id) => UnidadeId = id;
        public void SetNumeroUnidade(string numero) => NumeroUnidade = numero;
        public void SetAndarUnidade(string andar) => AndarUnidade = andar;
        public void SetGrupoUnidade(string grupo) => GrupoUnidade = grupo;

        public void SetUsuario(Guid usuarioId, string nome)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nome;
        }

        /// Outros Metodos 
        public bool TemVeiculo
        {
            get
            {
                if (Veiculo != null)
                {
                    return true;
                }
                return false;
            }
        }


        public StatusVisita ObterStatus()
        {
            if (Status == StatusVisita.PENDENTE && DataDeEntrada.Date<DataHoraDeBrasilia.Get().Date)
                    return StatusVisita.EXPIRADA;

                if (Status == StatusVisita.APROVADA && DataDeEntrada.Date<DataHoraDeBrasilia.Get().Date)
                    return StatusVisita.EXPIRADA;

                return Status;
        }
    }
}
