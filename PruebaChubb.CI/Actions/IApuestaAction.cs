using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Actions
{
   
        public interface IApuestaAction
        {
            Task<Response<bool>> SaveApuesta(ApuestaParameter apuestaParameter);
        }

        public interface IApuestaRepositoryAction : IApuestaAction
        {
        }

        public interface IApuestaBusinessAction : IApuestaAction
        {
        }
    
}
