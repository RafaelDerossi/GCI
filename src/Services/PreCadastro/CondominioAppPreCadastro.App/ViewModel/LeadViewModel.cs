using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CondominioAppPreCadastro.App.ViewModel
{
    public class LeadViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int plano { get; set; }

        public int statusPreCadastro { get; set; }

        public string motivoStatus { get; set; }

        public List<CondominioModel> condominios { get; set; }
    }
}