using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LSS.Client.Helpers
{
  public interface IHttpService
  {
    Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
  }
}
