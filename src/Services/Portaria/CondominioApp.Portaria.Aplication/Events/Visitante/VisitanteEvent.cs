using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Portaria.ValueObjects;
using System;

namespace CondominioApp.Portaria.Aplication.Events
{
    public abstract class VisitanteEvent : Event
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }
        public TipoDeDocumento TipoDeDocumento { get; protected set; }
        public Rg Rg { get; protected set; }
        public Cpf Cpf { get; protected set; }
        public Email Email { get; protected set; }
        public Foto Foto { get; protected set; }

        public Guid CondominioId { get; protected set; }
        public string NomeCondominio { get; protected set; }

        public Guid UnidadeId { get; protected set; }
        public string NumeroUnidade { get; protected set; }
        public string AndarUnidade { get; protected set; }
        public string GrupoUnidade { get; protected set; }

        public bool VisitantePermanente { get; protected set; }
        public string QrCode { get; protected set; }
        public TipoDeVisitante TipoDeVisitante { get; protected set; }
        public string NomeEmpresa { get; protected set; }

        public bool TemVeiculo { get; protected set; }
        public Veiculo Veiculo { get; protected set; }



        public void SetTipoDeDocumento(TipoDeDocumento tipoDeDocumento) => TipoDeDocumento = tipoDeDocumento;
        public void SetRg(Rg rg) => Rg = rg;
        public void SetCPF(Cpf cpf) => Cpf = cpf;
        public void SetEmail(Email email) => Email = email;       
        public void SetFoto(Foto foto) => Foto = foto;
        public void SetVeiculo(Veiculo veiculo) => Veiculo = veiculo;
        
        public void SetNome(string nome) => Nome = nome;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;
        public void SetNomeCondominio(string nomeCondominio) => NomeCondominio = nomeCondominio;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;
        public void SetNumeroUnidade(string numero) => NumeroUnidade = numero;
        public void SetAndarDaUnidade(string andar) => AndarUnidade = andar;
        public void SetGrupoDaUnidade(string grupo) => GrupoUnidade = grupo;

        public void MarcarQueTemVeiculo() => TemVeiculo = true;
        public void MarcarQueNaoTemVeiculo() => TemVeiculo = false;
    }
}
