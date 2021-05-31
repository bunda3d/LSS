using AutoMapper;
using LSS.Shared.Entities;

namespace LSS.Server.Helpers
{
  public class AutomapperProfiles: Profile
  {
    public AutomapperProfiles()
    {
      //map for PeopleController
      CreateMap<Person, Person>()
        .ForMember(x => x.Photo, option => option.Ignore());

      //map for ProductController
      CreateMap<Product, Product>()
        .ForMember(x => x.Poster, option => option.Ignore());
    }
  }
}
