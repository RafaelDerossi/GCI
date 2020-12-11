using System;
using FluentValidation;

namespace CondominioApp.Comunicados.App.Aplication.Commands.Validations
{
    public abstract class ComunicadoValidation<T> : AbstractValidator<T> where T : ComunicadoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.ComunicadoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do comunicado não pode estar vazio!"); ;
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Condominio não pode estar vazio!"); ;
        }

        protected void ValidateNomeCondominio()
        {
            RuleFor(c => c.NomeCondominio)
                  .NotNull()
                  .NotEmpty();
        }

        protected void ValidateTitulo()
        {
            RuleFor(c => c.Titulo)
                  .NotNull()
                  .NotEmpty();
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                  .NotNull()
                  .NotEmpty();
        }
        
        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Usuario não pode estar vazio!"); ;
        }

        protected void ValidateNomeUsuario()
        {
            RuleFor(c => c.NomeUsuario)
                  .NotNull()
                  .NotEmpty();
        }

        protected void ValidateVisibilidade()
        {
            RuleFor(c => c.Visibilidade)
                  .NotNull()
                  .WithMessage("Visibilidade do Comunicado não pode estar vazio!");
        }

        protected void ValidateCategoria()
        {
            RuleFor(c => c.Categoria)
                  .NotNull()
                  .WithMessage("Categoria do Comunicado não pode estar vazio!");
        }

        protected void ValidateTemAnexos()
        {
            RuleFor(c => c.TemAnexos)
                  .NotNull()
                  .WithMessage("Tem anexos não pode estar vazio!");
        }

        protected void ValidateCriadoPelaAdministradora()
        {
            RuleFor(c => c.CriadoPelaAdministradora)
                  .NotNull()
                  .WithMessage("Criado pela administradora não pode estar vazio!");
        }

        protected void ValidateUnidades()
        {
            RuleForEach(c => c.Unidades).ChildRules(Regra =>
            {
                Regra.RuleFor(a => a.UnidadeId)
               .NotEqual(Guid.Empty)
               .WithMessage("Id da Unidade não pode estar vazio!");

                Regra.RuleFor(a => a.Numero)
                .NotNull().WithMessage("Número da Unidade não pode ser nulo!")
                .NotEmpty().WithMessage("Número da Unidade não pode estar vazio!");

                Regra.RuleFor(a => a.Andar)
                .NotNull().WithMessage("Andar da Unidade não pode ser nulo!")
                .NotEmpty().WithMessage("Andar da Unidade não pode estar vazio!");


                Regra.RuleFor(a => a.DescricaoGrupo)
                .NotNull().WithMessage("Grupo da Unidade não pode ser nulo!")
                .NotEmpty().WithMessage("Grupo da Unidade não pode estar vazio!");


                Regra.RuleFor(a => a.GrupoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Grupo da Unidade não pode estar vazio!");

                Regra.RuleFor(a => a.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da Unidade não pode estar vazio!");
            });
        }
    }
}
