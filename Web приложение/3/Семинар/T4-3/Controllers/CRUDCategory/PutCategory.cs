using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using T4_1.Model;

namespace T4_1.Controllers.CRUDCategory
{
    [ApiController]
    [Route("[controller]")]
    public class PutCategory : ControllerBase
    {

        [HttpPut(Name = "PutCategory")]
        public ActionResult Put(string key, string value)
        {

            return StatusCode(500);
        }

    }
}
