using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.ValueObjects;
using System;

namespace CondominioApp.Usuarios.App.Tests
{
    public class MoradorFactoryTests
    {        
        public static Morador Criar_Morador_Valido()
        {            
            return new Morador(Guid.NewGuid(), Guid.NewGuid(),  Guid.NewGuid(), true, true);    
        }

    }
}