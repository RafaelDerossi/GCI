using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
    public abstract class VisitaCommand : Command
    {
        public Guid Id { get; protected set; }

        public DateTime DataDeEntrada { get; protected set; }
        public bool Terminada { get; protected set; }
        public DateTime DataDeSaida { get; protected set; }
        
        public string Observacao { get; protected set; }
        public StatusVisita Status { get; protected set; }
       

        public Guid VisitanteId { get; protected set; }
        public string NomeVisitante { get; protected set; }
        public TipoDeDocumento TipoDeDocumentoVisitante { get; protected set; }
        public string DocumentoVisitante { get; protected set; }        
        public Email EmailVisitante { get; protected set; }
        public Foto FotoVisitante { get; protected set; }
        public TipoDeVisitante TipoDeVisitante { get; protected set; }       
        public string NomeEmpresaVisitante { get; protected set; }


        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }

        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string GrupoUnidade { get; protected set; }

        public bool TemVeiculo { get; protected set; }
        public Veiculo Veiculo { get; protected set; }

        public Guid MoradorId { get; protected set; }
        public string NomeMorador { get; protected set; }


        public void SetDocumentoVisitante(string documento, TipoDeDocumento tipoDeDocumento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                TipoDeDocumentoVisitante = TipoDeDocumento.OUTROS;
                DocumentoVisitante = "";
                return;
            }

            TipoDeDocumentoVisitante = tipoDeDocumento;

            if (tipoDeDocumento == TipoDeDocumento.CPF)
            {
                SetCPF(documento);
                return;
            }

            if (tipoDeDocumento == TipoDeDocumento.RG)
            {
                SetRg(documento);
                return;
            }

            DocumentoVisitante = documento;
        }
        private void SetRg(string rg)
        {
            try
            {
                var _rg = new Rg(rg);
                DocumentoVisitante = _rg.Numero;
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
        private void SetCPF(string cpf)
        {
            try
            {
                var _cpf = new Cpf(cpf);
                DocumentoVisitante = _cpf.Numero;
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
        public void SetEmailVisitante(string email)
        {
            try
            {
                EmailVisitante = new Email(email);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
        public void SetFotoVisitante(string nomeOriginal, string nomeArquivo = "")
        {
            if (nomeArquivo == "")
            {
                try
                {
                    FotoVisitante = new Foto(nomeOriginal);
                }
                catch (Exception e)
                {
                    AdicionarErrosDeProcessamentoDoComando(e.Message);
                }
            }                
        }                
        public void SetVeiculoPeloPorteiro(bool temVeiculo, string placa, string modelo, string cor)
        {
            TemVeiculo = temVeiculo;
            if (TemVeiculo)
            {
                if (modelo == "")
                {
                    AdicionarErrosDeProcessamentoDoComando("Informe o modelo do veículo.");
                    return;
                }
                if (cor == "")
                {
                    AdicionarErrosDeProcessamentoDoComando("Informe a cor do veículo.");
                    return;
                }
                try
                {
                    Veiculo = new Veiculo(placa, modelo, cor);
                }
                catch (Exception e)
                {
                    AdicionarErrosDeProcessamentoDoComando(e.Message);
                }
                return;
            }

            Veiculo = new Veiculo("", "", "");
        }
        public void SetVeiculoPeloMorador(bool temVeiculo, string placa, string modelo, string cor)
        {
            TemVeiculo = temVeiculo;
            if (TemVeiculo)
            {               
                try
                {
                    Veiculo = new Veiculo(placa, modelo, cor);
                }
                catch (Exception e)
                {
                    AdicionarErrosDeProcessamentoDoComando(e.Message);
                }
                return;
            }

            Veiculo = new Veiculo("", "", "");
        }
        public void SetDataDeEntrada(DateTime dataDeEntrada)
        {
            if (dataDeEntrada.Date < DataHoraDeBrasilia.Get().Date)
            {
                AdicionarErrosDeProcessamentoDoComando("Data de Entrada não pose ser anterior a data de hoje.");
                return;
            }
            DataDeEntrada = dataDeEntrada;
        }
        

        public void AprovarVisita() => Status = StatusVisita.APROVADA;

        public void SetVisitanteId(Guid visitanteId) => VisitanteId = visitanteId;

        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisiante) => TipoDeVisitante = tipoDeVisiante;

        public void SetNomeEmpresaVisitante(string  nomeEmpresaVisitante) => NomeEmpresaVisitante = nomeEmpresaVisitante;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetNomeDoCondominio(string nomeDoCondominio) => NomeCondominio = nomeDoCondominio;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetNumeroUnidade(string numeroUnidade) => NumeroUnidade = numeroUnidade;

        public void SetAndarUnidade(string andarUnidade) => AndarUnidade = andarUnidade;

        public void SetGrupoUnidade(string grupoUnidade) => GrupoUnidade = grupoUnidade;

        public void SetMorador(Guid moradorId, string nome)
        {
            MoradorId = moradorId;
            NomeMorador = nome;
        }
    }
}
