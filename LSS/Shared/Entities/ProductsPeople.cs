namespace LSS.Shared.Entities
{
  public class ProductsPeople
  {
    public int ProductId { get; set; }
    public Product Product { get; set; }


    public int PersonId { get; set; }
    public Person Person { get; set; }

  }
}