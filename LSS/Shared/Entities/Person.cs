using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class Person
  {
    public int Id { get; set; }

    [StringLength (50, MinimumLength = 2, ErrorMessage = "Required: " +
      "Name must be between 2 and 50 characters long.")]
    [Required(ErrorMessage = "Required Field")]
    [Column(TypeName = "varchar(50)")]
    public string NameFirst { get; set; }


    [StringLength(50, MinimumLength = 2, ErrorMessage = "Required: " +
      "Name must be between 2 and 50 characters long.")]
    [Required(ErrorMessage = "Required Field")]
    [Column(TypeName = "varchar(50)")]
    public string NameLast { get; set; }


    [StringLength(3, MinimumLength = 0, ErrorMessage = "Required: " +
      "Middle Initial must be between 0 and 3 characters long.")]
    [Column(TypeName = "varchar(3)")]
    public string NameMI { get; set; }


    [Column(TypeName = "varchar(100)")]
    public string FullName => string.Format("{0} {1}", NameFirst, NameLast);


    public bool IsEmployeeFlag { get; set; }
    public Employee EmployeeId { get; set; }

    //for if a Person is an Customer https://bit.ly/3vdDRS5
    public bool IsCustomerFlag { get; set; }
    //public Customer CustomerId { get; set; }
    //^^^ haven't built this table yet

    //for if a Person is an Vendor https://bit.ly/3vdDRS5
    public bool IsVendorFlag { get; set; }
    //public Vendor VendorId { get; set; }
    //^^^ haven't built this table yet



    [Column(TypeName = "varchar(MAX)")]
    public string Photo { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{dddd, yyyy/MM/dd}")]
    public DateTime? DateOfBirth { get; set; }

    public TimeSpan? GetAge() => DateTime.Now - DateOfBirth;

    [Required(ErrorMessage = "Required Field: Provide a descriptive summary as a Biography (up to 1024 characters).")]
    [StringLength(1024, ErrorMessage = "Max Length is 1024 characters.")]
    [Column(TypeName = "varchar(1024)")]
    public string Biography { get; set; }
    
    [NotMapped]
    public int Role { get; set; }


    //M:M relation
    public List<StarRatingsPeople> StarRatingsPeople { get; set; } = new List<StarRatingsPeople>();

    //M:M relation -> for person's role with product;
    //taylor, salesperson, purchaser, 
    public List<ProductsPeople> ProductsPeople { get; set; } = new List<ProductsPeople>();


    //this is for the searchbox "typeahead"
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
