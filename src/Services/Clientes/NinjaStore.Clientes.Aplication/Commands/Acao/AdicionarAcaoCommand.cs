using GCI.Acoes.Aplication.Commands.Validations;

namespace GCI.Acoes.Aplication.Commands
{
    public class AdicionarAcaoCommand : AcaoCommand
    {

        public AdicionarAcaoCommand(string codigo, string razaoSocial)
        {            
            Codigo = codigo;
            RazaoSocial = razaoSocial;            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarAcaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarAcaoCommandValidation : AcaoValidation<AdicionarAcaoCommand>
        {
            public AdicionarAcaoCommandValidation()
            {                               
                ValidateCodigo();
                ValidateRazaoSocial();
            }
        }

    }
}
