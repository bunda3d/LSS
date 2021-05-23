using LSS.Shared.Entities;
using LSS.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CategoriesController : ControllerBase
  {
    private readonly ApplicationDbContext context;
    public CategoriesController(ApplicationDbContext context)
    {
      this.context = context;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post(Category category)
    {
      context.Add(category);
      await context.SaveChangesAsync();
      
      return Ok();
      
    }

  }
}
