using LSS.Shared.Entities;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IProductRepository
  {
    Task<int> CreateProduct(Product product);
    Task DeleteProduct(int Id);
    //Task<DetailsProductDTO> GetDetailsProductDTO(int id);
    //Task<IndexPageDTO> GetIndexPageDTO();
    //Task<ProductUpdateDTO> GetProductForUpdate(int id);
    //Task<PaginatedResponse<List<Product>>> GetProductsFiltered(FilterProductsDTO filterProductsDTO);
    Task UpdateProduct(Product product);
  }
}
