using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using T4_1.Model;

namespace T4_1.Controllers.CRUDCatrgory
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteCategory : ControllerBase
    {

        [HttpDelete(Name = "DeleteCategory")]
        public ActionResult Delete(string Name)
        {
            using (var ctx = new ProductsDbContext())
            {
                try
                {
                    var prods = ctx.Categories.FirstOrDefault(x => x.Name.Equals(Name));
                    if (prods != null)
                    {
                        ctx.Categories.Remove(prods);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest("Нельзя удалить категорию с продуктами");
                }
                
            }
            return Ok();
        }
    }
}
