using System.ComponentModel.DataAnnotations;

namespace CondominioAppPreCadastro.App.ViewModel
{
    public class CondominioModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string nomeDoCondominio { get; set; }

        public string razaoSocial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string nomeDoSindico { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string emailDoSindico { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string telefoneDoSindico { get; set; }

        public int tipoDeDocumento { get; set; }

        public string outroTipoDeDocumento { get; set; }

        public string numeroDoDocumento { get; set; }

        public int tipoDeUnidade { get; set; }

        public int tipoDeGrupo { get; set; }

        public int quantidadeDeGrupos { get; set; }

        public int quantidadeDeAndar { get; set; }

        public int quantidadeDeUnidadesPorAndar { get; set; }

        public int quantidadeDeUnidades { get; set; }

        public string observacao { get; set; }

        public int plano { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string numero { get; set; }

        public string complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string cidade { get; set; }

        public string regiao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string estado { get; set; }

        public string TipoDeUnidadeFormatada { get; set; }

        public string TipoDeGrupoFormatada { get; set; }

        public string TipoDeDocumentoFormatada { get; set; }
    }
}