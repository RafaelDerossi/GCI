using CondominioApp.Core.DomainObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Usuarios.App.Models
{
    public class Veiculo : Entity
    {
        public string Placa { get; private set; }
        
        public string Modelo { get; private set; }

        public string Cor { get; private set; }

        public Guid UsuarioId { get; private set; }


        private readonly List<UnidadeVeiculo> _Unidades;
        public IReadOnlyCollection<UnidadeVeiculo> Unidades => _Unidades;

        protected Veiculo() { }

        public Veiculo(string placa, string modelo, string cor, Guid usuarioId)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;            
        }

        public void SetVeiculo(string placa, string modelo, string cor)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }

        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;

        public ValidationResult AdicionarUnidade(UnidadeVeiculo unidade)
        {
            _Unidades.Add(unidade);

            return ValidationResult;
        }

        public bool EstaCadastradoNaUnidade(Guid usuarioId, Guid unidadeId)
        {
           return (UsuarioId == usuarioId && _Unidades.Any(u => u.UnidadeId == unidadeId) && !Lixeira);
        }

        public bool EstaCadastradoNoCondominio(Guid usuarioId, Guid condominioId)
        {
            return (UsuarioId == usuarioId && _Unidades.Any(u => u.CondominioId == condominioId) && !Lixeira);
        }

        public bool PertenceAoMesmoUsuario(Guid usuarioId)
        {
            return (UsuarioId == usuarioId && !Lixeira);
        }

        public void RemoverTodasAsUnidade()
        {
            _Unidades.Clear();
        }

    }
}