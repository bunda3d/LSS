using System.ComponentModel.DataAnnotations.Schema;

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

    //this would actually be a query to find where this
    //table's PK is listed in any Product table's ColorId
    //[ForeignKey("ProductNumber")]
    public int ColorUsedInProductId { get; set; }

  }
}
