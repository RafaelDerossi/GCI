using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AlterarUnidadeCommand : UnidadeCommand
    {
        public AlterarUnidadeCommand(Guid unidadeId, string numero, string andar, 
            int vaga, string telefone, string ramal, string complemento)
        {
            UnidadeId = unidadeId;           
            Numero = numero;
            Andar = andar;
            Vaga = vaga;         
            Ramal = ramal;
            Complemento = complemento;

            SetTelefone(telefone);
        }

        public override bool EstaValido()
        {
            if (!base.EstaValido())
                return ValidationResult.IsValid;

            ValidationResult = new AlterarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarUnidadeCommandValidation : UnidadeValidation<AlterarUnidadeCommand>
        {
            public AlterarUnidadeCommandValidation()
            {
                ValidateId();                
                ValidateNumero();
                ValidateAndar();
                ValidateVaga();                             
            }
        }

    }
}
