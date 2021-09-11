﻿using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using System;

namespace CondominioApp.Portaria.Domain.FlatModel
{
    public class VisitanteFlat : IAggregateRoot
    {
        public const int Max = 200;

        public Guid Id { get; private set; }
        
        public DateTime DataDeCadastro { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public bool Lixeira { get; private set; }

        public string Nome { get; private set; }

        public TipoDeDocumento TipoDeDocumento { get; private set; }

        public string DescricaoTipoDeDocumento { get; private set; }

        public string Documento { get; private set; }       

        public string Email { get; private set; }

        public string NomeArquivoFoto { get; private set; }

        public string NomeOriginalArquivoFoto { get; private set; }

        public string FotoUrl
        {
            get
            {
                if (NomeArquivoFoto == null || NomeArquivoFoto == "")
                    return "";

                return StorageHelper.ObterUrlDeArquivo(CondominioId.ToString(), NomeArquivoFoto);
            }
        }



        public Guid CondominioId { get; private set; }

        public string NomeCondominio { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string AndarUnidade { get; private set; }

        public string GrupoUnidade { get; private set; }

        public bool VisitantePermanente { get; private set; }       

        public TipoDeVisitante TipoDeVisitante { get; private set; }

        public string DescricaoTipoDeVisitante { get; private set; }

        public string NomeEmpresa { get; private set; }

        public bool TemVeiculo { get; private set; }

        public Guid CriadorId { get; set; }

        public string NomeDoCriador { get; set; }

        public TipoDeUsuario TipoDeUsuarioDoCriador { get; set; }

        public string DescricaoTipoDeUsuarioDoCriador
        {
            get
            {
                return TipoDeUsuarioDoCriador switch
                {
                    TipoDeUsuario.ADMINISTRADORA => "Administradora",
                    TipoDeUsuario.ADM => "Adm",
                    TipoDeUsuario.FUNCIONARIO => "Funcionário",
                    TipoDeUsuario.MORADOR => "Morador",
                    TipoDeUsuario.SUPERADMIN => "Superadmin",
                    TipoDeUsuario.LOJISTA => "Lojista",
                    _ => "Indefinido",
                };
            }
        }        


        /// Construtores       
        protected VisitanteFlat()
        {            
        }

        public VisitanteFlat
            (Guid id, string nome, TipoDeDocumento tipoDeDocumento, string documento,
             string email, string nomeArquivoFoto, string nomeOriginalArquivoFoto, Guid condominioId,
             string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
             string grupoUnidade, bool visitantePermanente, TipoDeVisitante tipoDeVisitante,
             string nomeEmpresa, bool temVeiculo, Guid criadorId, string nomeDoCriador,
             TipoDeUsuario tipoDeUsuarioDoCriador)
        {
            Id = id;           
            Nome = nome;           
            Email = email;
            NomeArquivoFoto = nomeArquivoFoto;
            NomeOriginalArquivoFoto = nomeOriginalArquivoFoto;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            VisitantePermanente = visitantePermanente;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;
            CriadorId = criadorId;
            NomeDoCriador = nomeDoCriador;
            TipoDeUsuarioDoCriador = tipoDeUsuarioDoCriador;
            SetDocumento(documento, tipoDeDocumento);
            SetTipoDeVisitante(tipoDeVisitante);
        }







        /// Metodos Set

        public void EnviarParaLixeira() => Lixeira = true;
        public void RestaurarDaLixeira() => Lixeira = false;
        public void SetNome(string nome) => Nome = nome;
        public void SetDocumento(string documento,TipoDeDocumento tipoDeDocumento)
        {
            Documento = documento;
            TipoDeDocumento = tipoDeDocumento;
            DescricaoTipoDeDocumento = tipoDeDocumento switch
            {
                TipoDeDocumento.CPF => "CPF",
                TipoDeDocumento.CNPJ => "CNPJ",
                TipoDeDocumento.RG => "RG",
                TipoDeDocumento.OUTROS => "Outros",
                _ => "Outros",
            };
        }
        public void SetEmail(string email) => Email = email;              
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante)
        {
            TipoDeVisitante = tipoDeVisitante;
            switch (tipoDeVisitante)
            {
                case TipoDeVisitante.PARTICULAR:
                    DescricaoTipoDeVisitante = "Particular";
                    break;
                case TipoDeVisitante.SERVICO:
                    DescricaoTipoDeVisitante = "Serviço";
                    break;
                default:
                    break;
            }            
        }
        public void SetFoto(string nomeArquivo, string nomeOriginalArquivo)
        {
            NomeArquivoFoto = nomeArquivo;
            NomeOriginalArquivoFoto = nomeOriginalArquivo;           
        }
        public void SetNomeEmpresa(string nomeEmpresa) => NomeEmpresa = nomeEmpresa;

        public void MarcarTemVeiculo() => TemVeiculo = true;
        public void MarcarNaoTemVeiculo() => TemVeiculo = false;      

        public void MarcarVisitanteComoPermanente() => VisitantePermanente = true;
        public void MarcarVisitanteComoTemporario() => VisitantePermanente = false;

    }
}