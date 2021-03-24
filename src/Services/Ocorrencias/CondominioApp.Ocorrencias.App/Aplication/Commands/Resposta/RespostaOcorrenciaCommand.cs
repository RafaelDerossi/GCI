using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public abstract class RespostaOcorrenciaCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid OcorrenciaId { get; protected set; }
        public string Descricao { get; protected set; }
        public TipoDoAutor TipoAutor { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public string NomeUsuario { get; protected set; }
        public bool Visto { get; protected set; }
        public Foto Foto { get; protected set; }       
        public StatusDaOcorrencia Status { get; protected set; }        
        
        


        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFoto(string nomeOriginalfoto, string nomeFoto)
        {
            try
            {
                Foto = new Foto(nomeOriginalfoto, nomeFoto);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetUsuarioId(Guid id) => UsuarioId = id;

        public void MarcarComoVisto() => Visto = true;

        public void SetStatus(StatusDaOcorrencia status) => Status = status;


    }
}
