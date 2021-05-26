using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Shared.Entities
{
	public class Product
	{
    public int Order;

    public int Id { get; set; }

		[Required(ErrorMessage = "Required Field: Enter a unique 6-digit number with no letters")]
		public int ProductNumber { get; set; }

		[MaxLength(120, ErrorMessage ="Cannot exceed 120 characters.")]
		[Required(ErrorMessage = "Required Field: Provide a descriptive title sentence.")]
		[Column(TypeName = "varchar(120)")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Required Field: Provide a descriptive summary to explain and market the product.")]
		[StringLength(1024, ErrorMessage = "Max Length is 1024 characters.")]
		[Column(TypeName = "varchar(1024)")]
		public string Summary {get; set;}

    [DataType(DataType.Currency)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
		[Column(TypeName = "decimal(8,2)")]
		public decimal Price { get; set; }

		public bool IsMarkedDownFlag { get; set; }

		public bool OnClearanceFlag { get; set; }

		public int DaysToManufacture { get; set; }


		//[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? SellStartDate { get; set; }

		public DateTime? DiscontinuedDate { get; set; }


		[Column(TypeName = "varchar(MAX)")]
		public string Poster { get; set; }

		[Column(TypeName ="varchar(MAX)")]
		public string Video { get; set; }


		//FK Relations
		public int? ColorId { get; set; }

		[ForeignKey("ColorId")]
		public Color Color { get; set; }

		
		public int? PatternStyleId { get; set; }

		[ForeignKey("PatternStyleId")]
		public PatternStyle PatternStyle { get; set; }


		public int? StyleId { get; set; }

		[ForeignKey("StyleId")]
		public Style Style { get; set; }



		public int? SizeMeasureId { get; set; }

		[ForeignKey("SizeMeasureId")]
		public SizeMeasure SizeMeasure { get; set; }


		
		public int? SizeTypeId { get; set; }

		[ForeignKey("SizeTypeId")]
		public SizeType SizeType { get; set; }


		//how ef core sets up M:M relationships in the model
		//https://bit.ly/3bwZXau and in the link, see the
		//"Join Entity Type Configuration" section for why this: 

		//M:M relations
		public List<ProductsCategories> ProductsCategories { get; set; } = new List<ProductsCategories>();

		public List<StarRatingsProducts> StarRatingsProducts { get; set; } = new List<StarRatingsProducts>();

		public List<ProductsPeople> ProductsPeople { get; set; } = new List<ProductsPeople>();



		[Column(TypeName = "varchar(65)")]
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
