using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class CadastrarUnidadeCommand : UnidadeCommand
    {
        public CadastrarUnidadeCommand(string codigo, string numero, string andar, 
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
            ValidationResult = new CadastrarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarUnidadeCommandValidation : UnidadeValidation<CadastrarUnidadeCommand>
        {
            public CadastrarUnidadeCommandValidation()
            {  
                ValidateNumero();
                ValidateAndar();
                ValidateVaga();
                ValidateGrupoId();                              
            }
        }

    }
}
