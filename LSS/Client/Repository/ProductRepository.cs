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
      return response.Response;
    }

    Task IProductRepository.DeleteProduct(int Id)
    {
      throw new NotImplementedException();
    }

    Task<Product> IProductRepository.GetProductById(int id)
    {
      throw new NotImplementedException();
    }

    Task IProductRepository.UpdateProduct(Product product)
    {
      throw new NotImplementedException();
    }
  }
}
