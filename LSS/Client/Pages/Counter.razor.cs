using LSS.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Pages
{
	public partial class Counter
	{

		[Inject] SingletonService singleton { get; set; }
		[Inject] TransientService transient { get; set; }

		private int currentCount = 0;

		private void IncrementCount()
		{
			currentCount++;
			singleton.Value += 1;
			transient.Value += 1;
		}


		private List<Movie> movies;

		protected override void OnInitialized()
		{
			movies = new List<Movie>()
		{
			new Movie(){Title = "Joker", ReleaseDate = new DateTime(2019, 10, 4) },
			new Movie(){Title = "Avengers", ReleaseDate = new DateTime(2012, 5, 12) }
		};
		}
	}
}
