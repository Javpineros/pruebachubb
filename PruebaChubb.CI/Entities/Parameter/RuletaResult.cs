using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Entities.Parameter
{
    public class RuletaResult
    {
        public int IdRuleta { get; set; }
        public string Nombre { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public int NumeroGanador { get; set; } 
        public string ColorGanador { get; set; } = null!;

        public List<DetalleApuestaResult> DetalleApuestas { get; set; }

    }
}

