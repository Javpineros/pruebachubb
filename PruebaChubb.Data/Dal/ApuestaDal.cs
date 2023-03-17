using PruebaChubb.CI;
using PruebaChubb.CI.Actions;
using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.Data.Dal
{
    public class ApuestaDal : IApuestaRepositoryAction
    {
        Response<bool> response;
        private readonly IApuestaDetalleRepositoryAction _apuestaDetalleRepositoryAction;
        public ApuestaDal(IApuestaDetalleRepositoryAction apuestaDetalleRepositoryAction)
        {
            response = new(); 
            _apuestaDetalleRepositoryAction = apuestaDetalleRepositoryAction;
        }
        public async Task<Response<bool>> SaveApuesta(ApuestaParameter apuestaParameter)
        {

            try
            {
                Apuestum apuestum=new Apuestum();
                using (var context = new ChubbContext())
                {
                     apuestum = new Apuestum() { IdRuleta = apuestaParameter.IdRuleta };
                    context.Add(apuestum);
                    await context.SaveChangesAsync();
                }
                SaveApuestaDetalle(apuestum.IdApuesta, apuestaParameter);
                response.Entities.Add(true);
                response.Result=true;
                return response;
            }
            catch 
            {
                response.Entities.Add(false);
                return response; 
            }
        }

        private bool SaveApuestaDetalle(int idApuesta, ApuestaParameter apuestaParameter) 
        {
            _apuestaDetalleRepositoryAction.SaveApuestaDetalle( idApuesta, apuestaParameter);
            return true;
        }
    }
}
