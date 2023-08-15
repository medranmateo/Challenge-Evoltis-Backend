namespace Evoltis_Challenge.Models.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetListProductos();
        Task<Producto> GetProducto(int id);
        Task DeleteProducto(Producto producto);
        Task<Producto> AddProducto(Producto producto);
        Task UpdateProducto(Producto producto);
    }
}
