using LSS.Server.Helpers;
using LSS.Shared.Entities;
using LSS.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace LSS.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PeopleController : ControllerBase
  {
    private readonly ApplicationDbContext context;
    private readonly IFileStorageService fileStorageService;
    private string containerName = "img/people";
    private readonly IMapper mapper;

    public PeopleController(ApplicationDbContext context, 
      IFileStorageService fileStorageService,
      IMapper mapper)
    {
      this.context = context;
      this.fileStorageService = fileStorageService;
      this.mapper = mapper;
    }



    [HttpGet]
    public async Task<ActionResult<List<Person>>> Get()
    {
      return await context.People.ToListAsync();
    }


    //filtering multiple names, like 1st and last: https://bit.ly/3vgSCUj

    [HttpGet("search/{searchText}")]
    public async Task<ActionResult<List<Person>>> FilterByName(string searchText)
    {
      if (string.IsNullOrWhiteSpace(searchText)) { return new List<Person>(); }
      return await context.People.Where(x => x.NameLast.Contains(searchText) && 
        x.NameFirst.Contains(searchText))
        .Take(5).ToListAsync();
    } 


    [HttpPost]
    public async Task<ActionResult<int>> Post(Person person)
    {
      if (!string.IsNullOrWhiteSpace(person.Photo))
      {
        var personPicture = Convert.FromBase64String(person.Photo);
        person.Photo = await fileStorageService.SaveFile(personPicture, ".jpg", containerName);
      }

      context.Add(person);
      await context.SaveChangesAsync();
      return person.Id;
    }


    [HttpPut]
    public async Task<ActionResult> Put(Person person)
    {
      var personDB = await context.People.FirstOrDefaultAsync(x => x.Id == person.Id);

      if (personDB == null) { return NotFound(); }

      personDB = mapper.Map(person, personDB);

      if (!string.IsNullOrWhiteSpace(person.Photo))
      {
        var personPicture = Convert.FromBase64String(person.Photo);
        personDB.Photo = await fileStorageService.EditFile(personPicture,
            ".jpg", containerName, personDB.Photo);
      }

      await context.SaveChangesAsync();
      return NoContent();

    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
      if (person == null)
      {
        return NotFound();
      }

      context.Remove(person);
      await context.SaveChangesAsync();
      return NoContent();
    }

  }
}
