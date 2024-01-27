using AutoMapper;
using Microsoft.Extensions.Hosting;
using Server.Db.Model;
using System.Xml.Linq;
using T4_1.Model;
using T4_1.Model.DTO;

namespace T4_1.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddCategory(CategoryDTO group)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(ProductDTO product)
        {

            using (var ctx = new ProductsDbContext())
            {
                var prods = ctx.Products.FirstOrDefault(x => x.Name.Equals(product.Name));
                var cats = ctx.Categories.FirstOrDefault(x => x.Name.Equals(product.Category.Name));
                var stors = ctx.Stores.FirstOrDefault(x => x.Name.Equals(product.Stores.Name));

                if (prods == null)
                {
                    var newProduct = new Product(product.Name, product.Description, product.Cost);
                    newProduct.Category = cats;
                    newProduct.Stores = stors;
                    ctx.Products.Add(newProduct);
                    ctx.SaveChanges();
                }

            }
        }
        public void AddStore(StoreDTO product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetGroups()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            using (var ctx = new ProductsDbContext())
            {
                var prods = ctx.Products.Select(x => _mapper.Map<ProductDTO>(x));

                return prods;
            }

        }

        public IEnumerable<StoreDTO> GetStore()
        {
            throw new NotImplementedException();
        }
    }
}

