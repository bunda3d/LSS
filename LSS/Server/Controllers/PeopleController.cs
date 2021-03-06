using AutoMapper;
using LSS.Server.Helpers;
using LSS.Shared.DTOs;
using LSS.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class PeopleController : ControllerBase
  {
    private readonly ApplicationDbContext context;
    private readonly IFileStorageService fileStorageService;
    private readonly string containerName = "people";
    private readonly string fileExtension = ".jpg";
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
    public async Task<ActionResult<List<Person>>> Get(
      [FromQuery] PaginationDTO paginationDTO)
    {
      var queryable = context.People.AsQueryable();
      await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
      return await queryable.Paginate(paginationDTO).ToListAsync();
    }

    [HttpGet("update/{id}")]
    public async Task<ActionResult<Person>> PutGet(int id)
    {
      var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
      if (person == null) { return NotFound(); }
      return person;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<DetailsPersonDTO>> Get(int id)
    {
      var person = await context.People.Where(x => x.Id == id)
        .Include(x => x.ProductsPeople).ThenInclude(x => x.Product)
        .FirstOrDefaultAsync();

      var name = person.FullName;

      if (person == null) { return NotFound(); }

      person.ProductsPeople = person.ProductsPeople.OrderBy(x => x.Order).ToList();

      var model = new DetailsPersonDTO();
      model.Person = person;

      model.People = person.ProductsPeople.Select(x =>
        new Person
        {
          NameFirst = x.Person.NameFirst,
          NameLast = x.Person.NameLast,
          Photo = x.Person.Photo,
          Role = x.Role,
          Id = x.PersonId
        }).ToList();

      return model;
    }

    //filtering multiple names, like 1st and last: https://bit.ly/3vgSCUj

    [HttpGet("search/{searchText}")]
    public async Task<ActionResult<List<Person>>> FilterByName(string searchText)
    {
      if (string.IsNullOrWhiteSpace(searchText)) { return new List<Person>(); }
      return await context.People.Where(x => x.NameFirst.Contains(searchText)
        || x.NameLast.Contains(searchText)).Take(5).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post(Person person)
    {
      if (!string.IsNullOrWhiteSpace(person.Photo))
      {
        var personPicture = Convert.FromBase64String(person.Photo);
        person.Photo = await fileStorageService
          .SaveFile(personPicture, fileExtension, containerName);
      }

      context.Add(person);
      await context.SaveChangesAsync();
      return person.Id;
    }

    [HttpPut]
    public async Task<ActionResult> Put(Person person)
    {
      //personDB = same person, but from database
      var personDB = await context.People.FirstOrDefaultAsync(x => x.Id == person.Id);

      if (personDB == null) { return NotFound(); }

      personDB = mapper.Map(person, personDB);

      //so as not to replace image every edit--only when it's changed
      if (!string.IsNullOrWhiteSpace(person.Photo))
      {
        var personPicture = Convert.FromBase64String(person.Photo);
        personDB.Photo = await fileStorageService.EditFile(personPicture,
          fileExtension, containerName, personDB.Photo);
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