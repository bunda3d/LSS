namespace LSS.Shared.Entities
{
  public class StarRatingsPeople
  {
    public int StarRatingId { get; set; }
    public StarRating StarRating { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }

  }
}