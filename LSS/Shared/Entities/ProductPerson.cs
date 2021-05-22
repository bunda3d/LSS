namespace LSS.Shared.Entities
{
  public class ProductPerson
  {
    public int ProductId { get; set; }
    public Product Product { get; set; }


    public int PersonId { get; set; }
    public Person Person { get; set; }

    public string Role { get; set; }
    public int ProductValueAddJob { get; set; }

  }
}