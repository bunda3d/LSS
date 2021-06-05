using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.DTOs
{
  public class ProductFilterDTO
  {
    public int Page { get; set; } = 1;
    public int RecordsPerPage { get; set; } = 10;
    public PaginationDTO Pagination
    {
      get
      {
        return new PaginationDTO()
        {
          Page = Page,
          RecordsPerPage = RecordsPerPage
        };
      }
    }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public bool IsInStock { get; set; } = true;
    public bool IsTrending { get; set; }
    public bool IsOnSale { get; set; }
    public bool IsOnClearance { get; set; }

  }
}
