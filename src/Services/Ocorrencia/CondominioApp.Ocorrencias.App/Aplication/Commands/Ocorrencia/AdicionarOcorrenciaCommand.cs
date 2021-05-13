using CondominioApp.Ocorrencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands
{
    public class AdicionarOcorrenciaCommand : OcorrenciaCommand
    {
        public AdicionarOcorrenciaCommand
            (string descricao, string nomeOriginalfoto, string nomefoto,
            bool publica, Guid unidadeId, string numeroUnidade, string andarUnidade,
            string grupoUnidade, Guid moradorId, string nomeMorador, Guid condominioId,
            string nomeCondominio, bool panico)
        {            
            Descricao = descricao;            
            Publica = publica;            
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            MoradorId = moradorId;
            NomeMorador = nomeMorador;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            Panico = panico;            
            SetFoto(nomeOriginalfoto, nomefoto);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarOcorrenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarOcorrenciaCommandValidation : OcorrenciaValidation<AdicionarOcorrenciaCommand>
        {
            public AdicionarOcorrenciaCommandValidation()
            {
                ValidateDescricao();
                ValidatePublica();
                ValidateUnidadeId();
                ValidateMoradorId();
                ValidateNomeMorador();
                ValidateCondominioId();
                ValidatePanico();             
            }
        }
    }
}
