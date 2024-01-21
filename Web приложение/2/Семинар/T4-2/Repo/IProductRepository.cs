using T4_1.Model.DTO;

namespace T4_1.Repo
{
    public interface IProductRepository
    {
        public void AddCategory(CategoryDTO group);

        public IEnumerable<CategoryDTO> GetGroups();

        public void AddProduct(ProductDTO product);

        public IEnumerable<ProductDTO> GetProducts();

        public void AddStore(StoreDTO product);

        public IEnumerable<StoreDTO> GetStore();
    }
}