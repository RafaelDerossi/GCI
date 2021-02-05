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


        private readonly List<VeiculoCondominio> _VeiculoCondominios;
        public IReadOnlyCollection<VeiculoCondominio> VeiculoCondominios => _VeiculoCondominios;

        protected Veiculo() { }

        public Veiculo(string placa, string modelo, string cor)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;            
        }

        public void SetVeiculo(string placa, string modelo, string cor)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }        

        public ValidationResult AdicionarVeiculoCondominio(VeiculoCondominio veiculoCondominio)
        {
            _VeiculoCondominios.Add(veiculoCondominio);

            return ValidationResult;
        }

        public bool EstaCadastrado(Guid usuarioId, Guid unidadeId, Guid condominioId)
        {
            if ((_VeiculoCondominios.Any(u => u.UnidadeId == unidadeId && u.UsuarioId == usuarioId && u.CondominioId == condominioId) && !Lixeira) == true)
                return true;

           return (_VeiculoCondominios.Any(u => u.UsuarioId == usuarioId && u.CondominioId == condominioId) && !Lixeira);
        }

        public bool EstaCadastradoNoCondominio(Guid condominioId)
        {
            return (_VeiculoCondominios.Any(u => u.CondominioId == condominioId) && !Lixeira);
        }               

        public void RemoverTodosOsVeiculoCondominioPorCondominio(Guid condominioId)
        {
            var veiculoCondominiosDoCondominio = _VeiculoCondominios.Where(c => c.CondominioId == condominioId);
            foreach (VeiculoCondominio veiculoCondominio in veiculoCondominiosDoCondominio)
            {
                _VeiculoCondominios.Remove(veiculoCondominio);
            }            
        }

    }
}