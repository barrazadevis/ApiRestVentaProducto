using Microsoft.EntityFrameworkCore;
using RegistroInfraestructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicketCore.Entities;
using TicketCore.Interfaces;

namespace TicketInfraestructure.Repositories
{
    public class VentaProductoRepository : IVentaProductoRepository
    {
        private readonly VentaProductoContext _context;
        public VentaProductoRepository(VentaProductoContext context)
        {
            _context = context;
        }
        #region Metodos Cliente
        public PageList<Cliente> GetClientes(Cliente cliente)
        {
            var clientes = _context.Cliente.ToList();

            if (!String.IsNullOrEmpty(cliente.Cedula))
            {
                clientes = clientes.Where(x => x.Cedula == cliente.Cedula).ToList();
            }
            if (!String.IsNullOrEmpty(cliente.Nombre))
            {
                clientes = clientes.Where(x => x.Nombre == cliente.Nombre).ToList();
            }
            if (!String.IsNullOrEmpty(cliente.Apellido))
            {
                clientes = clientes.Where(x => x.Apellido == cliente.Apellido).ToList();
            }
            if (!String.IsNullOrEmpty(cliente.Telefono))
            {
                clientes = clientes.Where(x => x.Telefono == cliente.Telefono).ToList();
            }

            var pageCliente = PageList<Cliente>.Create(clientes, 1, clientes.Count);

            return pageCliente;
        }
        public async Task<Cliente> GetCliente(int idCliente)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(x => x.IdCliente == idCliente);

            return cliente;
        }

        public async Task<Cliente> GetCliente(string cedula)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(x => x.Cedula == cedula);

            return cliente;
        }

        public async Task InsertCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            var currentCliente = await GetCliente(cliente.IdCliente);
            currentCliente.Cedula = cliente.Cedula;
            currentCliente.Nombre = cliente.Nombre;
            currentCliente.Apellido = cliente.Apellido;
            currentCliente.Telefono = cliente.Telefono;

            await _context.SaveChangesAsync();
            return currentCliente;
        }

        public async Task<bool> DeleteCliente(int idCliente)
        {
            var currentCliente = await GetCliente(idCliente);
            _context.Cliente.Remove(currentCliente);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        #endregion

        #region Metodos Producto
        public PageList<Producto> GetProductos(Producto producto)
        {
            var productos = _context.Producto.ToList();

            if (!String.IsNullOrEmpty(producto.Nombre))
            {
                productos = productos.Where(x => x.Nombre == producto.Nombre).ToList();
            }
            if (producto.ValorUnitario > 0 || producto.ValorUnitario != null)
            {
                productos = productos.Where(x => x.ValorUnitario == producto.ValorUnitario).ToList();
            }
            
            var pageProducto = PageList<Producto>.Create(productos, 1, productos.Count);

            return pageProducto;
        }

        public async Task<Producto> GetProducto(int idProducto)
        {
            var producto = await _context.Producto.FirstOrDefaultAsync(x => x.IdProducto == idProducto);

            return producto;
        }

        public Task<Producto> ObtenerProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public async Task InsertProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<Producto> UpdateProducto(Producto producto)
        {
            var currentProducto = await GetProducto(producto.IdProducto);
            currentProducto.Nombre = producto.Nombre;
            currentProducto.ValorUnitario = producto.ValorUnitario;

            await _context.SaveChangesAsync();
            return currentProducto; 
        }
        
        public async Task<bool> DeleteProducto(int idProducto)
        {
            var currentProducto = await GetProducto(idProducto);
            _context.Producto.Remove(currentProducto);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        #endregion

        #region Metodo Venta
        public async Task<Venta> GetVenta(int idVenta)
        {
            var venta = await _context.Venta.FirstOrDefaultAsync(x => x.IdVenta == idVenta);

            return venta;
        }

        public PageList<Venta> GetVentas(Venta venta)
        {
            var ventas = _context.Venta.ToList();
            
            var pageVenta = PageList<Venta>.Create(ventas, 1, ventas.Count);

            return pageVenta;
        }

        public async Task<Venta> UpdateVenta(Venta venta)
        {
            var currentVenta = await GetVenta(venta.IdVenta);
            currentVenta.Cantidad = venta.Cantidad;
            currentVenta.ValorUnitario = venta.ValorUnitario;
            currentVenta.ValorTotal = venta.ValorTotal;

            await _context.SaveChangesAsync();
            return currentVenta;
        }

        public async Task InsertVenta(Venta venta)
        {
            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteVenta(int idVenta)
        {
            var currentVenta = await GetVenta(idVenta);
            _context.Venta.Remove(currentVenta);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        #endregion
        
    }
}
