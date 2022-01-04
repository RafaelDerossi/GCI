using System;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace GCI.Core.DomainObjects
{
    public abstract class Document : IDocument
    {
        [JsonIgnore]
        public ObjectId Id { get; set; }

        public DateTime CriadoEm => Id.CreationTime;

        public bool Lixeira { get; set; }

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;
    }
}