using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class CadastrarArquivoCommand : ArquivoCommand
    {

        public CadastrarArquivoCommand
            (string nomeArquivo, string nomeOriginal, int tamanho, Guid pastaId, bool publico, Guid funcionarioId,
             string nomeFuncionario, string titulo, string descricao, Guid anexadoId)
        {
            Id = Guid.NewGuid();            
            Tamanho = tamanho;
            PastaId = pastaId;
            Publico = publico;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Titulo = titulo;
            Descricao = descricao;
            AnexadoPorId = anexadoId;
            SetNome(nomeArquivo, nomeOriginal);
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
