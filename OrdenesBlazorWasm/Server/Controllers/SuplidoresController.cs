using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdenesBlazorWasm.Server.DAL;
using OrdenesBlazorWasm.Shared.Models;

namespace OrdenesBlazorWasm.Server.Controllers
{
    [Route("suplidores")]
    [ApiController]
    public class SuplidoresController : ControllerBase
    {
        private readonly Contexto _context;

        public SuplidoresController(Contexto context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<List<Suplidor>>> GetSuplidores()
        {
            return await _context.Suplidores.ToListAsync();
        }

    }
}
