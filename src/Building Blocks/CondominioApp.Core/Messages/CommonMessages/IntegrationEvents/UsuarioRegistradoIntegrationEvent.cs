using System;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class UsuarioRegistradoIntegrationEvent : IntegrationEvent
    {
        public string Nome { get; private set; }

        public string Apelido { get; private set; }

        public string Email { get; private set; }

        public string Celular { get; private set; }

        public string Foto { get; private set; }

        public string  NomeOriginal { get; private set; }

        public DateTime DataDeNascimento { get; private set; }

        public int Sexo { get; private set; }

        public string Logradouro { get; private set; }

        public string Complemento { get; private set; }

        public string Numero { get; private set; }

        public string Cep { get; private set; }

        public string Municipio { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string DispositivoId { get; private set; }

        public UsuarioRegistradoIntegrationEvent(Guid UsuarioId, string nome, string apelido, string email, string celular, string foto, string nomeOriginal, DateTime dataDeNascimento, 
            int sexo, string logradouro, string complemento, string numero, string cep, string municipio, string bairro, 
            string cidade, string estado, string dispositivoId)
        {
            AggregateId = UsuarioId;
            Nome = nome;
            Apelido = apelido;
            Email = email;
            Celular = celular;
            Foto = foto;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            Municipio = municipio;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            DispositivoId = dispositivoId;
            NomeOriginal = nomeOriginal;
        }
    }
}