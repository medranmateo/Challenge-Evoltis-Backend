using Evoltis_Challenge.Models;
using Evoltis_Challenge.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evoltis_Challenge.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> AddProducto(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task DeleteProducto(Producto producto)
        {
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producto>> GetListProductos()
        {
            return await _context.Producto.ToListAsync();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Producto.FindAsync(id);
        }

        public async Task UpdateProducto(Producto producto)
        {
            var productoItem = await _context.Producto.FirstOrDefaultAsync(x => x.Id == producto.Id);

            if (productoItem != null)
            {
                productoItem.Codigo = producto.Codigo;
                productoItem.Nombre = producto.Nombre;
                productoItem.Categoria = producto.Categoria;
                productoItem.Stock = producto.Stock;
                productoItem.Precio = producto.Precio;

                await _context.SaveChangesAsync();

            }
        }
    }
}
