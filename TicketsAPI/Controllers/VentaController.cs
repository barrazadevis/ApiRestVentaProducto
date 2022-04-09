using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroInfraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketCore.Interfaces;

namespace RegistroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaProductoRepository _ventaProductoRepository;

        public VentaController(IVentaProductoRepository ventaProductoRepository)
        {
            _ventaProductoRepository = ventaProductoRepository;
        }

        [HttpGet]
        public IActionResult GetVentas([FromQuery] Venta venta)
        {
            var ventas = _ventaProductoRepository.GetVentas(venta);
            return Ok(ventas);
        }

        [HttpGet("{idVenta}")]
        public async Task<IActionResult> GetVenta(int idVenta)
        {
            var venta = await _ventaProductoRepository.GetVenta(idVenta);
            return Ok(venta);
        }

        [HttpPost]
        public async Task<IActionResult> PostVenta(Venta venta)
        {
            await _ventaProductoRepository.InsertVenta(venta);
            return Ok(venta);
        }

        [HttpPut]
        public async Task<IActionResult> PutVenta(Venta venta)
        {
            await _ventaProductoRepository.UpdateVenta(venta);
            return Ok(venta);
        }

        [HttpDelete("{idVenta}")]
        public async Task<IActionResult> DeleteVenta(int idVenta)
        {
            var result = await _ventaProductoRepository.DeleteVenta(idVenta);
            return Ok(result);
        }
    }
}
