using LSS.Client.Helpers;
using LSS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public class AccountsRepository: IAccountsRepository
  {
    private readonly IHttpService httpService;
    private readonly string baseURL = "api/accounts";
    public AccountsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<UserToken> Register(UserInfo userInfo)
    {
      //invokes Create method from accounts controller
      var httpResponse = await httpService
        .Post<UserInfo, UserToken>($"{baseURL}/create", userInfo);

      if (!httpResponse.Success)
      {
        throw new ApplicationException(await httpResponse.GetBody());
      }

      return httpResponse.Response;
    }

    public async Task<UserToken> Login(UserInfo userInfo)
    {
      //invokes Create method from accounts controller
      var httpResponse = await httpService
        .Post<UserInfo, UserToken>($"{baseURL}/login", userInfo);

      if (!httpResponse.Success)
      {
        throw new ApplicationException(await httpResponse.GetBody());
      }

      return httpResponse.Response;
    }
  }
}
