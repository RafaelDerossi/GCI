using System;

namespace NinjaStore.Pedidos.Domain
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public string DataDeCadastroFormatada { get; set; }      

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }       

        public bool Lixeira { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Aldeia { get; set; }
    }
}
