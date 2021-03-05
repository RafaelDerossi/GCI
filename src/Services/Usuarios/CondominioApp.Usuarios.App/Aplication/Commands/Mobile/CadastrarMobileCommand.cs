using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarMobileCommand : MobileCommand
    {
        public CadastrarMobileCommand(string deviceKey, string mobileId, string modelo, string plataforma, string versao, Guid usuarioId)
        {
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

            ValidationResult = new CadastrarMobileCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarMobileCommandValidation : MobileValidation<CadastrarMobileCommand>
        {
            public CadastrarMobileCommandValidation()
            {
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