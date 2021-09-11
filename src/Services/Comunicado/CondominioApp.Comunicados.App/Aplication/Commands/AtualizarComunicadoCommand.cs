using CondominioApp.Comunicados.App.Aplication.Commands.Validations;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class AtualizarComunicadoCommand : ComunicadoCommand
    {
        public AtualizarComunicadoCommand
            (Guid comunicadoId, string titulo, string descricao, DateTime? dataDeRealizacao, Guid funcionarioId,
            string nomeFuncionario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            bool temAnexos, IEnumerable<UnidadeComunicado> unidades)
        {
            Unidades = new List<UnidadeComunicado>();
            ComunicadoId = comunicadoId;
            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            Visibilidade = visibilidade;
            Categoria = categoria;
            TemAnexos = temAnexos;
            Unidades = unidades;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarComunicadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarComunicadoCommandValidation : ComunicadoValidation<AtualizarComunicadoCommand>
        {
            public AtualizarComunicadoCommandValidation()
            {
                ValidateId();                
                ValidateTitulo();
                ValidateDescricao();
                ValidateFuncionarioId();
                ValidateNomeFuncionario();
                ValidateVisibilidade();
                ValidateCategoria();
                ValidateTemAnexos();
                ValidateUnidades();
            }
        }
    }
}
