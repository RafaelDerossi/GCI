using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.NotificacaoEmail.App.DTO
{
    public class ArquivoDTO
    {
        public string Nome { get; set; }

        public string Extensao { get; set; }

        public ArquivoDTO(string nome, string extensao)
        {
            Nome = nome;
            Extensao = extensao;
        }
    }
}
