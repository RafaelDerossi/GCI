using CondominioApp.Comunicados.App.Aplication.Commands.Validations;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Comunicados.App.Aplication.Commands
{
    public class CadastrarComunicadoCommand : ComunicadoCommand
    {
        public CadastrarComunicadoCommand
            (string titulo, string descricao, DateTime? dataDeRealizacao, Guid condominioId, string nomeCondominio,
            Guid funcionarioId, string nomeFuncionario, VisibilidadeComunicado visibilidade, CategoriaComunicado categoria,
            bool temAnexos, bool criadoPelaAdministradora, IEnumerable<UnidadeComunicado> unidades)
        {            
            Unidades = new List<UnidadeComunicado>();
            ComunicadoId = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            DataDeRealizacao = dataDeRealizacao;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
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
                ValidateFuncionarioId();
                ValidateNomeFuncionario();
                ValidateVisibilidade();
                ValidateCategoria();
                ValidateTemAnexos();
                ValidateCriadoPelaAdministradora();
                ValidateUnidades();
            }
        }
    }
}
