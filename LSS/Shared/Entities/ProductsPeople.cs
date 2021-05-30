using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class ProductsPeople
  {
    public int ProductId { get; set; }
    public Product Product { get; set; }


    public int PersonId { get; set; }
    public Person Person { get; set; }

    //person, emp, customer, or vendor who adds value, sells, buys, or
    //otherwise can be associated with this product.
    [Column(TypeName = "varchar(120)")]
    [Required(ErrorMessage = "Required: Role is any person, emp, customer, or vendor " +
      "who adds value, sells, buys, or otherwise can be associated with this product.")]
    public string Role { get; set; }
    //TODO^^^need roles list obj for feeding a select list 

    //sequential Order that Roles do work/add value to Products
    public int Order { get; set; }

    [Column(TypeName = "varchar(50)")]
    [Required(ErrorMessage = "Required: What job or process the Role " +
      "performs on the Product")]
    public string ValueAddJob { get; set; }
    //TODO^^^need to add job list table for feeding a select list 

  }
}