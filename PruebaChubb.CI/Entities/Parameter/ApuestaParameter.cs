using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Entities.Parameter
{
    public class ApuestaParameter
    {
        public int IdRuleta { get; set; }
        public int IdUsuario { get; set; }
        public string Color { get; set; } = null!;
        public int Numero { get; set; }
        public decimal Monto { get; set; }
        public int Tipo { get; set; }
    }
}
