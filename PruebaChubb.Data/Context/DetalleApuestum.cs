using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaChubb.Data.Context
{
    public partial class DetalleApuestum
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdApuesta { get; set; }
        public int IdUsuario { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string Color { get; set; } = null!;
        public int Numero { get; set; }
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Monto { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal ValorGanado { get; set; }
        public int Tipo { get; set; }

        [ForeignKey(nameof(IdApuesta))]
        [InverseProperty(nameof(Apuestum.DetalleApuesta))]
        public virtual Apuestum IdApuestaNavigation { get; set; } = null!;
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.DetalleApuesta))]
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        [ForeignKey(nameof(Tipo))]
        [InverseProperty(nameof(TipoApuestum.DetalleApuesta))]
        public virtual TipoApuestum TipoNavigation { get; set; } = null!;
    }
}
