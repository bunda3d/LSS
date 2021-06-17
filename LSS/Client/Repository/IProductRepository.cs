using LSS.Shared.DTOs;
using LSS.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IProductRepository
  {
    Task<int> CreateProduct(Product product);

    Task UpdateProduct(Product product);

    Task DeleteProduct(int Id);

    //using Data Transfer Objects
    Task<IndexPageDTO> GetIndexPageDTO();

    Task<DetailsProductDTO> GetDetailsProductDTO(int id);

    Task<ProductUpdateDTO> GetProudctForUpdate(int id);

    Task<PaginatedResponse<List<Product>>> GetFilteredProducts(ProductFilterDTO productFilterDTO);
  }
}