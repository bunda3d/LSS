using LSS.Shared.Entities;
using System.Collections.Generic;

namespace LSS.Shared.DTOs
{
  public class ProductUpdateDTO
  {
    public Product Product { get; set; }
    public List<Person> People { get; set; }
    public List<Category> SelectedCategories { get; set; }
    public List<Category> NotSelectedCategories { get; set; }
  }
}
