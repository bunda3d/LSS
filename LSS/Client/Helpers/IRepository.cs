using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Helpers
{
	public interface IRepository
	{
		List<Movie> GetMovies();
	}
}
