using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaChubb.Data.Context
{
    public partial class TipoApuestum
    {
        public TipoApuestum()
        {
            DetalleApuesta = new HashSet<DetalleApuestum>();
        }

        [Key]
        public int IdTipoApuesta { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? DescripcionTipo { get; set; }

        [InverseProperty(nameof(DetalleApuestum.TipoNavigation))]
        public virtual ICollection<DetalleApuestum> DetalleApuesta { get; set; }
    }
}
