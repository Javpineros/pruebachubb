using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI.Entities.Repository
{
    public class Ruleta
    {
        public int IdRuleta { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
