using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class CadastrarOcorrenciaCommand : OcorrenciaCommand
    {
        public CadastrarOcorrenciaCommand
            (string descricao, Foto foto, bool publica, Guid unidadeId,
            Guid usuarioId, Guid condominioId, bool panico, bool temAnexo)
        {            
            Descricao = descricao;
            Foto = foto;
            Publica = publica;            
            UnidadeId = unidadeId;
            UsuarioId = usuarioId;
            CondominioId = condominioId;
            Panico = panico;
            TemAnexo = temAnexo;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarOcorrenciaCommandValidation : OcorrenciaValidation<CadastrarOcorrenciaCommand>
        {
            public CadastrarOcorrenciaCommandValidation()
            {
                ValidateDescricao();
                ValidatePublica();
                ValidateUnidadeId();
                ValidateUsuarioId();
                ValidateCondominioId();
                ValidatePanico();
                ValidateTemAnexo();
            }
        }
    }
}
