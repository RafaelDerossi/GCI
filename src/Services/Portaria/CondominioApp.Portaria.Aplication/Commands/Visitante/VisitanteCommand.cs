using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
    public abstract class VisitanteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }
        public TipoDeDocumento TipoDeDocumento { get; protected set; }
        public Rg Rg { get; protected set; }
        public Cpf Cpf { get; protected set; }
        public Email Email { get; protected set; }
        public Foto Foto { get; protected set; }

        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }

        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string GrupoUnidade { get; protected set; }

        public bool VisitantePermanente { get; protected set; }
        public string QrCode { get; protected set; }
        public TipoDeVisitante TipoDeVisitante { get; protected set; }
        public string NomeEmpresa { get; protected set; }

        public bool TemVeiculo { get; protected set; }
        public Veiculo Veiculo { get; protected set; }



        public void SetDocumento(string documento)
        {
            if (!string.IsNullOrEmpty(documento))
            {
                if (documento.Length == 14)
                {
                    SetCPF(documento);
                    TipoDeDocumento = TipoDeDocumento.CPF;
                    return;
                }                    
                
                SetRg(documento);
                TipoDeDocumento = TipoDeDocumento.RG;
                return;                                   
            }
            
            Rg = new Rg("");
            Cpf = new Cpf("");
            TipoDeDocumento = TipoDeDocumento.OUTROS;            
        }

        private void SetRg(string rg)
        {
            try
            {
                Rg = new Rg(rg);
                Cpf = new Cpf("");
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
                Cpf = new Cpf(cpf);
                Rg = new Rg("");
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetEmail(string email)
        {
            try
            {
                Email = new Email(email);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetFoto(string nomeOriginal, string nome)
        {
            try
            {
                Foto = new Foto(nomeOriginal, nome);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

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

        public void SetNome(string nome) => Nome = nome;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;
        public void SetNomeCondominio(string nomeCondominio) => NomeCondominio = nomeCondominio;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;
        public void SetNumeroUnidade(string numero) => NumeroUnidade = numero;
        public void SetAndarDaUnidade(string andar) => AndarUnidade = andar;
        public void SetGrupoDaUnidade(string grupo) => GrupoUnidade = grupo;

        public void MarcarQueTemVeiculo() => TemVeiculo = true;
        public void MarcarQueNaoTemVeiculo() => TemVeiculo = false;
    }
}
