using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AlterarCondominioCommand : CondominioCommand
    {

        public AlterarCondominioCommand(Guid condominioId, string cnpj, string nome, string descricao = null, 
            string logoMarca = null, string nomeOriginal = null, string telefone = null, string logradouro = null,
            string complemento = null, string numero = null, string cep = null, string bairro = null, 
            string cidade = null, string estado = null)
        {
            CondominioId = condominioId;
            Cnpj = cnpj;
            Nome = nome;
            Descricao = descricao;
            LogoMarca = logoMarca;
            NomeOriginal = nomeOriginal;
            Telefone = telefone;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }


        public override bool EstaValido()
        {
            ValidationResult = new AlterarCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarCondominioCommandValidation : CondominioValidation<AlterarCondominioCommand>
        {
            public AlterarCondominioCommandValidation()
            {
                ValidateId();
                ValidateCNPJ();
                ValidateNome();                
            }
        }

    }
}
