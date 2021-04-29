using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Principal.Aplication.ViewModels
{
    public class VeiculoFlatViewModel
    {        

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public Guid VeiculoId { get; private set; }

        public string Placa { get; private set; }
        
        public string Modelo { get; private set; }

        public string Cor { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string NomeUsuario { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string AndarUnidade { get; private set; }

        public string GrupoUnidade { get; private set; }

        public Guid CondominioId { get; private set; }

        public string NomeCondominio { get; private set; }


        
    }
}