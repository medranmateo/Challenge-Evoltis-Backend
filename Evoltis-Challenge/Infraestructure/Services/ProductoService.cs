using Evoltis_Challenge.Models;
using Evoltis_Challenge.Models.Repositories;
using Evoltis_Challenge.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Evoltis_Challenge.Infraestructure.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Producto> AddProducto(Producto producto)
        {
            try
            {

                return await _repository.AddProducto(producto);

            }
            catch (Exception e)
            {
                var message = e.Message;
                throw;
            }
        }

        public async Task DeleteProducto(Producto producto)
        {
             await _repository.DeleteProducto(producto);
        }

        public async Task<List<Producto>> GetListProductos()
        {
            return await _repository.GetListProductos();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _repository.GetProducto(id);
        }

        public async Task UpdateProducto(Producto producto)
        {
            await _repository.UpdateProducto(producto);
        }
    }
}
