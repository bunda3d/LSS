using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Server.Helpers
{
  public interface IFileStorageService
  {

    //connect imgs to their subjects (people, products) so if they are deleted
    //images are also deleted, for housecleaning reasons.
    Task<string> SaveFile(byte[] content, string extension, string containerName);

    Task DeleteFile(string fileRoute, string containerName);

    //also, if Person or Product image is updated, want to delete previous file
    Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute);
   
  }
}
