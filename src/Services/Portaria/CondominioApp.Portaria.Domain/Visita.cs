using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Portaria.ValueObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Portaria.Domain
{
    public class Visita : Entity
    {
        public const int Max = 200;

        public Guid VisitanteId { get; private set; }

        private readonly Visitante _Visitante;
        public Visitante Visitante => _Visitante;
       
        public string NomeCondomino { get; private set; }

        public int MyProperty { get; set; }






        public bool VisitantePermanente { get; private set; }
        public string QrCode { get; private set; }
        public TipoDeVisitante TipoDeVisitante { get; private set; }
        public string NomeEmpresa { get; private set; }

       
        public string PlacaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string CorVeiculo { get; set; }
        


        //private readonly List<Visita> _Visitas;
        //public IReadOnlyCollection<Visita> Visitas => _Visitas;


       

        
        /// Construtores       
        protected Visitante()
        {
            //_Visitas = new List<Visita>();      
        }

        public Visitante
            (string nome, string rg, Cpf cpf, Cnpj cnpj, Telefone celular, Email email,
            Foto foto, Guid condominioId, string nomeCondominio, Guid unidadeId,
            string numeroUnidade, string andarUnidade, string descricaoGrupoUnidade,
            bool visitantePermanente, string qrCode, TipoDeVisitante tipoDeVisitante,
            string nomeEmpresa, string placaVeiculo, string modeloVeiculo, string corVeiculo)
        {
            //_Visitas = new List<Visita>(); 
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Celular = celular;
            Email = email;
            Foto = foto;
            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;
            UnidadeId = unidadeId;
            NumeroUnidade = numeroUnidade;
            AndarUnidade = andarUnidade;
            DescricaoGrupoUnidade = descricaoGrupoUnidade;
            VisitantePermanente = visitantePermanente;
            QrCode = qrCode;
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            PlacaVeiculo = placaVeiculo;
            ModeloVeiculo = modeloVeiculo;
            CorVeiculo = corVeiculo;
        }




        /// Metodos Set
        public void SetNome(string nome) => Nome = nome;      
        public void SetRg(string rg) => Rg = rg;
        public void SetCpf(Cpf cpf) => Cpf = cpf;
        public void SetCnpj(Cnpj cnpj) => Cnpj = cnpj;
        public void SetCelular(Telefone celular) => Celular = celular;
        public void SetEmail(Email email) => Email = email;
        public void SetFoto(Foto foto) => Foto = foto;
        public void SetQrCode(string qrCode) => QrCode = qrCode;
        public void SetTipoDeVisitante(TipoDeVisitante tipoDeVisitante) => TipoDeVisitante = tipoDeVisitante;
        public void SetNomeEmpresa(string nomeEmpresa) => NomeEmpresa = nomeEmpresa;
        public void SetPlacaVeiculo(string placaVeiculo) => PlacaVeiculo = placaVeiculo;
        public void SetModeloVeiculo(string modeloVeiculo) => ModeloVeiculo = modeloVeiculo;
        public void SetCorVeiculo(string corVeiculo) => CorVeiculo = corVeiculo;


        public void MarcarVisitanteComoPermanente() => VisitantePermanente = true;
        public void MarcarVisitanteComoTemporario() => VisitantePermanente = false;






        /// Outros Metodos 
        public bool TemVeiculo
        {
            get
            {
                if (PlacaVeiculo != null && PlacaVeiculo.Length == 7)
                {
                    return true;
                }
                return false;
            }
        } 

       
        

        //public ValidationResult AdicionarVisita(Visita visitaNova)
        //{
        //    var verificadorDeHorariosConflitantes = new VerificadorDeHorariosConflitantes();

        //    _Visitas.Add(visitaNova);

        //    return ValidationResult;
        //}
       
    }
}
