using System;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.Tests.Domain
{
    public static class ParceiroFactory
    {
        public static Parceiro CriarParceiroEfetivo()
        {
            return new Parceiro
                ("Alexandre Silva do Nascimento", "Teste de descricao", "03.096.733/0001-60", "Alexandre Nascimento",
                 "alexandre.nascimento@live.com", "(21) 99796-7038", "(21) 3654-9685", "logo.jpg", "Vermelho", "Rua Teste",
                 "Teste", "478", "22770-190", "Pechincha", "Rio de Janeiro", "Rio de Janeiro", new DateTime(2020, 01, 01),
                  new DateTime(2020, 12, 31), "Descrição do contrato", false, true);            
        }

        public static Parceiro CriarParceiroPreCadastro()
        {
            return new Parceiro
                ("Alexandre Silva do Nascimento", "Teste de descricao", "03.096.733/0001-60", "Alexandre Nascimento",
                 "alexandre.nascimento@live.com", "(21) 99796-7038", "(21) 3654-9685", "logo.jpg", "Vermelho", "Rua Teste",
                 "Teste", "478", "22770-190", "Pechincha", "Rio de Janeiro", "Rio de Janeiro", new DateTime(2020, 01, 01),
                  new DateTime(2020, 12, 31), "Descrição do contrato", true, true);
        }
    }
}