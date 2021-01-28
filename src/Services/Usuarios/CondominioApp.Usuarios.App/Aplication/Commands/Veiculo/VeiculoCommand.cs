using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.ValueObjects;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public abstract class VeiculoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Placa { get; protected set; }

        public string Modelo { get; protected set; }

        public string Cor { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public Guid UnidadeId { get; protected set; }



        public void SetPlaca(string placa)
        {
            if (!string.IsNullOrEmpty(placa))
            {                
                Regex regex = new Regex(@"^([A-Z]{3}[0-9][0-9A-Z][0-9]{2})*$");
                Match match = regex.Match(placa);
                if (!match.Success)
                    throw new DomainException("Placa inválida!");
            }

            Placa = placa;
        }

        public void SetModelo(string modelo)
        {
            Modelo = modelo;
        }

        public void SetCor(string cor)
        {
            Cor = cor;
        }

    }
}
