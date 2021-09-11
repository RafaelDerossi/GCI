using CondominioApp.ArquivoDigital.App.Aplication.Commands.Validations;
using Microsoft.AspNetCore.Http;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class AdicionarArquivoCommand : ArquivoCommand
    {

        public AdicionarArquivoCommand
            (Guid pastaId, bool publico, Guid funcionarioId, string nomeFuncionario,
             string titulo, string descricao, Guid anexadoId, IFormFile arquivo)
        {
            Id = Guid.NewGuid();
            PastaId = pastaId;
            Publico = publico;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Titulo = titulo;
            Descricao = descricao;
            AnexadoPorId = anexadoId;
            SetArquivo(arquivo);
            SetNome(arquivo.FileName);
            SetTamanho(arquivo.Length);
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
