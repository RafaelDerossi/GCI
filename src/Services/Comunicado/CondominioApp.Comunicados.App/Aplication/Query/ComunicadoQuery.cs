using CondominioApp.Comunicados.App.Models;
using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CondominioApp.Comunicados.App.Aplication.Query
{
    public class ComunicadoQuery : IComunicadoQuery
    {
        private IComunidadoRepository _comunicadoRepository;

        public ComunicadoQuery(IComunidadoRepository comunicadoRepository)
        {
            _comunicadoRepository = comunicadoRepository;
        }


        public async Task<Comunicado> ObterPorId(Guid id)
        {
            return await _comunicadoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Comunicado>> ObterPorCondominioUnidadeEProprietario
            (Guid condominioId, Guid UnidadeId, bool IsProprietario)
        {
            //Pega Comunicados Publicos
            List<Comunicado> listaFinal = _comunicadoRepository.Obter(
                c => c.CondominioId == condominioId &&
                c.Visibilidade == VisibilidadeComunicado.PUBLICO &&
                !c.Lixeira).Result.ToList();

            if (listaFinal == null)
                listaFinal = new List<Comunicado>();

            //Pega Comunicados para a Unidade
            var listaUnidades = await _comunicadoRepository.ObterUnidades(
                c => c.Comunicado.CondominioId == condominioId &&
                c.Comunicado.Visibilidade == VisibilidadeComunicado.UNIDADES &&
                c.UnidadeId == UnidadeId && 
                !c.Lixeira);

            if (listaUnidades != null)
            {
                foreach (Unidade unidade in listaUnidades)
                {
                    var comunicado = await _comunicadoRepository.ObterPorId(unidade.ComunicadoId);
                    listaFinal.Add(comunicado);
                }
            }


           //Pega comunicados específicos para proprietario
            if (IsProprietario)
            {
                //Pega Comunicados para Proprietarios em geral
                var listaProprietario = _comunicadoRepository.Obter(
                c => c.CondominioId == condominioId &&
                c.Visibilidade == VisibilidadeComunicado.PROPRIETARIOS &&
                !c.Lixeira).Result.ToList();

                if (listaProprietario != null)
                {
                    foreach (Comunicado comunicado in listaProprietario)
                    {                        
                        listaFinal.Add(comunicado);
                    }
                }



                //Pega Comunicados para o proprietarios da Unidade específica
                var listaProprietarioUnidade = await _comunicadoRepository.ObterUnidades(
                    c => c.Comunicado.CondominioId == condominioId &&
                    c.Comunicado.Visibilidade == VisibilidadeComunicado.PROPRIETARIOS_UNIDADES &&
                    c.UnidadeId == UnidadeId &&
                    !c.Lixeira);

                if (listaProprietarioUnidade != null)
                {
                    foreach (Unidade unidade in listaProprietarioUnidade)
                    {
                        var comunicado = await _comunicadoRepository.ObterPorId(unidade.ComunicadoId);
                        listaFinal.Add(comunicado);
                    }
                }
            }

            listaFinal = listaFinal.OrderBy(c => c.DataDeCadastro).ToList();
            return listaFinal; 
        }

        public async Task<IEnumerable<Comunicado>> ObterPorCondominioEUsuario(Guid condominioId, Guid usuarioId)
        {           
            return await _comunicadoRepository.Obter(
                 c => c.CondominioId == condominioId &&
                 c.UsuarioId == usuarioId &&
                 !c.Lixeira);
        }        
                



        public void Dispose()
        {
            _comunicadoRepository?.Dispose();
        }
    }
}