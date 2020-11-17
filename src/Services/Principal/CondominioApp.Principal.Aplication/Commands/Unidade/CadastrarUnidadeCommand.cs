using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class CadastrarUnidadeCommand : UnidadeCommand
    {
        public CadastrarUnidadeCommand(string codigo, string numero, string andar, 
            int vaga, string telefone, string ramal, string complemento, Guid grupoId, Guid condominioId)
        {
            Codigo = codigo;
            Numero = numero;
            Andar = andar;
            Vaga = vaga;
            Telefone = new Telefone(telefone);
            Ramal = ramal;
            Complemento = complemento;
            GrupoId = grupoId;
            CondominioId = condominioId;
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
                ValidateCondominioId();                
            }
        }

    }
}
