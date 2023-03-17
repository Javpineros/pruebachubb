using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaChubb.Data.Context
{
    public partial class Apuestum
    {
        public Apuestum()
        {
            DetalleApuesta = new HashSet<DetalleApuestum>();
        }

        [Key]
        public int IdApuesta { get; set; }
        public int IdRuleta { get; set; }
        public int? NumeroGanador { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? ColorGanador { get; set; }

        [ForeignKey(nameof(IdRuleta))]
        [InverseProperty(nameof(Ruletum.Apuesta))]
        public virtual Ruletum IdRuletaNavigation { get; set; } = null!;
        [InverseProperty(nameof(DetalleApuestum.IdApuestaNavigation))]
        public virtual ICollection<DetalleApuestum> DetalleApuesta { get; set; }
    }
}
