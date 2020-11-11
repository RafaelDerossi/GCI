using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{   
    public class EditarMoradorCommandValidation : UsuarioValidation<EditarMoradorCommand>
    {
        public EditarMoradorCommandValidation()
        {
            ValidateName();           
            ValidateEmail();
            ValidateId();
        }
    }
}
