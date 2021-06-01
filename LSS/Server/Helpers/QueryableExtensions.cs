using LSS.Shared.DTOs;
using System.Linq;

namespace LSS.Server.Helpers
{
  public static class QueryableExtensions
  {
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, 
      PaginationDTO paginationDTO)
    {
      return queryable
        .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage)
        .Take(paginationDTO.RecordsPerPage);
    }
  }
}
