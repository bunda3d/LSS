using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.Entities
{
  public class Person
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "This field cannot be blank")]
    public string NameFirst { get; set; }

    [Required(ErrorMessage = "This field cannot be blank")]
    public string NameLast { get; set; }

    public string NameMI { get; set; }

    public string Photo { get; set; }

    [Required]
    public DateTime? DateOfBirth { get; set; }

    public string Biography { get; set; }

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
