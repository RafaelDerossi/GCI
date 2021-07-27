using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.ValueObjects;
using System;
using Xunit;


namespace CondominioApp.Principal.Tests
{
   
    public class CondominioFactoryTests
    {
        public static Condominio Criar_Condominio_Valido()
        {           
           return new Condominio(Guid.NewGuid(), new Cnpj("26585345000148"), "Condominio TU",
                "Condominio Teste Unitario", new Foto("Foto.jpg"), new Telefone("(21) 99796-7038"),
                 new Endereco("Rua...", null, "1001", "23063260", "Bairro", "Cidade", "RJ"),
                 false, false, false, false, false, false, false, false, false, false, false,
                 false, false, false, false);  
        }

        
        public static Condominio Criar_Condominio_Valido_SemFoto()
        {
            var condominio = Criar_Condominio_Valido();
            condominio.SetLogo(new Foto(""));
            return condominio;
        }

        
        public static Condominio Criar_Condominio_Valido_SemTelefone()
        {
           var condominio = Criar_Condominio_Valido();
           condominio.SetTelefone(new Telefone(""));
           return condominio;
        }


        public static Condominio Criar_Condominio_Invalido_SemCNPJ()
        {
            var condominio = Criar_Condominio_Valido();
            condominio.SetCNPJ(new Cnpj(""));
            return condominio;
        }
        
        public static Condominio Criar_Condominio_Invalido_ComCNPJInvalido()
        {
            var condominio = Criar_Condominio_Valido();
            condominio.SetCNPJ(new Cnpj("26585345000147"));
            return condominio;
        }
    }
}
