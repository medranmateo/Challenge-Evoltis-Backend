namespace Evoltis_Challenge.Models.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> GetListProductos();
        Task<Producto> GetProducto(int id);
        Task DeleteProducto(Producto producto);
        Task<Producto> AddProducto(Producto producto);
        Task UpdateProducto(Producto producto);
    }
}
