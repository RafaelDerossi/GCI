﻿using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class VeiculoEvent : Event
    {
        public Guid Id { get; protected set; }

        public Guid VeiculoId { get; protected set; }

        public string Placa { get; protected set; }

        public string Modelo { get; protected set; }

        public string Cor { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public string NomeUsuario { get; protected set; }

        public Guid UnidadeId { get; protected set; }        

        public string NumeroUnidade { get; protected set; }

        public string AndarUnidade { get; protected set; }

        public string GrupoUnidade { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public string NomeCondominio { get; protected set; }

    }
}