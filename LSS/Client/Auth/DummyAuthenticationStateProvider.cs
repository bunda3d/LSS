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
        new Claim(ClaimTypes.Name, "Kris"),
        new Claim(ClaimTypes.Role, "Admin")
      });
      return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
  }
}