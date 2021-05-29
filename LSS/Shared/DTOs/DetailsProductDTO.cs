using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.DTOs
{
  public class DetailsProductDTO
  {
    public Product Product { get; set; }
    public List<Category> Categories { get; set; }
    public List<Person> People { get; set; }

  }
}
