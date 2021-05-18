namespace LSS.Shared.Entities
{
  public class Style
  {
    public int Id { get; set; }


    //French Cuff, Vintage, Casual, Polo, Summer 
    public string StyleName { get; set; }

    public string StyleDescription { get; set; }

    public string StyleSimilarTo { get; set; }

    public string StyleAssociatedWith { get; set; }

    public bool StyleIsTrendingFlag { get; set; }

    public string StyleIsTrendingReason { get; set; }


  }
}
