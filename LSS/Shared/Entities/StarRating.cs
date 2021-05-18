namespace LSS.Shared.Entities
{
  public class StarRating
  {
    public int Id { get; set; }

    //1-5 stars for each ecommerce-listed product ID
    public string ProductId { get; set; }

    //one customer's scoring of this product
    public int StarRatingScoreEvent { get; set; }

    //if >1 starRatingScores, record average score
    public decimal StarRatingScoreAvg { get; set; }



  }
}
