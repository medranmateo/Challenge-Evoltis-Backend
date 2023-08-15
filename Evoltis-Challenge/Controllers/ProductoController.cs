using AutoMapper;
using Evoltis_Challenge.Models;
using Evoltis_Challenge.Models.DataObjects;
using Evoltis_Challenge.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evoltis_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductoService _productoService;


        public ProductoController(IMapper mapper, IProductoService productoService)
        {
            _mapper = mapper;
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listProductos = await _productoService.GetListProductos();

                var listProductosDto = _mapper.Map<IEnumerable<ProductoDTO>>(listProductos);

                return Ok(listProductosDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var producto = await _productoService.GetProducto(id);

                if (producto == null)
                {
                    return NotFound();
                }

                var productoDTO = _mapper.Map<ProductoDTO>(producto);

                return Ok(productoDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producto = await _productoService.GetProducto(id);

                if (producto == null)
                {
                    return NotFound();
                }

                await _productoService.DeleteProducto(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoDTO productoDTO)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);


                producto = await _productoService.AddProducto(producto);

                var productoItemDto = _mapper.Map<ProductoDTO>(producto);

                return CreatedAtAction("Get", new { id = productoItemDto.Id }, productoItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoDTO productoDTO)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);

                if (id != producto.Id)
                {
                    return BadRequest();
                }

                var productoItem = await _productoService.GetProducto(id);

                if (productoItem == null)
                {
                    return NotFound();
                }

                await _productoService.UpdateProducto(producto);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
