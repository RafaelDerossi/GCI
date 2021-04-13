using System.ComponentModel;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Infra.Data.Repository;
using CondominioApp.Principal.Infra.DataQuery;
using Microsoft.EntityFrameworkCore;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.Principal.Infra.Data.Repository;
using CondominioApp.ReservaAreaComum.Infra.Data;
using CondominioApp.Core.Mediator;
using MediatR;
using System;
using System.Collections.Generic;

namespace CondominioApp.ReservaAreaComum.Aplication.FilaDeReservas
{
    public class FilaDeReservaWorker : IFilaDeReservaWorker
    {
        IReservaAreaComumRepository _reservaAreaComumQuery;

        public FilaDeReservaWorker(IReservaAreaComumRepository reservaAreaComumQuery)
        {
            _reservaAreaComumQuery  = reservaAreaComumQuery;
        }

        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public void Start()
        {
            if (_backgroundWorker.IsBusy != true)
            {
                
                _backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
                _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);

                // Start the asynchronous operation.                
                _backgroundWorker.RunWorkerAsync(_reservaAreaComumQuery);
                return;
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReservaAreaComumRepository _reservaAreaComumQuery = e.Argument as ReservaAreaComumRepository;

            while (true)
           {
                if (_reservaAreaComumQuery.ObterQtdDeReservasProcessando().Result > 0)
                {
                    var solicitacao =  _reservaAreaComumQuery.ObterPrimeiraNaFilaParaSerProcessada().Result;

                    var areaComum = _reservaAreaComumQuery.ObterPorId(solicitacao.Id).Result;

                    var retorno = areaComum.ValidarReserva(solicitacao);
                    
                    if (retorno.IsValid)
                    {
                        if (areaComum.RequerAprovacaoDeReserva)
                            solicitacao.AguardarAprovacao("");

                        if (!areaComum.RequerAprovacaoDeReserva)
                            solicitacao.Aprovar("");
                    }
                    if (!retorno.IsValid)
                    {
                        
                    }
                    
                    
                    _reservaAreaComumQuery.Dispose();                    
                    System.Threading.Thread.Sleep(30000);
                }
                else
                {
                    _reservaAreaComumQuery.Dispose();                    
                    System.Threading.Thread.Sleep(60000);
                }


            }
        }


        // This event handler deals with the results of the background operation.
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
        }
      
    }
}
