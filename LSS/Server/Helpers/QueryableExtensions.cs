using LSS.Shared.DTOs;
using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

    public static bool IsBetween(this DateTime listDate, DateTime startDate, DateTime endDate)
    {
      return listDate >= startDate && listDate <= endDate;
    }
  }
}
