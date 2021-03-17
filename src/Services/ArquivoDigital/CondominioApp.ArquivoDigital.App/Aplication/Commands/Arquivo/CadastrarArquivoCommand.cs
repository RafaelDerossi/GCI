using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class CadastrarArquivoCommand : ArquivoCommand
    {

        public CadastrarArquivoCommand
            (string nomeOriginal, int tamanho, Guid pastaId, bool publico, Guid usuarioId,
             string nomeUsuario, string titulo, string descricao)
        {
            Id = Guid.NewGuid();            
            Tamanho = tamanho;
            PastaId = pastaId;
            Publico = publico;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Titulo = titulo;
            Descricao = descricao;
            SetNome(nomeOriginal);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarArquivoCommandValidation : ArquivoValidation<CadastrarArquivoCommand>
        {
            public CadastrarArquivoCommandValidation()
            {                
                ValidateTamanho();                
                ValidatePastaId();
                ValidatePublico();
                ValidateUsuarioId();
                ValidateNomeUsuario();
                ValidateTitulo();
                ValidateDescricao();
            }
        }

    }
}
