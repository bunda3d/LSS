using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class Category
  {
    public int Id { get; set; }

    //Suits, Pants, Shoes (usually: category = Garment Type)
    [Required(ErrorMessage = "Required Field: Provide Category Name, i.e.; 'Suits' or 'Pants'")]
    [Column(TypeName = "varchar(30)")]
    public string Name { get; set; }


    //M:M in ef core: https://bit.ly/3bwZXau
    public ICollection<ProductsCategories> ProductsCategories { get; } = new List<ProductsCategories>();

  }
}

