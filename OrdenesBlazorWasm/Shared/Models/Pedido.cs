using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdenesBlazorWasm.Shared.Models {
    public class Pedido {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrdenId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Range(minimum:1, maximum:int.MaxValue)]
        public int Cantidad { get; set; }

        public decimal Costo { get; set; }
    }
}
