using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace T4_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Class:ControllerBase
    {
        [HttpGet(template: "Square")]
        public int Square(int x)
        {
            return x * x;
        }

        [HttpGet(Name = "Divide")]
        public ActionResult<int> Divide(int x, int y)
        {
            try
            {
                var z = x / y;
              
                return Ok(z);
            }
            catch (DivideByZeroException e)
            {

                return BadRequest(e.Message);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

    }
}
