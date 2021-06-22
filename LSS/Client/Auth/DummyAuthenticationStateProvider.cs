using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LSS.Client.Auth
{
  public class DummyAuthenticationStateProvider : AuthenticationStateProvider
  {
    //override the base class
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      //await Task.Delay(3000);
      var anonymous = new ClaimsIdentity(new List<Claim>() {
        new Claim("key1", "value1"),
        new Claim(ClaimTypes.Name, "Kris"),
        new Claim(ClaimTypes.Role, "Admin")
      }, "test");  //adding Authentication Type name here allows access
      return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
  }
}