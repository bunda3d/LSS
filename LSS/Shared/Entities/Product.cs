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

		[Required(ErrorMessage = "Required Field: Enter a unique 6-digit number with no letters")]
		//Need to add controllers to get RegExs working in WASM Blazor
		//https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0#business-logic-validation
		//[RegularExpression(@"^[0 - 9]{6}$", ErrorMessage = "Enter a unique 6-digit number with no letters")]
		public int ProductNumber { get; set; }

		[Required(ErrorMessage = "Required Field: Provide a descriptive title sentence.")]
		public string Title { get; set; }

		public string Summary {get; set;}

    public decimal Price { get; set; }

		public bool IsMarkedDownFlag { get; set; }

		public bool OnClearanceFlag { get; set; }

		//Need to add controllers to get RegExs working in WASM Blazor
		//https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0#business-logic-validation
		//[RegularExpression(@"^[0 - 9]{0,3}$", ErrorMessage = "Estimated timeframe (in days) for Product Order to Factory Shipment")]
		public int? DaysToManufacture { get; set; }

		[Required]
		public DateTime? SellStartDate { get; set; }

		[Required]
		public DateTime? DiscontinuedDate { get; set; }

		public string Poster { get; set; }

		public string Video { get; set; }

		public int? CategoryId { get; set; }

		public int? ColorId { get; set; }

		public int? PatternId { get; set; }

		public int? StyleId { get; set; }

		public int? StarRatingId { get; set; }

		public int? SizeMeasureId { get; set; }

		public int? SizeTypeId { get; set; }

		//how ef core sets up M:M relationships in the model
		//https://bit.ly/3bwZXau
		public ICollection<Category> Categories { get; set; }

		//M:M relation
		public ICollection<StarRating> StarRatings { get; set; }

		public List<ProductsCategories> ProductsCategories { get; set; } = new List<ProductsCategories>();


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
