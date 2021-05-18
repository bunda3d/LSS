namespace LSS.Shared.Entities
{
  public class PatternStyle
  {
    public int Id { get; set; }

    //Plaid, Solid, Hound's Tooth, Camo
    public string PatternStyleName { get; set; }
    public string SizeMeasureId { get; set; }
    public bool WasUsedInProductionFlag { get; set; }

    //if pattern used in prod, which ProductID?
    public string PatternUsedInProductId { get; set; }

    //if pattern used in prod, ID of Purch Order
    public string PatternUsedInPoId { get; set; }


  }
}
