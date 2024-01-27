using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using System.Xml.Linq;
using T4_1.Model;

namespace T4_1.Controllers.CRUDProduct
{
    [ApiController]
    [Route("[controller]")]
    public class ChangeCostProduct : ControllerBase
    {

        [HttpPatch(Name = "Change cost product")]
        public ActionResult ChangeCost(string name, int newCost)
        {

            using (var ctx = new ProductsDbContext())
            {
                try
                {
                    var prods = ctx.Products.FirstOrDefault(x => x.Name.Equals(name));
                    if (prods != null)
                    {
                        prods.Cost = newCost;
                        ctx.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    StatusCode(500);
                }

            }
            return Ok();
        }
    }
}
