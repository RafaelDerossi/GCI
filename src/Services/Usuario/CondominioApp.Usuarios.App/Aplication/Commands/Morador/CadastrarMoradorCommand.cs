using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarMoradorCommand : MoradorCommand
    {
        public CadastrarMoradorCommand(Guid usuarioId, Guid condominioId, string nomeCondominio,
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

            ValidationResult = new CadastrarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarMoradorCommandValidation : MoradorValidation<CadastrarMoradorCommand>
        {
            public CadastrarMoradorCommandValidation()
            {
                ValidateUsuarioId();
                ValidateCondominioId();
                ValidateUnidadeId();
            }
        }

    }
}