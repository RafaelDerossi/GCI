﻿using System;

namespace CondominioApp.ArquivoDigital.App.Models
{
    public class AtualizaArquivoViewModel
    {
        public Guid Id { get; set; }        

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool Publico { get; set; }

        public string NomeArquivo { get; set; }

        public string NomeOriginal { get; set; }
        
    }
}