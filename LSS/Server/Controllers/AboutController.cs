using LSS.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LSS.Server.Controllers
{
  [ApiController]
  [Route("api")]
  public class AboutController : ControllerBase
  {
    private static readonly string[] Titles = new[]
    {
        "Owner", "Sales Manager", "Sales Persons", "Sales Persons",  "Sales Persons",  "Bookkeeper", "Assembly Manager", "Workers","Workers", "Workers",  "Purchasing Manager"
    };

    private static readonly string[] EmpNames = new[]
    {
        "Larry", "John", "Renae", "Rachel", "Timothy", "Jennifer", "Dylan", "Jeremy", "Linda", "Mary", "Derrick"
    };

    private static readonly string[] DaysOfWeek = new[]
    {
      "Sunday", "Monday", "Tuesday", "Wednesday",  "Thursday",  "Friday", "Saturday"
    };

    private static readonly string[] OpenTimes = new[]
    {
        "11am", "9am","9am","9am","9am","9am","11am"
    };

    private static readonly string[] ClosingTimes = new[]
    {
        "5pm", "9pm","9pm","9pm","9pm","9pm","5pm"
    };

    private static readonly string[] OpenHrsMsgs = new[]
    {
        "Closed on some major Holidays", 
        "If it's a holiday, please ", 
        "call to inquire if we're open.", 
        "555-515-5115", 
        "Or ask ahead via email: ", 
        "Info4Larry@LSS.co", 
        ""
    };


    private readonly ILogger<AboutController> _logger;

    public AboutController(ILogger<AboutController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    [Route("[controller]")]
    public IEnumerable<About> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 8).Select(index => new About
      {
        EmpImg = "https://via.placeholder.com/50/000000/FFFFFF?text=LSS",
        EmpName = EmpNames[index],
        EmpTitle = Titles[index],
        EmpYrsOfService = rng.Next(3, 25)
      })
      .ToArray();
    }

    [HttpGet]
    [Route("OpenHrs")]
    public IEnumerable<OpenHrs> GetHrs()
    {
      return Enumerable.Range(0, 7).Select(index => new OpenHrs
      {
        DayOfWk = DaysOfWeek[index],
        OpenTime = OpenTimes[index],
        ClosingTime = ClosingTimes[index],
        OpenHrsMsg = OpenHrsMsgs[index]
      })
      .ToArray();
    }
  }
}