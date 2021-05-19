using LSS.Shared.Entities;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IPersonRepository
  {
    Task CreatePerson(Person person);
    Task DeletePerson(int Id);
    //Task<PaginatedResponse<List<Person>>> GetPeople(PaginationDTO paginationDTO);
    //Task<List<Person>> GetPeopleByName(string name);
    Task<Person> GetPersonById(int id);
    Task UpdatePerson(Person person);
  }
}
