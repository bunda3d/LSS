using LSS.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AccountsController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;

    //user manager creates user
    //sign in manager signs in user
    //configuration retrieves jwt key

    public AccountsController(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      IConfiguration configuration)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _configuration = configuration;
    }

    //endpoints for creating & signing in users

    [HttpPost("Create")]
    public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
    {
      var user = new IdentityUser { UserName = model.Email, Email = model.Email };
      var result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return BuildToken(model);
      }
      else
      {
        return BadRequest("Username or password invalid");
      }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
    {
      var result = await _signInManager.PasswordSignInAsync(userInfo.Email,
        userInfo.Password, isPersistent: false, lockoutOnFailure: false);

      if (result.Succeeded)
      {
        return BuildToken(userInfo);
      }
      else
      {
        return BadRequest("Invalid login attempt");
      }
    }

    private UserToken BuildToken(UserInfo userinfo)
    {
      var claims = new List<Claim>()
      {
        new Claim(ClaimTypes.Name, userinfo.Email),
        new Claim(ClaimTypes.Email, userinfo.Email),
        new Claim("myvalue", "whatever I want")
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var expiration = DateTime.UtcNow.AddYears(1);

      JwtSecurityToken token = new JwtSecurityToken(
        issuer: null,
        audience: null,
        claims: claims,
        expires: expiration,
        signingCredentials: creds
      );

      return new UserToken()
      {
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Expiration = expiration
      };
    }
  }
}