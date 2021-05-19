using LSS.Client.Helpers;
using LSS.Shared.Entities;
using System;
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

    public async Task CreatePerson(Person person)
    {
      var response = await httpService.Post(url, person);
      if (!response.Success)
      {
        throw new ApplicationException(await response.GetBody());
      }
    }

    Task IPersonRepository.DeletePerson(int Id)
    {
      throw new NotImplementedException();
    }

    Task<Person> IPersonRepository.GetPersonById(int id)
    {
      throw new NotImplementedException();
    }

    Task IPersonRepository.UpdatePerson(Person person)
    {
      throw new NotImplementedException();
    }
  }
}
