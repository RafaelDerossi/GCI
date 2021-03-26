using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class RegistrarMoradorMobileCommand : MobileCommand
    {
        public RegistrarMoradorMobileCommand(string deviceKey, string mobileId, string modelo, string plataforma, string versao, Guid moradorId)
        {
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            MoradorFuncionarioId = moradorId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RegistrarMoradorMobileCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RegistrarMoradorMobileCommandValidation : MobileValidation<RegistrarMoradorMobileCommand>
        {
            public RegistrarMoradorMobileCommandValidation()
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