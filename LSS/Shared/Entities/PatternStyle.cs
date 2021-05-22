using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class PatternStyle
  {
    public int Id { get; set; }

    //Plaid, Solid, Hound's Tooth, Camo
    [Required(ErrorMessage = "Required: Pattern Style is like 'Plaid', 'Solid', 'Hounds Tooth', 'Camo'.")]
    [Column(TypeName = "varchar(30)")]
    public string PatternStyleName { get; set; }

    //if pattern ever used in prod, or just in mockups/etc.
    public bool WasUsedInProductionFlag { get; set; }


    //if pattern used in prod, which ProductID?
    public int PatternUsedInProductId { get; set; }

    //if pattern used in prod, ID of Purch Order
    public int PatternUsedInPoId { get; set; }


  }
}
