using System;
using System.Collections.Generic;

namespace CondominioApp.NotificacaoPush.App.ViewModel
{
   public class NotificarTodosPorCondominioViewModel
    {        
        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public Guid CondominioId { get; set; }
    }
}
