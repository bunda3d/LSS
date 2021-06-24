﻿using LSS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Repository
{
  public interface IAccountsRepository
  {
    Task<UserToken> Login(UserInfo userInfo);
    Task<UserToken> Register(UserInfo userInfo);
  }
}
