using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AdicionarMoradorCommand : MoradorCommand
    {
        public AdicionarMoradorCommand(Guid usuarioId, Guid condominioId, string nomeCondominio,
            Guid unidadeId, string numeroUnidade, string andarUnidade, string grupoUnidade, 
            bool proprietario = false, bool principal = false, bool criadoPelaAdministracao = false)
        {
            UsuarioId = usuarioId;            

            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;

            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            
            Proprietario = proprietario;
            Principal = principal;

            CriadoPelaAdministracao = criadoPelaAdministracao;
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarMoradorCommandValidation : MoradorValidation<AdicionarMoradorCommand>
        {
            public AdicionarMoradorCommandValidation()
            {
                ValidateUsuarioId();
                ValidateCondominioId();
                ValidateUnidadeId();
            }
        }

    }
}