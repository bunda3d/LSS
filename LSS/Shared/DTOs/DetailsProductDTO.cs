using LSS.Shared.Entities;
using System;
using System.Collections.Generic;

namespace LSS.Shared.DTOs
{
  public class DetailsProductDTO
  {
    public Product Product { get; set; }
    public List<Category> Categories { get; set; }
    public List<Person> People { get; set; }

  }
}
