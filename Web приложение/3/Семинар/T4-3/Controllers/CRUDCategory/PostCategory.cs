using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using T4_1.Model;

namespace T4_1.Controllers.CRUDCategory
{
    [ApiController]
    [Route("[controller]")]
    public class PostCategory : ControllerBase
    {

        [HttpPost(Name = "PostCategory")]
        public ActionResult Post(string name, string description)
        {
            try
            {
                using (var ctx = new ProductsDbContext())
                {
                    var postCat = new Category(name, description);

                    ctx.Categories.Add(postCat);
                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(409);
            }

        }

    }
}
