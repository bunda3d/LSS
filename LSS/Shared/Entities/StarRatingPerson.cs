namespace LSS.Shared.Entities
{
  public class StarRatingPerson
  {
    public int StarRatingId { get; set; }
    public StarRating StarRating { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }

  }
}