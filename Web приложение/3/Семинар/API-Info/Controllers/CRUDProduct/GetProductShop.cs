using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using T4_1.Model;
using T4_1.Repo;

namespace T4_1.Controllers.CRUDProduct
{
    [ApiController]
    [Route("[controller]")]
    public class GetProductShop : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public GetProductShop(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetProduct")]
        public ActionResult Get()
        {
            var products = _productRepository.GetProducts();


            return Ok(products);
        }
    }
}

/*
[HttpGet(Name = "GetProduct")]
public ActionResult Get()
{

    using (var ctx = new ProductsDbContext())
    {
        var prods = ctx.Products.ToList();

        var result = new List<string>();
        foreach (var item in prods)
        {
            result.Add(item.ToString());
        }

        return Ok(prods);
    }
}
*/