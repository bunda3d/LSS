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
		public int Id { get; set; } = 1;

		[Required]
		public string Title { get; set; }

		public DateTime ReleaseDate { get; set; }

		public string Poster { get; set; }

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
