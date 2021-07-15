using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.ReservaAreaComum.Domain.ValueObject;
using System;

namespace CondominioApp.ReservaAreaComum.Domain
{
    public class FotoDaAreaComum : Entity
    {
        public Guid AreaComumId { get; private set; }

        public Guid CondominioId { get; private set; }

        public Foto Foto { get; private set; }

        public string FotoUrl
        {
            get
            {
                if (Foto == null)
                    return "";

                return StoragePaths.ObterUrlDeArquivo(CondominioId.ToString(), Foto.NomeDoArquivo);
            }
        }

        protected FotoDaAreaComum() { }

        public FotoDaAreaComum(Guid areaComumId, Guid condominioId, Foto foto)
        {
            AreaComumId = areaComumId;
            CondominioId = condominioId;
            Foto = foto;
        }

        public void SetAreaComumId(Guid id) => AreaComumId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;

        public void SetFoto(Foto foto) => Foto = foto;
    }
}
