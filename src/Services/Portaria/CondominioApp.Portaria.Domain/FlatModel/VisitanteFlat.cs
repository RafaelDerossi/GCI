using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Domain.ValueObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

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

        public Guid CondominioId { get; private set; }

        public string NomeCondominio { get; private set; }

        public Guid UnidadeId { get; private set; }

        public string NumeroUnidade { get; private set; }

        public string AndarUnidade { get; private set; }

        public string GrupoUnidade { get; private set; }

        public bool VisitantePermanente { get; private set; }

        public string QrCode { get; private set; }

        public TipoDeVisitante TipoDeVisitante { get; private set; }

        public string DescricaoTipoDeVisitante { get; private set; }

        public string NomeEmpresa { get; private set; }

        public bool TemVeiculo { get; private set; }

        public Guid CriadorId { get; set; }

        public string NomeDoCriador { get; set; }

        public TipoDeUsuario TipoDeUsuarioDoCriador { get; set; }


        /// Construtores       
        protected VisitanteFlat()
        {            
        }

        public VisitanteFlat
            (Guid id, DateTime dataDeCadastro, DateTime dataDeAlteracao, bool lixeira, string nome,
             TipoDeDocumento tipoDeDocumento, string descricaoTipoDeDocumento, string documento,
             string email, string nomeArquivoFoto, string nomeOriginalArquivoFoto, Guid condominioId,
             string nomeCondominio, Guid unidadeId, string numeroUnidade, string andarUnidade,
             string grupoUnidade, bool visitantePermanente, string qrCode, TipoDeVisitante tipoDeVisitante,
             string descricaoTipoDeVisitante, string nomeEmpresa, bool temVeiculo, Guid criadorId,
             string nomeDoCriador, TipoDeUsuario tipoDeUsuarioDoCriador)
        {
            Id = id;
            DataDeCadastro = dataDeCadastro;
            DataDeAlteracao = dataDeAlteracao;
            Lixeira = lixeira;
            Nome = nome;           
            DescricaoTipoDeDocumento = descricaoTipoDeDocumento;           
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
            QrCode = qrCode;          
            DescricaoTipoDeVisitante = descricaoTipoDeVisitante;
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
        public void SetQrCode(string qrCode) => QrCode = qrCode;
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
        
        public void SetNomeEmpresa(string nomeEmpresa) => NomeEmpresa = nomeEmpresa;

        public void MarcarTemVeiculo() => TemVeiculo = true;
        public void MarcarNaoTemVeiculo() => TemVeiculo = false;      

        public void MarcarVisitanteComoPermanente() => VisitantePermanente = true;
        public void MarcarVisitanteComoTemporario() => VisitantePermanente = false;

    }
}
