using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Correspondencias.App.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public abstract class CorrespondenciaCommand : Command
    {
        public Guid CorrespondenciaId { get; protected set; }

        public Guid UnidadeId { get; protected set; }

        public string NumeroUnidade { get; protected set; }

        public string Bloco { get; protected set; }

        public bool Visto { get; protected set; }

        public string NomeRetirante { get; protected set; }

        public string Observacao { get; protected set; }

        public DateTime DataDaRetirada { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public string NomeUsuario { get; protected set; }

        public Foto Foto { get; protected set; }

        public string NumeroRastreamentoCorreio { get; protected set; }

        public DateTime DataDeChegada { get; protected set; }

        public int QuantidadeDeAlertasFeitos { get; protected set; }

        public string TipoDeCorrespondencia { get; protected set; }

        public StatusCorrespondencia Status { get; protected set; }

        public void SetFoto(string foto, string nomeOriginal)
        {
            try
            {
                Foto = new Foto(nomeOriginal, foto);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        
    }
}
