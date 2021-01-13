using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.ValueObjects;
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
        public string Rg { get; private set; }
        public string Cpf { get; private set; }       
        public string Email { get; private set; }
        public string Foto { get; private set; }

        public Guid CondominioId { get; private set; }
        public string NomeCondominio { get; private set; }

        public Guid UnidadeId { get; private set; }
        public string NumeroUnidade { get; private set; }
        public string AndarUnidade { get; private set; }
        public string GrupoUnidade { get; private set; }

        public bool VisitantePermanente { get; private set; }
        public string QrCode { get; private set; }
        public TipoDeVisitante TipoDeVisitante { get; private set; }
        public string NomeEmpresa { get; private set; }

        public bool TemVeiculo { get; private set; }
        public string PlacaVeiculo { get; private set; }
        public string ModeloVeiculo { get; private set; }
        public string CorVeiculo { get; private set; }
              



        /// Construtores       
        protected VisitanteFlat()
        {            
        }

        public VisitanteFlat(Guid id, string nome, TipoDeDocumento tipoDeDocumento, string rg, string cpf,
            string email, string foto, Guid condominioId, string nomeCondominio, Guid unidadeId,
            string numeroUnidade, string andarUnidade, string grupoUnidade, bool visitantePermanente,
            string qrCode, TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo,
            string placaVeiculo, string modeloVeiculo, string corVeiculo)
        {
            Id = id;
            Nome = nome;
            TipoDeDocumento = tipoDeDocumento;
            Rg = rg;
            Cpf = cpf;
            Email = email;
            Foto = foto;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            GrupoUnidade = grupoUnidade;
            VisitantePermanente = visitantePermanente;
            QrCode = qrCode;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;
            PlacaVeiculo = placaVeiculo;
            ModeloVeiculo = modeloVeiculo;
            CorVeiculo = corVeiculo;

        }


        /// Metodos Set

        public void EnviarParaLixeira() => Lixeira = true;
        public void RestaurarDaLixeira() => Lixeira = false;
        public void SetNome(string nome) => Nome = nome;
        public void SetTipoDeDocumento(TipoDeDocumento tipoDeDocumento) => TipoDeDocumento = tipoDeDocumento;
        public void SetRg(string rg) => Rg = rg;
        public void SetCpf(string cpf) => Cpf = cpf;       
        public void SetEmail(string email) => Email = email;
        public void SetFoto(string foto) => Foto = foto;
        public void SetQrCode(string qrCode) => QrCode = qrCode;
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
        public void SetNomeEmpresa(string nomeEmpresa) => NomeEmpresa = nomeEmpresa;

        public void MarcarTemVeiculo() => TemVeiculo = true;
        public void MarcarNaoTemVeiculo() => TemVeiculo = false;
        public void SetPlacaVeiculo(string placa) => PlacaVeiculo = placa;
        public void SetModeloVeiculo(string modelo) => ModeloVeiculo = modelo;
        public void SetCorVeiculo(string cor) => CorVeiculo = cor;

        public void MarcarVisitanteComoPermanente() => VisitantePermanente = true;
        public void MarcarVisitanteComoTemporario() => VisitantePermanente = false;

    }
}
