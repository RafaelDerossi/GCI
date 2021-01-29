using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class UnidadeVeiculo : Entity
    {
        public Guid VeiculoId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public Guid CondominioId { get; private set; }

        

        protected UnidadeVeiculo() { }

        public UnidadeVeiculo(Guid veiculoId, Guid unidadeId, Guid condominioId)
        {
            VeiculoId = veiculoId;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
        }

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;


    }
}