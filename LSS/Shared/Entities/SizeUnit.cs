namespace LSS.Shared.Entities
{
  public class SizeUnit
  {
    public int Id { get; set; }

    //XXL or Petit
    public string SizeMeasure { get; set; }
    public string SizeMeasureId { get; set; }

    //Gender or Age Group
    public string SizeType { get; set; }
    public string SizeTypeId { get; set; }
  }
}
