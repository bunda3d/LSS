using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.Entities
{
  public class Color
  {
    public int Id { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string ColorName { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string ColorHexCode { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string ColorHsvCode { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string ColorPantoneCode { get; set; }

    [Column(TypeName = "varchar(30)")]
    public string ColorDyeName { get; set; }

    public bool WasUsedInProductionFlag { get; set; }

    [ForeignKey("ProductNumber")]
    public int ColorUsedInProductId { get; set; }

  }
}
