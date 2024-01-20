using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using System.Xml.Linq;
using T4_1.Model;

namespace T4_1.Controllers.CRUDProduct
{
    [ApiController]
    [Route("[controller]")]
    public class PostProduct : ControllerBase
    {

        [HttpPost(Name = "PostProduct")]
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

    }
}
