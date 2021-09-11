using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.ValueObjects;
using System;


namespace CondominioApp.Principal.Aplication.Commands
{
    public abstract class ContratoCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public DateTime DataAssinatura { get; set; }

        public TipoDePlano TipoPlano { get; set; }

        public string DescricaoContrato { get; set; }

        public bool Ativo { get; set; }

        public int QuantidadeDeUnidadesContratado { get; set; }

        public NomeArquivo ArquivoContrato { get; set; }

        public void SetArquivoContrato(string nomeOriginal)
        {
            try
            {
                ArquivoContrato = new NomeArquivo(nomeOriginal, Guid.NewGuid());
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }

    }
}
