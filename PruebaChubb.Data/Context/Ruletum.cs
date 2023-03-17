using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaChubb.Data.Context
{
    public partial class Ruletum
    {
        public Ruletum()
        {
            Apuesta = new HashSet<Apuestum>();
        }

        [Key]
        [Column("idRuleta")]
        public int IdRuleta { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column("estado")]
        public bool? Estado { get; set; }

        public int? NumeroGanador { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? ColorGanador { get; set; }

        [InverseProperty(nameof(Apuestum.IdRuletaNavigation))]
        public virtual ICollection<Apuestum> Apuesta { get; set; }
    }
}
