using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.ValueObjects;
using System;

namespace CondominioApp.Usuarios.App.Tests
{
    public class FuncionarioFactoryTests
    {        
        public static Funcionario Criar_Funcionario_Sindico_Valido()
        {            
            return new Funcionario(Guid.NewGuid(), Guid.NewGuid(), "Sindico", "Sindico", Core.Enumeradores.Permissao.ADMIN);    
        }

        public static Funcionario Criar_Funcionario_Porteiro_Valido()
        {
            return new Funcionario(Guid.NewGuid(), Guid.NewGuid(), "Porteiro", "Porteiro", Core.Enumeradores.Permissao.USUARIO);
        }
    }
}