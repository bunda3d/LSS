﻿namespace LSS.Shared.Entities
{
  public class ProductsCategories
  {
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public Product Product { get; set; }
    public Category Category { get; set; }


  }
}
