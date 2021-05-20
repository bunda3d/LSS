using LSS.Shared.Entities;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IProductRepository
  {
    Task CreateProduct(Product product);
    Task DeleteProduct(int Id);
    //Task<PaginatedResponse<List<Product>>> GetProducts(PaginationDTO paginationDTO);
    //Task<List<Product>> GetProductsByName(string name);
    Task<Product> GetProductById(int id);
    Task UpdateProduct(Product product);
  }
}
