using LSS.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface ICategoryRepository
  {
    Task CreateCategory(Category category);

    Task<Category> GetCategory(int id);

    Task<List<Category>> GetCategories();

    Task UpdateCategory(Category category);

    Task DeleteCategory(int Id);

  }
}
