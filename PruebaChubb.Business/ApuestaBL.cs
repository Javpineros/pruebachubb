using PruebaChubb.CI;
using PruebaChubb.CI.Actions;
using PruebaChubb.CI.Entities.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.Business
{
    public class ApuestaBL : IApuestaBusinessAction
    {
        private readonly IApuestaRepositoryAction _apuestaRepositoryAction;
        Response<bool> response;
        public ApuestaBL(IApuestaRepositoryAction apuestaRepositoryAction) { 
            _apuestaRepositoryAction=   apuestaRepositoryAction;
            response = new();
        }
        public async Task<Response<bool>> SaveApuesta(ApuestaParameter apuestaParameter)
        {
            response= await _apuestaRepositoryAction.SaveApuesta(apuestaParameter);
            response.Messages.Add(rcMessages.ApuestaCreada);
            return response;    
        }
    }
}
