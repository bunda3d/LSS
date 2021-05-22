using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class Person
  {
    public int Id { get; set; }


    [Required(ErrorMessage = "Required Field")]
    public string NameFirst { get; set; }


    [Required(ErrorMessage = "Required Field")]
    public string NameLast { get; set; }

    public string NameMI { get; set; }

    public string FullName => string.Format("{0} {1}", NameFirst, NameLast);

    public string Photo { get; set; }

    [Required]
    public DateTime? DateOfBirth { get; set; }

    public TimeSpan? GetAge() => DateTime.Now - DateOfBirth;

    public string Biography { get; set; }
    
    [NotMapped]
    public string Role { get; set; }


    //M:M relation
    public ICollection<StarRatingPerson> StarRatingsPeople { get; } = new List<StarRatingPerson>();

    //M:M relation -> for person's role with product;
    //taylor, salesperson, purchaser, 
    public ICollection<ProductPerson> ProductsPeople { get; } = new List<ProductPerson>();



    //2 persons are equal if only they share the same id.
    public override bool Equals(object obj)
    {
      if (obj is Person p2)
      {
        return Id == p2.Id;
      }
      return false;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }


  }
}
