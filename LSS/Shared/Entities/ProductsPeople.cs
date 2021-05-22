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
    [Required(ErrorMessage = "Required: Role is any person, emp, customer, " +
      "or vendor who adds value, sells, buys, or otherwise can be associated with this product.")]
    [Column(TypeName = "varchar(50)")]
    public string Role { get; set; }
    //^^^need roles list obj for feeding a select list 

    //does the person in role attached to product add value to it
    //by performing a work process or applying a component to it? 
    [Required(ErrorMessage = "Required: does the person in the role attached " +
      "to product add value to it by performing a work process or applying a component to it? " +
      "if 'YES', what job or process was performed?")]
    [Column(TypeName = "varchar(50)")]
    public int ProductValueAddJob { get; set; }
    //^^^need to add job list table for feeding a select list 

  }
}