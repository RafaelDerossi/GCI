using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class EditarMobileCommand : MobileCommand
    {
        public EditarMobileCommand(Guid id, string deviceKey, string mobileId, string modelo, string plataforma, string versao, Guid usuarioId)
        {
            Id = id;
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            UsuarioId = usuarioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarMobileCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarMobileCommandValidation : MobileValidation<EditarMobileCommand>
        {
            public EditarMobileCommandValidation()
            {
                ValidateId();
                ValidateDeviceKey();
                ValidateMobileId();
                ValidateModelo();                
                ValidatePlataforma();
                ValidateVersao();
                ValidateUsuarioId();
            }
        }

    }
}