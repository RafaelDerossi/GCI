using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.ValueObjects;
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
        public Rg RgVisitante { get; protected set; }
        public Cpf CpfVisitante { get; protected set; }
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

        public Guid UsuarioId { get; protected set; }
        public string NomeUsuario { get; protected set; }


        public void SetDocumentoVisitante(string documento)
        {
            if (!string.IsNullOrEmpty(documento))
            {
                if (documento.Length == 14)
                {
                    SetCPFVisitante(documento);                   
                    return;
                }
                
                SetRgVisitante(documento);                
                return;
            }
            
            RgVisitante = new Rg("");
            CpfVisitante = new Cpf("");
            TipoDeDocumentoVisitante = TipoDeDocumento.OUTROS;
            
        }
        private void SetRgVisitante(string rg)
        {
            try
            {
                TipoDeDocumentoVisitante = TipoDeDocumento.RG;
                RgVisitante = new Rg(rg);
                CpfVisitante = new Cpf("");
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
        private void SetCPFVisitante(string cpf)
        {
            try
            {
                TipoDeDocumentoVisitante = TipoDeDocumento.CPF;
                CpfVisitante = new Cpf(cpf);
                RgVisitante = new Rg("");
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

        public void SetFotoVisitante(string nomeOriginal, string nome)
        {
            try
            {
                FotoVisitante = new Foto(nomeOriginal, nome);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void MarcarQueTemVeiculo() => TemVeiculo = true;
        public void MarcarQueNaoTemVeiculo() => TemVeiculo = false;
        public void SetVeiculo(string placa, string modelo, string cor)
        {
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

        public void SetDataDeEntrada(DateTime dataDeEntrada) => DataDeEntrada = dataDeEntrada;

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

        public void SetUsuario(Guid usuarioId, string nome)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nome;
        }
    }
}
