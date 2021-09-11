﻿using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Comunicados.App.ViewModels
{
    public class ComunicadoViewModel
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }        

        public string NomeCondominio { get; set; }       

        public string NomeFuncionario { get; set; }

        public string FotoFuncionario { get; set; }

        public IEnumerable<UnidadeComunicadoViewModel> Unidades { get; set; }


        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataDeRealizacao { get; set; }

        public Guid CondominioId { get; set; }

        public Guid FuncionarioId { get; set; }

        public VisibilidadeComunicado Visibilidade { get; set; }

        public CategoriaComunicado Categoria { get; set; }

        public bool CriadoPelaAdministradora { get; set; }

        public IEnumerable<AnexoComunicadoViewModel> Anexos { get; set; }

        public bool TemAnexos
        {
            get
            {
                bool temAnexos = false;
                if (Anexos != null)
                {
                    temAnexos = Anexos.Count() > 0;
                }
                return temAnexos;
            }
        }

   
    }
}