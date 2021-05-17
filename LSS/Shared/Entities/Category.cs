using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LSS.Shared.Entities
{
  public class Category
  {
    public int Id { get; set; }

    //Suits or Pants
    [Required(ErrorMessage = "Required Field: Provide a Category Name, like 'Suits' or 'Pants'.")]
    public string Name { get; set; }

    //XXL or Petit
    public string SizeMeasure { get; set; }

    //Gender or Age Group
    public string SizeType { get; set; }

    //Predominate Color
    public string Color { get; set; }

    //Plaid, Solid, Hound's Tooth, Camo
    public string PatternStyle { get; set; }

    //French Cut, Vintage
    public string Style { get; set; }

    //1-5 stars
    public int? StarRating { get; set; }

    public List<ProductsCategories> ProductsCategories { get; set; } = new List<ProductsCategories>();
  }
}
