using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.Domain.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
    public abstract class VisitanteCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public TipoDeDocumento TipoDeDocumento { get; protected set; }
        public string Documento { get; protected set; }        
        public Email Email { get; protected set; }
        public Foto Foto { get; protected set; }
        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }
        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string GrupoUnidade { get; protected set; }
        public bool VisitantePermanente { get; protected set; }        
        public TipoDeVisitante TipoDeVisitante { get; protected set; }
        public string NomeEmpresa { get; protected set; }
        public bool TemVeiculo { get; protected set; }
        public Guid CriadorId { get; set; }
        public string NomeDoCriador { get; set; }
        public TipoDeUsuario TipoDeUsuarioDoCriador { get; set; }        


        public void SetDocumento(string documento, TipoDeDocumento tipoDeDocumento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                TipoDeDocumento = TipoDeDocumento.OUTROS;
                Documento = "";
                return;
            }

            TipoDeDocumento = tipoDeDocumento;

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

            Documento = documento;            
        }
        private void SetRg(string rg)
        {
            try
            {
                var _rg = new Rg(rg);
                Documento = _rg.Numero;
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
                Documento = _cpf.Numero;              
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
        public void SetFoto(string nomeOriginal, string nomeArquivo = "")
        {
            if (nomeArquivo == "")
            {
                try
                {
                    Foto = new Foto(nomeOriginal);
                }
                catch (Exception e)
                {
                    AdicionarErrosDeProcessamentoDoComando(e.Message);
                }
            }            
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
