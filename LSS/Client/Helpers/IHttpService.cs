﻿using System;
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
    Task<HttpResponseWrapper<T>> Get<T>(string url);
    Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
    Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
    Task<HttpResponseWrapper<object>> Put<T>(string url, T data);
    Task<HttpResponseWrapper<object>> Delete(string url);
  }
}
