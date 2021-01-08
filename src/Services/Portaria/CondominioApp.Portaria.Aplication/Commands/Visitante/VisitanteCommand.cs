using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

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



        protected void SetDocumento(string documento)
        {
            if (!string.IsNullOrEmpty(documento))
            {
                if (documento.Length == 14)
                {
                    SetCPF(documento);
                    Rg = null;
                    
                }                    
                else
                {
                    SetRg(documento);
                    Cpf = null;
                }                    
            }
            else
            {
                Rg = null;
                Cpf = null;
            }               
        }
        private void SetRg(string rg)
        {
            try
            {
                Rg = new Rg(rg);
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
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        protected void SetEmail(string email)
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

        protected void SetFoto(string nomeOriginal, string nome)
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

        protected void SetVeiculo(string placa, string modelo, string cor)
        {
            try
            {
                Veiculo = new Veiculo(placa,modelo,cor);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
        
    }
}
