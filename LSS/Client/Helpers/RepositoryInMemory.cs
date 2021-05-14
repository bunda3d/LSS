using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Helpers
{
	public class RepositoryInMemory : IRepository
	{
		public List<Suit> GetSuits()
		{
			return new List<Suit>()
			{
				new Suit(){Title = "Spider-Man: Far From Home", ReleaseDate = new DateTime(2019, 7, 2) },
				new Suit(){Title = "Moana", ReleaseDate = new DateTime(2016, 11, 23) },
				new Suit(){Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16) }
			};
		}
	}
}
