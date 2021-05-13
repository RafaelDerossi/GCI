using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using FluentValidation;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AdicionarArquivoCommand : ArquivoCommand
    {

        public AdicionarArquivoCommand
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

            ValidationResult = new AdicionarArquivoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarArquivoCommandValidation : ArquivoValidation<AdicionarArquivoCommand>
        {
            public AdicionarArquivoCommandValidation()
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
