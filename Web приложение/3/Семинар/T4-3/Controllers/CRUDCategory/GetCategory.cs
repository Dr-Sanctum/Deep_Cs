using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using T4_1.Model;

namespace T4_1.Controllers.CRUDCategory
{
    [ApiController]
    [Route("[controller]")]
    public class GetCategory : ControllerBase
    {

        [HttpGet(Name = "GetCategory")]
        public ActionResult<List<string>> Get()
        {

                return StatusCode(500);
            
        }
    }
}
