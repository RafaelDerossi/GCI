using System;
using CondominioAppMarketplace.App.ParceiroFactory;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.Tests.Domain
{
    public static class ParceiroFactory
    {
        public static Parceiro CriarParceiroCadastroEfetivo()
        {
            var factory = new ConstrutorDeParceiros(new FabricaDeParceirosEfetivos());

            return factory.Construir(new ParceiroViewModel()
            {
                Logradouro = "Rua Teste",
                Numero = "478",
                Bairro = "Pechincha",
                Cep = "22770-190",
                Cidade = "Rio de Janeiro",
                Complemento = "Teste",
                Estado = "Rio de Janeiro",
                Descricao = "Teste de descricao",
                EmailDoResponsavel = "alexandre.nascimento@live.com",
                NomeCompleto = "Alexandre Silva do Nascimento",
                NomeDoResponsavel = "Alexandre Nascimento",
                NumeroDoCnpj = "03.096.733/0001-60",
                PreCadastro = false,
                TelefoneCelular = "(21) 99796-7038",
                TelefoneFixo = "(21) 3654-9685",
                Whatsapp = true,
                Cor = "Vermelho",
                LogoMarca = "logo.jpg",
                ContratoDataDeInicio = new DateTime(2020,01,01),
                ContratoDataDeRenovacao = new DateTime(2020,12,31),
                ContratoDescricao = "Descrição do contrato"
            });
        }

        public static Parceiro CriarParceiroPrecadastro()
        {
            var factory = new ConstrutorDeParceiros(new FabricaDeParceirosPreCadastro());

            return factory.Construir(new ParceiroViewModel()
            {
                Logradouro = "Rua Teste",
                Numero = "478",
                Bairro = "Pechincha",
                Cep = "22770-190",
                Cidade = "Rio de Janeiro",
                Complemento = "Teste",
                Estado = "Rio de Janeiro",
                Descricao = "Teste de descricao",
                EmailDoResponsavel = "alexandre.nascimento@live.com",
                NomeCompleto = "Novo Parceiro para testes",
                NomeDoResponsavel = "Alexandre Nascimento",
                NumeroDoCnpj = "03.096.733/0001-60",
                PreCadastro = false,
                TelefoneCelular = "(21) 99796-7038",
                TelefoneFixo = "(21) 3654-9685",
                Whatsapp = true
            });
        }
    }
}