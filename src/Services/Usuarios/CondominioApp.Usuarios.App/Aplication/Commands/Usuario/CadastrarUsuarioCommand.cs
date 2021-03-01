using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarUsuarioCommand : UsuarioCommand
    {
        public CadastrarUsuarioCommand(Guid usuarioId, string nome, string sobrenome, string email,
            Guid condominioId, Guid unidadeId, string foto, string nomeOriginal, string rg = null, string cpf = null, string cel = null,
            bool proprietario = false, bool principal = false, string atribuicao = null, string funcao = null,
            DateTime? dataNascimento = null, TipoDeUsuario tpUsuario = TipoDeUsuario.MORADOR,
            Permissao permissao = Permissao.USUARIO)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;

            TpUsuario = tpUsuario;
            Permissao = permissao;

            CondominioId = condominioId;
            UnidadeId = unidadeId;

            Atribuicao = atribuicao;
            Funcao = funcao;
            Proprietario = proprietario;
            Principal = principal;

            SetCpf(cpf);
            SetCelular(cel);
            SetEmail(email);
            SetFoto(foto, nomeOriginal);
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarMoradorCommandValidation : UsuarioValidation<CadastrarUsuarioCommand>
        {
            public CadastrarMoradorCommandValidation()
            {
                ValidateNome();
                ValidateEmail();
                ValidateId();                
            }
        }

    }
}