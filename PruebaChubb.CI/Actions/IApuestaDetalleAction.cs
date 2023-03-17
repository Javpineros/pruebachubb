using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Actions
{
    
        public interface IApuestaDetalleAction
        {
            Task<Response<bool>> SaveApuestaDetalle(int idApuesta, ApuestaParameter apuestaParameter);
        Task<Response<bool>> UpdateApuestaDetalle(List<DetalleApuesta> detalleApuestas);
        Task<Response<DetalleApuesta>> GetApuestas(int idRuleta);
    }

        public interface IApuestaDetalleRepositoryAction : IApuestaDetalleAction
        {
        }

        public interface IApuestaDetalleBusinessAction : IApuestaDetalleAction
        {
        }
    
}

