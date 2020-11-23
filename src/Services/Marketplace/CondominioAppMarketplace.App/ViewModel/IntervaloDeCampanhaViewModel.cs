using System;
using System.ComponentModel.DataAnnotations;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class IntervaloDeCampanhaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CampanhaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime NovaDataDeInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime NovaDataDeFinal { get; set; }
    }
}
