using LSS.Server.Helpers;
using LSS.Shared.Entities;
using LSS.Server.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LSS.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PeopleController : ControllerBase
  {
    private readonly ApplicationDbContext context;
    private readonly IFileStorageService fileStorageService;

    public PeopleController(ApplicationDbContext context, IFileStorageService fileStorageService)
    {
      this.context = context;
      this.fileStorageService = fileStorageService;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post(Person person)
    {
      if (!string.IsNullOrWhiteSpace(person.Photo))
      {
        var personPicture = Convert.FromBase64String(person.Photo);
        person.Photo = await fileStorageService.SaveFile(personPicture, ".jpg", "img/people");
      }


      context.Add(person);
      await context.SaveChangesAsync();
      
      return person.Id;
      
    }

  }
}
