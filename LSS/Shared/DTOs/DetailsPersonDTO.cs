using LSS.Shared.Entities;
using System;
using System.Collections.Generic;

namespace LSS.Shared.DTOs
{
  public class DetailsPersonDTO
  {
    public Person Person { get; set; }
    public List<Person> People { get; set; }
    public List<Category> Categories { get; set; }
    public List<Product> Products { get; set; }

  }
}
