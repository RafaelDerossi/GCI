using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.OneSignal.Recursos.Dispositivos.Enuns
{
   public enum TipoDeTeste
    {
        /// <summary>
        /// Used during development phase.
        /// </summary>
        Development = 1,
        /// <summary>
        /// Used in production, when trying to track down undelivered messages for example.
        /// </summary>
        AdHoc = 2
    }
}
