﻿using CondominioApp.Usuarios.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CondominioApp.Usuarios.App.Aplication.Query
{
    public interface IUsuarioQuery : IDisposable
    {
        Task<Usuario> ObterPorId(Guid Id);         
    }
}