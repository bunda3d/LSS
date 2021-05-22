using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class SizeMeasure
  {
    public int Id { get; set; }

    //Extra-Large or Petit
    [Required(ErrorMessage = "Required: Size Measure is like 'Extra-Large' or 'Petit'.")]
    [Column(TypeName = "varchar(30)")]
    public string SizeMeasureName { get; set; }


    //[abbr.] XL or P
    [Required(ErrorMessage = "Required: An abbreviation of the Size Measure, like 'XL' for Extra-Large or 'P' for Petit.")]
    [Column(TypeName = "varchar(15)")]
    public string SizeMeasureCode { get; set; }

  }
}
