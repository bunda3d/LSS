using LSS.Client.Helpers;
using LSS.Shared.Entities;
using System;
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
