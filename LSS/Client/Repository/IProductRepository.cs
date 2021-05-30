using LSS.Shared.DTOs;
using LSS.Shared.Entities;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IProductRepository
  {
    Task<int> CreateProduct(Product product);

    //Task<DetailsProductDTO> GetDetailsProductDTO(int id);
    //Task<ProductUpdateDTO> GetProductForUpdate(int id);
    //Task<PaginatedResponse<List<Product>>> GetProductsFiltered(FilterProductsDTO filterProductsDTO);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int Id);
    Task<IndexPageDTO> GetIndexPageDTO();
    Task<DetailsProductDTO> GetDetailsProductDTO(int id);
    Task<ProductUpdateDTO> GetProudctForUpdate(int id);
  }
}
