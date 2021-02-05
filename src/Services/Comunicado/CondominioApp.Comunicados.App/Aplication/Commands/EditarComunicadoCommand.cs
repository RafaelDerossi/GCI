using CondominioApp.Comunicados.App.Aplication.Commands.Validations;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class EditarComunicadoCommand : ComunicadoCommand
    {
        public EditarComunicadoCommand
            (Guid comunicadoId, string titulo, string descricao, DateTime? dataDeRealizacao, Guid usuarioId,
            string nomeUsuario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            bool temAnexos, IEnumerable<UnidadeComunicado> unidades)
        {
            Unidades = new List<UnidadeComunicado>();
            ComunicadoId = comunicadoId;
            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Visibilidade = visibilidade;
            Categoria = categoria;
            TemAnexos = temAnexos;
            Unidades = unidades;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarComunicadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarComunicadoCommandValidation : ComunicadoValidation<EditarComunicadoCommand>
        {
            public EditarComunicadoCommandValidation()
            {
                ValidateId();                
                ValidateTitulo();
                ValidateDescricao();
                ValidateUsuarioId();
                ValidateNomeUsuario();
                ValidateVisibilidade();
                ValidateCategoria();
                ValidateTemAnexos();
                ValidateUnidades();
            }
        }
    }
}
