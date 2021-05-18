

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class ArquivoDTO
    {
        public string Nome { get; set; }

        public string Extensao { get; set; }

        public string Url { get; set; }

        public ArquivoDTO(string nome, string extensao, string url)
        {
            Nome = nome;
            Extensao = extensao;
            Url = url;
        }
    }
}
