using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Entities.Repository
{
    public  class DetalleApuesta
    {
        public int IdDetalle { get; set; }
        public int IdApuesta { get; set; }
        public int IdUsuario { get; set; }
        public string Color { get; set; } = null!;
        public int Numero { get; set; }
        public decimal Monto { get; set; }
        public decimal ValorGanado { get; set; }
        public int Tipo { get; set; }
    }
}
