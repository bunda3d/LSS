using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.Entities
{
	public class Product
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "This field cannot be blank")]
		[RegularExpression(@"^[0 - 9]{6}$", ErrorMessage = "This is a 6-digit number with no letters")]
		public int ProductId { get; set; }

		[Required(ErrorMessage = "This field cannot be blank")]
		public string Title { get; set; }

		public string Summary {get; set;}

		public bool IsMarkedDownFlag { get; set; }

		public bool OnClearanceFlag { get; set; }

		[RegularExpression(@"^[0 - 9]{0,3}$", ErrorMessage = "Estimated timeframe (in days) for Product Order to Factory Shipment")]
		public int? DaysToManufacture { get; set; }

		[Required]
		public DateTime? SellStartDate { get; set; }

		[Required]
		public DateTime? DiscontinuedDate { get; set; }

		public string Poster { get; set; }

		public string Video { get; set; }

		[DataType(DataType.Currency)]
		[DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0.c}")]
		public decimal Price { get; set; }


		public string TitleBrief
		{
			get
			{
				if (string.IsNullOrEmpty(Title))
				{
					return null;
				}

				if (Title.Length > 60)
				{
					return Title.Substring(0, 60) + "...";
				}
				else
				{
					return Title;
				}
			}
		}
	}
}
