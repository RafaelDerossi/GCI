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

        public string NumeroUnidade { get; protected set; }

        public string AndarUnidade { get; protected set; }

        public string GrupoUnidade { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }



        public void SetVeiculo(string placa, string modelo, string cor)
        {
            if (!string.IsNullOrEmpty(placa))
            {                
                Regex regex = new Regex(@"^([A-Z]{3}[0-9][0-9A-Z][0-9]{2})*$");
                Match match = regex.Match(placa);
                if (!match.Success)
                    throw new DomainException("Placa inválida!");
            }

            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }              

        public void SetUsuarioId(Guid id)
        {
            UsuarioId = id;
        }

        public void SetUnidade(Guid id, string numero, string andar, string grupo)
        {
            UnidadeId = id;
            NumeroUnidade = numero;
            AndarUnidade = andar;
            GrupoUnidade = grupo;
        }

        public void SetCondominio(Guid id, string nome)
        {
            CondominioId = id;
            NomeCondominio = nome;
        }

    }
}
