using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Actions
{
    public interface IRuletaAction
    {
        Task<Response<Ruleta> >SaveRuleta(RuletaParameter ruleta);
        Task<Response<RuletaResult>> GetRuletas();
        Task<Response<Ruleta>> GetRuleta(int idRuleta);
        Task<Response<Ruleta>> ChageStateRuleta(int idRuleta);
       
    }

    public interface IRuletaRepositoryAction: IRuletaAction
    {
        Task<Response<bool>> Cerrar(int idRuleta, int numeroGanador, string colorGanador);
    }

    public interface IRuletaBusinessAction: IRuletaAction
    {
        Task<Response<bool>> Cerrar(int idRuleta);
        CierreResult CerrarRuleta(List<DetalleApuesta> detalleApuestas);
    }
}

