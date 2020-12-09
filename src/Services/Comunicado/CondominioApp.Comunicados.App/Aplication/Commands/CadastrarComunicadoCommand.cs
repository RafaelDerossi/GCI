using CondominioApp.Comunicados.App.Aplication.Commands.Validations;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;
using System.Collections.Generic;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class CadastrarComunicadoCommand : ComunicadoCommand
    {
        public CadastrarComunicadoCommand
            (string titulo, string descricao, DateTime? dataDeRealizacao, Guid condominioId, string nomeCondominio,
            Guid usuarioId, string nomeUsuario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            bool temAnexos, bool criadoPelaAdministradora, IEnumerable<Unidade> unidades)
        {
            Unidades = new List<Unidade>();
            ComunicadoId = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Visibilidade = visibilidade;
            Categoria = categoria;
            TemAnexos = temAnexos;
            CriadoPelaAdministradora = criadoPelaAdministradora;
            Unidades = unidades;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarComunicadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarComunicadoCommandValidation : ComunicadoValidation<CadastrarComunicadoCommand>
        {
            public CadastrarComunicadoCommandValidation()
            {
                ValidateCondominioId();
                ValidateNomeCondominio();
                ValidateTitulo();
                ValidateDescricao();
                ValidateUsuarioId();
                ValidateNomeUsuario();
                ValidateVisibilidade();
                ValidateCategoria();
                ValidateTemAnexos();
                ValidateCriadoPelaAdministradora();
                ValidateUnidades();
            }
        }
    }
}
