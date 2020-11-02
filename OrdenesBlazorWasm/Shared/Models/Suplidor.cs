using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdenesBlazorWasm.Shared.Models {
    public class Suplidor {

        [Key]
        public int SuplidorId { get; set; }

        [Required]
        public string Nombre { get; set; }

    }
}
