using MicroserviceApplication.Models;

namespace MicroserviceApplication.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int ProductId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int ProductId);
        void Save();
    }
}
