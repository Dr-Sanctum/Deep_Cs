using Microsoft.AspNetCore.Mvc;
using Server.Db.Model;
using System.Text;
using T4_1.Model;

namespace T4_1.Controllers
{


    public class GetCsvFile : ControllerBase
    {
        private string GetCsv(IEnumerable<Product> products)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in products)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }


        [HttpGet(Name = "GetFile")]
        public FileContentResult GetFileCsv()
        {
            using (var ctx = new ProductsDbContext())
            {
                var prods = ctx.Products.ToList();

                var content = GetCsv(prods);

                return File(new System.Text.UTF8Encoding().GetBytes(content), "text/csv", "report.csv");
            }
        }
    }
}
