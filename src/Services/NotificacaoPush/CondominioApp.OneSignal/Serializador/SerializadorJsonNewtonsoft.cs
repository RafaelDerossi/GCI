using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace CondominioApp.OneSignal.Serializador
{
  public  class SerializadorJsonNewtonsoft : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer;

        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }
        public string DateFormat { get; set; }       
        public string Namespace { get; set; }        
        public string RootElement { get; set; }        
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    _serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

       
        public SerializadorJsonNewtonsoft()
        {
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

    }
}
