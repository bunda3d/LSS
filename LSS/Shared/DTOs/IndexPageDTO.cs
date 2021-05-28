using LSS.Shared.Entities;
using System.Collections.Generic;

namespace LSS.Shared.DTOs
{
  public class IndexPageDTO
  {
    public List<Product> Featured { get; set; }
    public List<Product> NewRelease { get; set; }
    public List<Product> Trending { get; set; }
    public List<Product> OnSale { get; set; }
    public List<Product> OnClearance { get; set; }

  }
}
