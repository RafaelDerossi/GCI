using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public abstract class FotoDaAreaComumCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid AreaComumId { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public Foto Foto { get; protected set; }


        public void SetAreaComumId(Guid id) => AreaComumId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;

        public void SetFoto(string NomeOriginalfoto)
        {
            try
            {
                var foto = new Foto(NomeOriginalfoto);
                Foto = foto;
            }
            catch (Exception e)
            {
                AdicionarErrosDeProcessamentoDoComando(e.Message);
            }
        }
    }
}
