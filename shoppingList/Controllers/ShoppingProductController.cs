using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingList.Models;

namespace shoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingProductController : ControllerBase
    {
        ShoppingProducts obj = new ShoppingProducts();
        [HttpGet]
        [Route("/plist")]
        public IActionResult GetShoppingProducts()
        {
            return Ok(obj.GetAllShoppingProducts());
        }
        [HttpGet]
        [Route("/plist/category/{ctg}")]
        public IActionResult GetEmployeeBycategory(string ctg)
        {
            try
            {
                var result = obj.GetShoppingProductsByType(ctg);               
                
                    return Ok(result);
                
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet]
        [Route("/plist/name/{name}")]
        public IActionResult GetEmployeeByName(string name)
        {
            try
            {
                var result = obj.GetShoppingProductsByName(name);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet]
        [Route("/plist/total")]
        public IActionResult GetProductTotal()
        {
            try
            {
                var result = obj.GetTotalShoppingProducts();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        [Route("/plist/stock/{stock}")]
        public IActionResult GetShoppingProductstock(bool stock)
        {
            try
            {
                var result = obj.GetInstockShoppingProducts(stock);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpPost]
        [Route("/plist/add")]
        public IActionResult AddProduct ([FromBody]ShoppingProducts shp)
        {
            try
            {
                var result = obj.AddShoppingProducts(shp);
                return Accepted("Shopping Product added");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("/plist/update")]
        public IActionResult UpdateProduct([FromBody] ShoppingProducts obj)
        {
            try
            {
                var result = obj.UpdateShoppingProducts(obj);
                return Accepted("Product updated");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/plist/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var result = obj.DeleteShoppingProducts(id);

                return Ok("Product deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        [Route("/plist/cart/add/{id}")]
        public IActionResult AddProductToCart(int id)
        {
            try
            {
                var result = obj.AddProductsToCart(id);
                return Accepted("Shopping Product added to cart");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("/clist")]
        public IActionResult GetAllCartProducts()
        {
            return Ok(obj.GetAllCartProducts());
        }
    }
}
