using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.ArquivoDigital.App.Aplication.Commands
{
    public class ArquivoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string NomeOriginal { get; protected set; }

        public string Extensao { get; protected set; }

        public int Tamanho { get; protected set; }

        public Guid CondominioId { get; protected set; }

        public Guid PastaId { get; protected set; }

        public bool Publico { get; protected set; }




        public void SetNome(string nome) => Nome = nome;

        public void SetNomeOriginal(string nomeOriginal) => NomeOriginal = nomeOriginal;

        public void SetExtensao(string extensao)
        {
            if (String.IsNullOrEmpty(extensao))
            {
                Extensao = "";
                return;
            }

            switch (extensao)
            {
                case "application/pdf":
                    Extensao = "pdf";
                    break;
                case "text/plain":
                    Extensao = "txt";
                    break;
                case "image/bmp":
                    Extensao = "bmp";
                    break;
                case "image/gif":
                    Extensao = "gif";
                    break;
                case "image/png":
                    Extensao = "png";
                    break;
                case "image/jpeg":
                    Extensao = "jpeg";
                    break;
                case "image/jpg":
                    Extensao = "jpg";
                    break;
                case "application/vnd.ms-excel":
                    Extensao = "xls";
                    break;
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    Extensao = "xlsx";
                    break;
                case "text/csv":
                    Extensao = "csv";
                    break;
                case "text/html":
                    Extensao = "html";
                    break;
                case "text/xml":
                    Extensao = "xml";
                    break;
                case "application/zip":
                    Extensao = "zip";
                    break;
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    Extensao = "docx";
                    break;
                case "application/msword":
                    Extensao = "word";
                    break;

                default:
                    Extensao = extensao;
                    break;
            }
        }

        public void SetTamanho(int tamanho) => Tamanho = tamanho;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void SetPastaId(Guid pastaId) => PastaId = pastaId;

        public void MarcarComoPublico() => Publico = true;

        public void MarcarComoPrivado() => Publico = false;

       
    }
}
