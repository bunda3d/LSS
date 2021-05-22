using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class Style
  {
    public int Id { get; set; }

    //French Cuff, Vintage, Casual, Polo, Summer 
    [Required(ErrorMessage = "Required: Style Names are like 'French Cuff,' " +
      "'Vintage,' 'Casual,' 'Polo,' 'Summer'.")]
    [Column(TypeName = "varchar(50)")]
    public string StyleName { get; set; }

    //Elaborate on style name
    [Column(TypeName = "varchar(50)")]
    public string StyleDescription { get; set; }

    //Select a style reminiscent of this one
    //(for a "you may also like" feature)
    public string StyleSimilarTo { get; set; }

    //Name some comma-speparated words or phrases of fashions,
    //eras, celebrities, cultures or anything this style.
    //i.e. 'Mid-Century Modern', 'Lil Wayne', 'Summer', 'Beach House'.
    [Column(TypeName = "varchar(120)")]
    public string StyleAssociatedWith { get; set; }

    public bool StyleIsTrendingFlag { get; set; }

    //Explain what has caused this to trend
    [Column(TypeName = "varchar(240)")]
    public string StyleIsTrendingReason { get; set; }


  }
}
