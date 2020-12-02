using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class EditarCondominioCommand : CondominioCommand
    {

        public EditarCondominioCommand(Guid condominioId, string cnpj, string nome, string descricao = null, 
            string logoMarca = null, string nomeOriginal = null, string telefone = null, string logradouro = null,
            string complemento = null, string numero = null, string cep = null, string bairro = null, 
            string cidade = null, string estado = null)
        {
            CondominioId = condominioId;           
            Nome = nome;
            Descricao = descricao;            
           
            SetCNPJ(cnpj);
            SetFoto(logoMarca, nomeOriginal);
            SetTelefone(telefone);
            SetEndereco(logradouro, complemento, numero, cep, bairro, cidade, estado);          
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarCondominioCommandValidation : CondominioValidation<EditarCondominioCommand>
        {
            public EditarCondominioCommandValidation()
            {
                ValidateId();
                ValidateCNPJ();
                ValidateNome();                
            }
        }

    }
}
