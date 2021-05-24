﻿using LSS.Client.Helpers;
using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{

  public class PersonRepository : IPersonRepository
  {  
    
    private readonly IHttpService httpService;
    //controller's endpoint
    private string url = "api/people";

    public PersonRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }



    //public async Task<PaginatedResponse<List<Person>>> GetPeople(PaginationDTO paginationDTO)
    //{
    //  return await httpService.GetHelper<List<Person>>(url, paginationDTO);
    //}



    //delete after uncommenting above
    Task<List<Person>> IPersonRepository.GetPeople()
    {
      throw new NotImplementedException();
    }






    public async Task<List<Person>> GetPeopleByName()
    {
      var response = await httpService.Get<List<Person>>($"{url}/search/{nameof(Person.NameLast)}");
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
      return response.Response;
    }


    //public async Task<Person> GetPersonById(int id)
    //{
    //  return await httpService.GetHelper<Person>($"{url}/{id}");
    //}


    public async Task CreatePerson(Person person)
    {
      var response = await httpService.Post(url, person);
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
    }


    //public async Task UpdatePerson(Person person)
    //{
    //  var response = await httpService.Put(url, person);
    //  if (!response.Success)
    //  {
    //    throw new ApplicationException(await response.GetBody());
    //  }
    //}


    //public async Task DeletePerson(int Id)
    //{
    //  var response = await httpService.Delete($"{url}/{Id}");
    //  if (!response.Success)
    //  {
    //    throw new ApplicationException(await response.GetBody());
    //  }
    //}


  }
}
