using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class StarRating
  {
    public int Id { get; set; }


    //one customer's scoring of this product
    //[1-5] are values, null is default (unrated)
    [Column(TypeName = "int")]
    public int StarRatingScoreEvent { get; set; }

    //if >1 starRatingScores, record average score
    [Column(TypeName = "decimal(1, 1)")]
    public decimal StarRatingScoreAvg { get; set; }

    //Person clicking the star score

    [ForeignKey("Person")]
    [Column(TypeName = "int")]
    public int PersonId { get; set; }

    //1-5 stars for each ecommerce-listed product ID
    [ForeignKey("Product")]
    [Column(TypeName = "int")]
    public int ProductId { get; set; }


    //M:M relation
    public List<StarRatingsProducts> StarRatingsProducts { get; set; } = new List<StarRatingsProducts>();

    public List<StarRatingsPeople> StarRatingsPeople { get; set; } = new List<StarRatingsPeople>();


  }
}
