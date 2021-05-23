using LSS.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface ICategoryRepository
  {
    Task CreateCategory(Category category);
    Task<List<Category>> GetCategories();
  }
}
