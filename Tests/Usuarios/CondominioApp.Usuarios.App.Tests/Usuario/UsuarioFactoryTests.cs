using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.ValueObjects;

namespace CondominioApp.Usuarios.App.Tests
{
    public class UsuarioFactoryTests
    {        
        public static Usuario Criar_Usuario_Valido()
        {            
            return new Usuario("Nome", "sobrenome", "52145256", new Telefone("(21) 99796-7038"),
                new Email("alexandre@techdog.com.br"), new Foto("Foto.jpg", "Foto.jpg"));            
        }

                
        public static Usuario Criar_Usuario_Valido_SemFoto()
        {
            return new Usuario("Nome", "sobrenome", "52145256", new Telefone("(21) 99796-7038"),
               new Email("alexandre@techdog.com.br"), new Foto("", ""));
        }

    }
}