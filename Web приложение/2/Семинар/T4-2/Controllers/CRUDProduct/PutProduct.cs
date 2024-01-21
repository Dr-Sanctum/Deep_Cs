using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using T4_1.Model;

namespace T4_1.Controllers.CRUDProduct
{
    [ApiController]
    [Route("[controller]")]
    public class PutProduct : ControllerBase
    {

        [HttpPut(Name = "PutProduct")]
        public ActionResult Put(string key, string value)
        {

            return StatusCode(500);
        }

    }
}
