using LSS.Shared.DTOs;
using LSS.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IPersonRepository
  {
    Task CreatePerson(Person person);

    Task<Person> GetPersonById(int id);

    Task<List<Person>> GetPeopleByName(string name);

    Task<PaginatedResponse<List<Person>>> GetPeople(PaginationDTO paginationDTO);

    Task UpdatePerson(Person person);

    Task DeletePerson(int Id);

  }
}
