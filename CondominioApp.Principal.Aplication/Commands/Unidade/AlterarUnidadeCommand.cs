using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AlterarUnidadeCommand : UnidadeCommand
    {
        public AlterarUnidadeCommand(Guid unidadeId, string codigo, string numero, string andar, 
            int vaga, string telefone, string ramal, string complemento, Guid grupoId, Guid condominioId)
        {
            UnidadeId = unidadeId;
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
            ValidationResult = new AlterarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarUnidadeCommandValidation : UnidadeValidation<AlterarUnidadeCommand>
        {
            public AlterarUnidadeCommandValidation()
            {
                ValidateId();
                ValidateCodigo();
                ValidateNumero();
                ValidateAndar();
                ValidateVaga();
                ValidateGrupoId();
                ValidateCondominioId();                
            }
        }

    }
}
