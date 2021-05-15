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
				new Suit(){
					Title = "Mens Grey Suit: 3-button ensemble",
					ReleaseDate = new DateTime(2019, 7, 2),
					Price = 700,
					Poster = "/img/product/suit01.jpg"
				},
				new Suit(){
					Title = "Extra Slim Light Gray Plaid Linen Blend Suit",
					ReleaseDate = new DateTime(2016, 11, 23),
					Price = 500,
					Poster = "/img/product/suit03a.png"
				},
				new Suit(){
					Title = "Grey Check Suit Jacket and Pant combo",
					ReleaseDate = new DateTime(2010, 7, 16),
					Price = 600,
					Poster = "/img/product/suit02.jpg"
				},
				new Suit(){
					Title = "Rust Chambray Solid Style Jacket and Pant",
					ReleaseDate = new DateTime(2010, 7, 16),
					Price = 400,
					Poster = "/img/product/suit04a.png"
				}
			};
		}
	}
}
