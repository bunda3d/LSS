using LSS.Client.Helpers;
using LSS.Shared.DTOs;
using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{

  public class ProductRepository : IProductRepository
  {  
    
    private readonly IHttpService httpService;
    //controller's endpoint
    private string url = "api/products";

    public ProductRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    //Using Data Transfer Objectss (DTOs)

    public async Task<IndexPageDTO> GetIndexPageDTO()
    {
      return await httpService.GetHelper<IndexPageDTO>(url);
    }

    public async Task<ProductUpdateDTO> GetProudctForUpdate(int id)
    {
      return await httpService.GetHelper<ProductUpdateDTO>($"{url}/update/{id}");
    }

    public async Task<DetailsProductDTO> GetDetailsProductDTO(int id)
    {
      return await httpService.GetHelper<DetailsProductDTO>($"{url}/{id}");
    }

    public async Task<PaginatedResponse<List<Product>>> GetFilteredProducts(ProductFilterDTO productFilterDTO)
    {
      //.Post<datatype sending to server, datatype receiving>
      var responseHTTP = await httpService
        .Post<ProductFilterDTO, List<Product>>($"{url}/filter", productFilterDTO);
      var totalAmountPages = int
        .Parse(responseHTTP.HttpResponseMessage.Headers
        .GetValues("totalAmountPages")
        .FirstOrDefault());
      var paginatedResponse = new PaginatedResponse<List<Product>>()
      {
        Response = responseHTTP.Response,
        TotalAmountPages = totalAmountPages
      };

      return paginatedResponse;
    }



    //CRUD

    public async Task<int> CreateProduct(Product product)
    {
      var response = await httpService.Post<Product, int>(url, product);
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
      //integer (<int>) (PK) that came back from api after saving Product
      return response.Response;
    }

    public async Task UpdateProduct(Product product)
    {
      var response = await httpService.Put(url, product);
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
    }


    public async Task DeleteProduct(int Id)
    {
      var response = await httpService.Delete($"{url}/{Id}");
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
    }
  }
}
