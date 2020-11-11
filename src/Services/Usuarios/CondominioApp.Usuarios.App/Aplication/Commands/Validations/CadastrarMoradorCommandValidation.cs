using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{   
    public class CadastrarMoradorCommandValidation : UsuarioValidation<CadastrarMoradorCommand>
    {
        public CadastrarMoradorCommandValidation()
        {
            ValidateName();           
            ValidateEmail();
            ValidateId();
        }
    }
}
