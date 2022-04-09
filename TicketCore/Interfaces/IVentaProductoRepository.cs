using RegistroInfraestructure.Data;
using System.Threading.Tasks;
using TicketCore.Entities;

namespace TicketCore.Interfaces
{
    public interface IVentaProductoRepository
    {
        #region "Metodos de Clientes"
        PageList<Cliente> GetClientes(Cliente clienteFilters);
        Task<Cliente> GetCliente(int idCliente);

        Task<Cliente> GetCliente(string Cedula);

        Task InsertCliente(Cliente cliente);

        Task<bool> DeleteCliente(int IdCliente);

        Task<Cliente> UpdateCliente(Cliente cliente);

        #endregion

        #region "Metodos Productos"
        PageList<Producto> GetProductos(Producto productoFilters);
        Task<Producto> GetProducto(int idProducto);

        Task<Producto> ObtenerProducto(Producto producto);

        Task InsertProducto(Producto producto);

        Task<bool> DeleteProducto(int IdProducto);

        Task<Producto> UpdateProducto(Producto producto);

        #endregion

        #region "Metodos Ventas"
        PageList<Venta> GetVentas(Venta ventaFilters);
        Task<Venta> GetVenta(int idVenta);

        Task InsertVenta(Venta venta);

        Task<bool> DeleteVenta(int idVenta);

        Task<Venta> UpdateVenta(Venta venta);

        #endregion
    }
}
