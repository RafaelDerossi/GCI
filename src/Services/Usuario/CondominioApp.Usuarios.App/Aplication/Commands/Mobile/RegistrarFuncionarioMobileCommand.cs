using System;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class RegistrarFuncionarioMobileCommand : MobileCommand
    {
        public RegistrarFuncionarioMobileCommand(string deviceKey, string mobileId, string modelo, string plataforma, string versao, Guid funcionarioId)
        {
            DeviceKey = deviceKey;
            MobileId = mobileId;
            Modelo = modelo;
            Plataforma = plataforma;
            Versao = versao;
            MoradorFuncionarioId = funcionarioId;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new RegistrarFuncionarioMobileCommandalidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RegistrarFuncionarioMobileCommandalidation : MobileValidation<RegistrarFuncionarioMobileCommand>
        {
            public RegistrarFuncionarioMobileCommandalidation()
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