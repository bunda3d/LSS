using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LSS.Shared.Entities
{
  public class Category
  {
    public int Id { get; set; }

    //Suits, Pants, Shoes (usually: category = Garment Type)
    [Required(ErrorMessage = "Required Field: Provide Category Name, i.e.; 'Suits' or 'Pants'")]
    public string Name { get; set; }

    //M:M in ef core: https://bit.ly/3bwZXau
    public ICollection<ProductCategory> ProductsCategories { get; } = new List<ProductCategory>();


  }
}

