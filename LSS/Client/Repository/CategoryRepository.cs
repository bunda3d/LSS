using LSS.Client.Helpers;
using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{

  public class CategoryRepository : ICategoryRepository
  {  
    
    private readonly IHttpService httpService;
    //controller's endpoint
    private string url = "api/categories";

    public CategoryRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<List<Category>> GetCategories()
    {
      var response = await httpService.Get<List<Category>>(url);
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
      return response.Response;
    }

    public async Task CreateCategory(Category category)
    {
      var response = await httpService.Post(url, category);
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
    }

    Task<Category> ICategoryRepository.GetCategories(int id)
    {
      throw new NotImplementedException();
    }

    Task ICategoryRepository.UpdateCategory(Category category)
    {
      throw new NotImplementedException();
    }

    Task ICategoryRepository.DeleteCategory(int Id)
    {
      throw new NotImplementedException();
    }
  }
}
