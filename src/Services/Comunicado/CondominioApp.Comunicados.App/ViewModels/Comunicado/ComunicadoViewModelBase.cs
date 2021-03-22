using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public abstract class ComunicadoViewModelBase
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeRealizacao { get; set; }

        public Guid CondominioId { get; set; }     

        public Guid UsuarioId { get; set; }

        public VisibilidadeComunicado Visibilidade { get; set; }

        public CategoriaComunicado Categoria { get; set; }

        public bool CriadoPelaAdministradora { get; set; }

        public IEnumerable<AnexoComunicadoViewModelBase> Anexos { get; set; }

        public bool TemAnexos
        {
            get
            {
                bool temAnexos = false;
                if (Anexos != null)
                {
                    temAnexos = Anexos.Count() > 0;
                }
                return temAnexos;
            }
        }

        public CategoriaDaPastaDeSistema ObterCategoriaDePastaDeSistema()
        {
            switch (Categoria)
            {
                case CategoriaComunicado.ATA:
                    return CategoriaDaPastaDeSistema.ATA;

                case CategoriaComunicado.AVISO:
                    return CategoriaDaPastaDeSistema.AVISO;

                case CategoriaComunicado.BALANCETE:
                    return CategoriaDaPastaDeSistema.BALANCETE;

                case CategoriaComunicado.COBRANÇA:
                    return CategoriaDaPastaDeSistema.COBRANÇA;

                case CategoriaComunicado.COMUNICADO:
                    return CategoriaDaPastaDeSistema.COMUNICADO;

                case CategoriaComunicado.MANUTENÇÃO:
                    return CategoriaDaPastaDeSistema.MANUTENÇÃO;

                case CategoriaComunicado.OBRA_REFORMA:
                    return CategoriaDaPastaDeSistema.OBRA_REFORMA;

                case CategoriaComunicado.OUTROS:
                    return CategoriaDaPastaDeSistema.OUTROS;

                case CategoriaComunicado.URGENCIA:
                    return CategoriaDaPastaDeSistema.URGENCIA;

                default:
                    return 0;
            }
        }

        public ComunicadoViewModelBase()
        {
        }
    }
}
