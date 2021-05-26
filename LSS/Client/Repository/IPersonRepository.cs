﻿using LSS.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IPersonRepository
  {
    Task CreatePerson(Person person);


    //Task<PaginatedResponse<List<Person>>> GetPeople(PaginationDTO paginationDTO);

    Task<Person> GetPersonById(int id);

    Task UpdatePerson(Person person);

    Task<List<Person>> GetPeople();

    Task<List<Person>> GetPeopleByName(string name);

    Task DeletePerson(int Id);

  }
}