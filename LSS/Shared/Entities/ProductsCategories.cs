using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.Entities
{
  public class ProductsCategories
  {
    public int ProductId { get; set; }
    public int CategoriesId { get; set; }
    public Product Product { get; set; }
    public Category Category { get; set; }


  }
}
