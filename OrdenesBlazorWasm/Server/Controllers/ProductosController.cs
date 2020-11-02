using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdenesBlazorWasm.Server.DAL;
using OrdenesBlazorWasm.Shared.Models;

namespace OrdenesBlazorWasm.Server.Controllers {
    [Route("Productos")]
    [ApiController]
    public class ProductosController : ControllerBase {

        private readonly Contexto contexto;

        public ProductosController(Contexto _contexto) {
            contexto = _contexto;
        }

        [HttpGet]
        public async Task<List<Producto>> GetOrdenes() {
            return await contexto.Productos.ToListAsync();
        }

        [HttpGet("{productoId}")]
        public async Task<Producto> Buscar(int productoId) {
            return await contexto.Productos.Where(p => p.ProductoId == productoId).FirstOrDefaultAsync();
        }

    }
}
