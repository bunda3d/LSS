namespace LSS.Shared.Entities
{
  public class StarRatingsProducts
  {
    public int StarRatingId { get; set; }
    public int ProductId { get; set; }
    public StarRating StarRating { get; set; }
    public Product Product { get; set; }

  }
}