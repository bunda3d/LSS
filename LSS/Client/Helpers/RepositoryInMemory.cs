using LSS.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSS.Client.Helpers
{
	public class RepositoryInMemory : IRepository
	{
		public List<Product> GetProducts()
		{
			return new List<Product>()
			{
				new Product(){
          Title = "Mens Grey Suit: 3-button ensemble",
					SellStartDate = new DateTime(2019, 7, 2),
					Price = 700,
					Poster = "/img/product/suit01.jpg"
				},
				new Product(){
					Title = "Extra Slim Light Gray Plaid Linen Blend Suit",
					SellStartDate = new DateTime(2016, 11, 23),
					Price = 500,
					Poster = "/img/product/suit03a.png"
				},
				new Product(){
					Title = "Grey Check Suit Jacket and Pant combo",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 600,
					Poster = "/img/product/suit02.jpg"
				},
				new Product(){
					Title = "Rust Chambray Solid Style Jacket and Pant",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 900,
					Poster = "/img/product/suit04a.png"
				},
				new Product(){
					Title = "Mens Grey Suit: 3-button ensemble",
					SellStartDate = new DateTime(2019, 7, 2),
					Price = 700,
					Poster = "/img/product/suit01.jpg"
				},
				new Product(){
					Title = "Extra Slim Light Gray Plaid Linen Blend Suit",
					SellStartDate = new DateTime(2016, 11, 23),
					Price = 500,
					Poster = "/img/product/suit03a.png"
				},
				new Product(){
					Title = "Grey Check Suit Jacket and Pant combo",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 600,
					Poster = "/img/product/suit02.jpg"
				},
				new Product(){
					Title = "Rust Chambray Solid Style Jacket and Pant",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 900,
					Poster = "/img/product/suit04a.png"
				},
				new Product(){
					Title = "Mens Grey Suit: 3-button ensemble",
					SellStartDate = new DateTime(2019, 7, 2),
					Price = 700,
					Poster = "/img/product/suit01.jpg"
				},
				new Product(){
					Title = "Extra Slim Light Gray Plaid Linen Blend Suit",
					SellStartDate = new DateTime(2016, 11, 23),
					Price = 500,
					Poster = "/img/product/suit03a.png"
				},
				new Product(){
					Title = "Grey Check Suit Jacket and Pant combo",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 600,
					Poster = "/img/product/suit02.jpg"
				},
				new Product(){
					Title = "Rust Chambray Solid Style Jacket and Pant",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 900,
					Poster = "/img/product/suit04a.png"
				},
				new Product(){
					Title = "Mens Grey Suit: 3-button ensemble",
					SellStartDate = new DateTime(2019, 7, 2),
					Price = 700,
					Poster = "/img/product/suit01.jpg"
				},
				new Product(){
					Title = "Extra Slim Light Gray Plaid Linen Blend Suit",
					SellStartDate = new DateTime(2016, 11, 23),
					Price = 500,
					Poster = "/img/product/suit03a.png"
				},
				new Product(){
					Title = "Grey Check Suit Jacket and Pant combo",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 600,
					Poster = "/img/product/suit02.jpg"
				},
				new Product(){
					Title = "Rust Chambray Solid Style Jacket and Pant",
					SellStartDate = new DateTime(2010, 7, 16),
					Price = 900,
					Poster = "/img/product/suit04a.png"
				}
			};
		}


		public List<OpenHrs> GetOpenHrs()
		{
			return new List<OpenHrs>()
			{
				new OpenHrs(){
					DayOfWk = "Sunday",
					OpenTime = "11am",
					ClosingTime = "5pm",
					OpenHrsMsg = "Compressed days on Weekends"
				},
				new OpenHrs(){
					DayOfWk = "Monday",
					OpenTime = "9am",
					ClosingTime = "9pm",
					OpenHrsMsg = ""
				},        
				new OpenHrs(){
					DayOfWk = "Tuesday",
					OpenTime = "9am",
					ClosingTime = "9pm",
					OpenHrsMsg = ""
				},
				new OpenHrs(){
					DayOfWk = "Wednesday",
					OpenTime = "9am",
					ClosingTime = "9pm",
					OpenHrsMsg = ""
				},
								new OpenHrs(){
					DayOfWk = "Thursday",
					OpenTime = "9am",
					ClosingTime = "9pm",
					OpenHrsMsg = ""
				},
				new OpenHrs(){
					DayOfWk = "Friday",
					OpenTime = "9am",
					ClosingTime = "7pm",
					OpenHrsMsg = "Close Early Fridays"
				},
				new OpenHrs(){
					DayOfWk = "Saturday",
					OpenTime = "11am",
					ClosingTime = "5pm",
					OpenHrsMsg = "Compressed days on Weekends"
				}
			};
		}
	}
}
