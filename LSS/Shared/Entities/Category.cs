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

    //how ef core sets up M:M relationships in the model
    //https://bit.ly/3bwZXau
    public ICollection<Product> Products { get; set; }
    public List<ProductsCategories> ProductsCategories { get; set; }


  }
}

