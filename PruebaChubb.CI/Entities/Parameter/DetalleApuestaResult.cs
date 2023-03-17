using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Entities.Parameter
{
    public  class DetalleApuestaResult
    {
        
        public int IdRuleta { get; set; }
        public int IdUsuario { get; set; }
        public string Color { get; set; } = null!;
        public int Numero { get; set; }
        public decimal Monto { get; set; }
        public decimal ValorGanado { get; set; }
        public string Tipo { get; set; } = null!;
    }
}
