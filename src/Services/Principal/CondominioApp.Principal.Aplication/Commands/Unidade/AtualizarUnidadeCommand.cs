﻿using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
    public class AtualizarUnidadeCommand : UnidadeCommand
    {
        public AtualizarUnidadeCommand(Guid unidadeId, string numero, string andar, 
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
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarUnidadeCommandValidation : UnidadeValidation<AtualizarUnidadeCommand>
        {
            public AtualizarUnidadeCommandValidation()
            {
                ValidateId();                
                ValidateNumero();
                ValidateAndar();
                ValidateVaga();                             
            }
        }

    }
}