using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketCore.Interfaces;

namespace RegistroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteVentaController : ControllerBase
    {
        private readonly IVentaProductoRepository _ventaProductoRepository;

        public ClienteVentaController(IVentaProductoRepository ventaProductoRepository)
        {
            _ventaProductoRepository = ventaProductoRepository;
        }

        [HttpGet ("{cedula}")]
        public async Task<IActionResult> GetCliente(string cedula)
        {
            var cliente = await _ventaProductoRepository.GetCliente(cedula);
            return Ok(cliente);
        }
    }
}
