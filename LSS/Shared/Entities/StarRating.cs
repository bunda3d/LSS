using System.Collections.Generic;

namespace LSS.Shared.Entities
{
  public class StarRating
  {
    public int Id { get; set; }


    //one customer's scoring of this product
    //[1-5] are values, null is default (unrated)
    public int StarRatingScoreEvent { get; set; }

    //if >1 starRatingScores, record average score
    public decimal StarRatingScoreAvg { get; set; }

    //Person clicking the star score
    public string PersonId { get; set; }

    //1-5 stars for each ecommerce-listed product ID
    public string ProductId { get; set; }


    //M:M relation
    public ICollection<Product> Products { get; set; }

    //M:M relation
    public ICollection<Person> People { get; set; }


  }
}
