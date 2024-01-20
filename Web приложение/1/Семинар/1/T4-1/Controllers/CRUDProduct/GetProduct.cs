using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using T4_1.Model;

namespace T4_1.Controllers.CRUDProduct
{
    [ApiController]
    [Route("[controller]")]
    public class GetProduct : ControllerBase
    {

        [HttpGet(Name = "GetProduct")]
        public ActionResult<List<string>> Get()
        {

            using (var ctx = new ProductsDbContext())
            {
                var prods = ctx.Products.ToList();
                var result = new List<string>();
                foreach (var item in prods)
                {
                    result.Add(item.ToString());
                }

                return result;
            }
        }
    }
}
