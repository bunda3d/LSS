using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class SizeType
  {
    public int Id { get; set; }

    //Gender or Age Group
    [Required(ErrorMessage ="Required: Size Type is like a Gender or Age Group; i.e. 'Womens' or 'Infant'.")]
    [Column(TypeName = "varchar(30)")]
    public string SizeTypeName { get; set; }

    //[abbr.] W or I
    [Required(ErrorMessage = "Required: An abbreviation of the Size Type, like 'W' for Womens or 'I' for Infant.")]
    [Column(TypeName = "varchar(15)")]
    public string SizeTypeCode { get; set; }
  }
}
