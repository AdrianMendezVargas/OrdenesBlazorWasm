using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesBlazorWasm.Shared.Models {
    public class Producto {
        [Key, Range(minimum: 0 , maximum: int.MaxValue)]
        public int ProductoId { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required, Range(minimum: 0 , maximum: ((double) decimal.MaxValue))]
        public decimal Precio { get; set; }

        [Required, Range(minimum: 1 , maximum: int.MaxValue)]
        public int Existencia { get; set; }

        public virtual decimal ValorInventario => Precio * Existencia;
    }
}
