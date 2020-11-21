using CondominioApp.Core.ValueObjects;
using CondominioAppMarketplace.Domain;
using Microsoft.VisualBasic.CompilerServices;

namespace CondominioAppMarketplace.Tests.Domain
{
    public static class VendedorFactory
    {
        public static Vendedor CriarVendedorValido()
        {
            return new Vendedor("Alexandre Nascimento",
                new Email("alexandre@techdog.com.br"),
                new Cpf("117.128.950-28"),
                new Telefone("(21) 99796-7038", true),
                new Endereco("Rua Teste","Complemento Teste","5214",
                    "22770-190","Pechincha","Rio de Janeiro","RJ"));
        }
    }
}