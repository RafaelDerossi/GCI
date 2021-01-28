using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Principal.Domain.FlatModel
{
    public class VeiculoFlat
    {
        public const int Max = 200;

        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Placa { get; private set; }
        
        public string Modelo { get; private set; }

        public string Cor { get; private set; }

        public Guid UsuarioId { get; private set; }

        //EF
        public Usuario Usuario { get; set; }

        protected VeiculoFlat() { }

        public VeiculoFlat(Guid id, string placa, string modelo, string cor, Guid usuarioId)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;            
        }


        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public void SetVeiculo(string placa, string modelo, string cor)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }

        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;


    }
}