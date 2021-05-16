using System.ComponentModel.DataAnnotations;

namespace LSS.Shared.Entities
{
  public class Category
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "This field cannot be blank")]
    public string Name { get; set; }

  }
}
