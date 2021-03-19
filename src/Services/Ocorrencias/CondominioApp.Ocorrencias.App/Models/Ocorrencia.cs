using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Helpers;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
   public class Ocorrencia : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Descricao { get; private set; }
        public Foto Foto { get; private set; }
        public bool Publica { get; private set; }


        public bool EmAndamento { get; private set; }
        public DateTime? DataResposta { get; private set; }
        public bool Resolvida { get; private set; }        
        public string Parecer { get; private set; }
        public DateTime? DataResolucao { get; private set; }

        public Guid UnidadeId { get; private set; }
        public Guid UsuarioId { get; private set; }                
        public Guid CondominioId { get; private set; }       
        
        public bool Panico { get; private set; }

        public Ocorrencia()
        {
        }
        public Ocorrencia
            (string descricao, Foto foto, bool publica, Guid unidadeId,
            Guid usuarioId, Guid condominioId, bool panico)
        {
            Descricao = descricao;
            Foto = foto;
            Publica = publica;            
            UnidadeId = unidadeId;
            UsuarioId = usuarioId;
            CondominioId = condominioId;            
            Panico = panico;
        }

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetFoto(Foto foto) => Foto = foto;        

        public void SetUsuarioId(Guid id) => UsuarioId = id;

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;



        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;


        public void MarcarComoOcorrenciaDePanico() => Panico = true;

        public void DesmarcarComoOcorrenciaDePanico() => Panico = false;


        public void ColocarEmAndamento()
        {
            Resolvida = false;
            Parecer = "";
            EmAndamento = true;
            DataResposta = DataHoraDeBrasilia.Get();
        }

        public void MarcarComoResolvida(string parecer)
        {
            EmAndamento = false;
            Resolvida = true;
            Parecer = parecer;           
            DataResolucao = DataHoraDeBrasilia.Get();
        }
              
    }
}
