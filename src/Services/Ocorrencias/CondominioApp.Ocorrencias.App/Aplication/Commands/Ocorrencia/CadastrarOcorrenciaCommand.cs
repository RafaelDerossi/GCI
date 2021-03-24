using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class CadastrarOcorrenciaCommand : OcorrenciaCommand
    {
        public CadastrarOcorrenciaCommand
            (string descricao, string nomeOriginalfoto, string nomefoto,
            bool publica, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, Guid usuarioId, string nomeUsuario, Guid condominioId,
            string nomeCondominio, bool panico)
        {            
            Descricao = descricao;            
            Publica = publica;            
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Panico = panico;            
            SetFoto(nomeOriginalfoto, nomefoto);
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
            }
        }
    }
}
