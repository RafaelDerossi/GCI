using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AdicionarUnidadeCommand : UnidadeCommand
    {
        public AdicionarUnidadeCommand(string codigo, string numero, string andar, 
            int vaga, string telefone, string ramal, string complemento, Guid grupoId)
        {
            Codigo = codigo;
            Numero = numero;
            Andar = andar;
            Vaga = vaga;
            Ramal = ramal;
            Complemento = complemento;
            GrupoId = grupoId;            

            SetTelefone(telefone);
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarUnidadeCommandValidation : UnidadeValidation<AdicionarUnidadeCommand>
        {
            public AdicionarUnidadeCommandValidation()
            {
                ValidateNumero();
                ValidateAndar();
                ValidateVaga();
                ValidateGrupoId();                              
            }
        }

    }
}
