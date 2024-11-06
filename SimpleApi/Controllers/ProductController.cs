using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.BLL.Models;
using SimpleApi.BLL.Service.Intrfaces;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel product)
        {
            try
            {
                if (product != null)
                {
                    _productService.Add(product);
                    return Ok("Product Added successfully");
                }
                else {
                    return BadRequest("Enter valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult GetProduct(int id)
        {
            try
            {
                return Ok(_productService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok("Product Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductViewModel product)
        {
            try
            {
                if (product != null)
                {
                    _productService.Update(product);
                    return Ok("Product Updated successfully");
                }
                else {
                    return BadRequest("Enter valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult ListProducts(int start = 0, int size = 10)
        {

            try
            {
                return Ok(_productService.List(start,size));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}
