using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaChubb.Data.Context
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            DetalleApuesta = new HashSet<DetalleApuestum>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? Nombre { get; set; }

        [InverseProperty(nameof(DetalleApuestum.IdUsuarioNavigation))]
        public virtual ICollection<DetalleApuestum> DetalleApuesta { get; set; }
    }
}
