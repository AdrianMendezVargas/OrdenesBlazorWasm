using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrdenesBlazorWasm.Shared.Models {
    public class Orden {

        [Key]
        public int OrdenId { get; set; }

        [Required]
        public int SuplidorId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public void CalcularMonto() {
            Monto = 0;
            foreach (var pedido in Pedidos) {
                Monto += pedido.Costo;
            }
        }

    }
}
