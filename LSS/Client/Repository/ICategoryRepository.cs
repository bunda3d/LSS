using LSS.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface ICategoryRepository
  {
    Task CreateCategory(Category category);
    Task<List<Category>> GetCategories();
    Task<Category> GetCategories(int id);
    Task UpdateCategory(Category category);
    Task DeleteCategory(int Id);

  }
}
