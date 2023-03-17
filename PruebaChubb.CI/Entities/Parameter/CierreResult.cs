using PruebaChubb.CI.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Entities.Parameter
{
    public class CierreResult
    {
        public List<DetalleApuesta> DetalleApuestas { get; set; }
        public int NumeroGanador { get; set; }
        public string ColorGanador { get; set; } = null!;

    }
}
