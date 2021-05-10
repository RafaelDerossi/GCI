using CondominioApp.NotificacaoPush.App.Aplication.Commands.Validations;
using CondominioApp.NotificacaoPush.Commands;
using System;

namespace CondominioApp.NotificacaoPush.App.Aplication.Commands
{
    public class EnviarNotificacaoParaTodosNoCondominioCommand : NotificacaoPushCommand
    {
        public EnviarNotificacaoParaTodosNoCondominioCommand
            (string titulo, string conteudo, Guid condominioId)
        {
            CondominioId = condominioId;
            Titulo = titulo;
            Conteudo = conteudo;            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EnviarNotificacaoParaTodosNoCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EnviarNotificacaoParaTodosNoCondominioCommandValidation : NotificacaoPushValidation<EnviarNotificacaoParaTodosNoCondominioCommand>
        {
            public EnviarNotificacaoParaTodosNoCondominioCommandValidation()
            {
                ValidateCondominioId();                
                ValidateTitulo();
                ValidateConteudo();
            }
        }
    }
}
