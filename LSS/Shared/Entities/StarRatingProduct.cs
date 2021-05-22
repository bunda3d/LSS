namespace LSS.Shared.Entities
{
  public class StarRatingProduct
  {
    public int StarRatingId { get; set; }
    public StarRating StarRating { get; set; }


    public int ProductId { get; set; }
    public Product Product { get; set; }

  }
}