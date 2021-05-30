using AutoMapper;
using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Server.Helpers
{
  public class AutomapperProfiles: Profile
  {
    public AutomapperProfiles()
    {
      CreateMap<Person, Person>()
        .ForMember(x => x.Photo, option => option.Ignore());

    }
  }
}
