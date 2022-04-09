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
    public class ProductoController : ControllerBase
    {
        private readonly IVentaProductoRepository _ventaProductoRepository;

        public ProductoController(IVentaProductoRepository ventaProductoRepository)
        {
            _ventaProductoRepository = ventaProductoRepository;
        }

        [HttpGet]
        public IActionResult GetProductos([FromQuery] Producto producto)
        {
            var productos = _ventaProductoRepository.GetProductos(producto);
            return Ok(productos);
        }

        [HttpGet("{idProducto}")]
        public async Task<IActionResult> GetProducto(int idProducto)
        {
            var producto = await _ventaProductoRepository.GetProducto(idProducto);
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto(Producto producto)
        {
            await _ventaProductoRepository.InsertProducto(producto);
            return Ok(producto);
        }

        [HttpPut]
        public async Task<IActionResult> PutProducto(Producto producto)
        {
            await _ventaProductoRepository.UpdateProducto(producto);
            return Ok(producto);
        }

        [HttpDelete("{idProducto}")]
        public async Task<IActionResult> DeleteProducto(int idProducto)
        {
            var result = await _ventaProductoRepository.DeleteProducto(idProducto);
            return Ok(result);
        }
    }
}
