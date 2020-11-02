using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdenesBlazorWasm.Server.DAL;
using OrdenesBlazorWasm.Shared.Models;

namespace OrdenesBlazorWasm.Server.Controllers {
    [Route("ordenes")]
    [ApiController]
    public class OrdenesController : ControllerBase {

        private readonly Contexto contexto;

        public OrdenesController(Contexto _contexto) {
            contexto = _contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Orden>>> GetOrdenes() {
            return await contexto.Ordenes.Include(o => o.Pedidos).ToListAsync();
        }

        [HttpGet("{ordenId}")]
        public async Task<ActionResult<Orden>> Buscar(int ordenId) {
            return await contexto.Ordenes.Include(o => o.Pedidos).Where(o => o.OrdenId == ordenId).FirstOrDefaultAsync();
        }

        [HttpDelete("{ordenId}")]
        public async Task<ActionResult<bool>> Eliminar(int ordenId) {
            bool eliminada = false;

            var orden = await contexto.Ordenes.FindAsync(ordenId);

            if (orden != null) {
                contexto.Entry(orden).State = EntityState.Deleted;
                eliminada = await contexto.SaveChangesAsync() > 0;
            }
            return eliminada;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Orden orden) {

            if (await Existe(orden.OrdenId)) {
                return await Modificar(orden);
            } else {
                return await Insertar(orden);
            }

        }

        public async Task<ActionResult<bool>> Insertar(Orden orden) {
            contexto.Ordenes.Add(orden);
            return (await contexto.SaveChangesAsync() > 0);
        }


        public async Task<ActionResult<bool>> Modificar(Orden orden) {


            await contexto.Database.ExecuteSqlRawAsync($"Delete from Pedido Where OrdenId = {orden.OrdenId}");

            foreach (var ordenDetalle in orden.Pedidos) {
                contexto.Entry(ordenDetalle).State = EntityState.Added;
            }

            contexto.Entry(orden).State = EntityState.Modified;

            bool paso = await contexto.SaveChangesAsync() > 0;

            return paso;
        }

        public async Task<bool> Existe(int ordenId) {
            return await contexto.Ordenes.AnyAsync(o => o.OrdenId == ordenId);
        }

    }
}
