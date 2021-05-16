﻿using LSS.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LSS.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
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
		private readonly ILogger<AboutController> _logger;

		public AboutController(ILogger<AboutController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<About> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 8).Select(index => new About
			{
				Date = DateTime.Now.AddDays(index),

				EmpName = EmpNames[rng.Next(EmpNames.Length)],
				EmpTitle = Titles[rng.Next(Titles.Length)],
				EmpYrsOfService = rng.Next(3, 25)

			})
			.ToArray();
		}
	}
}