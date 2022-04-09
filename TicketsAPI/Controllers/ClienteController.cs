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
    public class ClienteController : ControllerBase
    {
        private readonly IVentaProductoRepository _ventaProductoRepository;

        public ClienteController(IVentaProductoRepository ventaProductoRepository)
        {
            _ventaProductoRepository = ventaProductoRepository;
        }

        [HttpGet]
        public IActionResult GetClientes([FromQuery] Cliente cliente)
        {
            var clientes = _ventaProductoRepository.GetClientes(cliente);
            return Ok(clientes);
        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetCliente(int idCliente)
        {
            var cliente = await _ventaProductoRepository.GetCliente(idCliente);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(Cliente cliente)
        {
            await _ventaProductoRepository.InsertCliente(cliente);
            return Ok(cliente);
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(Cliente cliente)
        {
            await _ventaProductoRepository.UpdateCliente(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> DeleteCliente(int idCliente)
        {
            var result = await _ventaProductoRepository.DeleteCliente(idCliente);
            return Ok(result);
        }
    }
}
