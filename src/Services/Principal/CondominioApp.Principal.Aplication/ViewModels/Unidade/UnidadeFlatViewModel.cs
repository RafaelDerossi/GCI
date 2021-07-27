using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Principal.Aplication.ViewModels
{
   public class UnidadeFlatViewModel
    {
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Codigo { get; private set; }

        public string Numero { get; private set; }

        public string Andar { get; private set; }

        public int Vagas { get; private set; }

        public string Telefone { get; private set; }

        public string Ramal { get; private set; }

        public string Complemento { get; private set; }

        public Guid GrupoId { get; private set; }

        public string GrupoDescricao { get; private set; }

        public Guid CondominioId { get; private set; }

        public string CondominioCnpj { get; private set; }

        public string CondominioNome { get; private set; }

        public string CondominioLogo { get; private set; }

        public IList<MoradorFlatViewModel> Moradores { get; set; }

        public IList<VeiculoFlatViewModel> Veiculos { get; set; }



        public string ObterDescricaoUnidade()
        {
            return $"{Numero}|{Andar}|{GrupoDescricao}";
        }
    }
}
