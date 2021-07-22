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
        public Guid AutorId { get; protected set; }
        public string NomeDoAutor { get; protected set; }
        public bool Visto { get; protected set; }
        public Foto Foto { get; protected set; }
        public NomeArquivo ArquivoAnexo { get; protected set; }
        public StatusDaOcorrencia Status { get; protected set; }        
                


        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFoto(string nomeOriginalfoto)
        {
            try
            {
                Foto = new Foto(nomeOriginalfoto);
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

        public void SetAutorId(Guid id) => AutorId = id;

        public void MarcarComoVisto() => Visto = true;

        public void SetStatus(StatusDaOcorrencia status) => Status = status;

        public void SetArquivoAnexo(string nomeOriginalArquivo)
        {
            try
            {
                ArquivoAnexo = new NomeArquivo(nomeOriginalArquivo, Guid.NewGuid());
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
    }
}
