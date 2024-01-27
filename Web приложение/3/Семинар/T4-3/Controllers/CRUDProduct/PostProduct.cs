using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using System.Xml.Linq;
using T4_1.Model;
using T4_1.Model.DTO;
using T4_1.Repo;

namespace T4_1.Controllers.CRUDProduct
{
    [ApiController]
    [Route("[controller]")]
    public class PostProduct : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public PostProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost(Name = "PostProduct")]
        public ActionResult Post([FromBody] ProductDTO productDTO)
        {
            _productRepository.AddProduct(productDTO);
            return Ok();
        }

    }
}

/*        [HttpPost(Name = "PostProduct")]
        public ActionResult Post(string name, string description, int cost, string category, string store)
        {
            try
            {
                using (var ctx = new ProductsDbContext())
                {
                    var prods = ctx.Products.FirstOrDefault(x => x.Name.Equals(name));
                    var cats = ctx.Categories.FirstOrDefault(x => x.Name.Equals(category));
                    var stors = ctx.Stores.FirstOrDefault(x => x.Name.Equals(store));
                    if (cats == null)
                    {
                        return BadRequest("Категории не существует");
                    }

                    if (stors == null)
                    {
                        return BadRequest("Склада не существует");
                    }

                    if (prods == null)
                    {
                        var newProduct = new Product(name, description, cost);
                        newProduct.Category = cats;
                        newProduct.Stores = stors;
                        ctx.Products.Add(newProduct);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(500);
                
            }

        }
*/