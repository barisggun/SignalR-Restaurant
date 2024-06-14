using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.ProductDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _ProductService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product Product = new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductName = createProductDto.ProductName,
                Price = createProductDto.Price,
                ProductStatus = createProductDto.ProductStatus
            };
            _ProductService.TAdd(Product);
            return Ok("Product added");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _ProductService.TGetByID(id);
            _ProductService.TDelete(values);

            return Ok("Product deleted");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product Product = new Product()
            {
                ProductID = updateProductDto.ProductID,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                ProductName = updateProductDto.ProductName,
                Price = updateProductDto.Price,
            };
            _ProductService.TUpdate(Product);
            return Ok("Product updated");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetByID(id);
            return Ok(value);
        }
    }
}
