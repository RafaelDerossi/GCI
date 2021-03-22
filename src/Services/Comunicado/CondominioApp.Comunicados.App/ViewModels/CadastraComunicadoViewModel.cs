using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioApp.Comunicados.App.ViewModels
{
   public class CadastraComunicadoViewModel
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataDeRealizacao { get; set; }

        public Guid CondominioId { get; set; }      

        public Guid UsuarioId { get; set; }        

        public VisibilidadeComunicado Visibilidade { get; set; }

        public CategoriaComunicado Categoria { get; set; }       

        public bool CriadoPelaAdministradora { get; set; }

        public IEnumerable<Guid> UnidadesId { get; set; }

        public IEnumerable<CadastraAnexoComunicadoViewModel> Anexos { get; set; }

        public bool TemAnexos
        {
            get {
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
    }
}
