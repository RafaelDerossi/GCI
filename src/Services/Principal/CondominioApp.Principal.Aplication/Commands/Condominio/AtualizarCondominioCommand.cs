using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AtualizarCondominioCommand : CondominioCommand
    {

        public AtualizarCondominioCommand(Guid condominioId, string cnpj, string nome, string descricao, 
            string telefone, string logradouro, string complemento, string numero, string cep,
            string bairro, string cidade, string estado)
        {
            CondominioId = condominioId;           
            Nome = nome;
            Descricao = descricao;            
           
            SetCNPJ(cnpj);
            SetTelefone(telefone);
            SetEndereco(logradouro, complemento, numero, cep, bairro, cidade, estado);          
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarCondominioCommandValidation : CondominioValidation<AtualizarCondominioCommand>
        {
            public AtualizarCondominioCommandValidation()
            {
                ValidateId();
                ValidateCNPJ();
                ValidateNome();                
            }
        }

    }
}
