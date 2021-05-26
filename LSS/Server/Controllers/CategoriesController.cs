using LSS.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    [HttpGet]
    public async Task<ActionResult<List<Category>>> Get()
    {
      return await context.Categories.ToListAsync();
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(int id)
    {
      var genre = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
      if (genre == null) { return NotFound(); }
      return genre;
    }



    [HttpPost]
    public async Task<ActionResult<int>> Post(Category category)
    {
      context.Add(category);
      await context.SaveChangesAsync();
      
      return Ok();
    }



    [HttpPut]
    public async Task<ActionResult> Put(Category category)
    {
      context.Attach(category).State = EntityState.Modified;
      await context.SaveChangesAsync();
      return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
      if (category == null)
      {
        return NotFound();
      }

      context.Remove(category);
      await context.SaveChangesAsync();
      return NoContent();
    }


  }
}
