using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.Models;

namespace FullPetflix.ProductFiles
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int product_id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int product_id);
    }
}