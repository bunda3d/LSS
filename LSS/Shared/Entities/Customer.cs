using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
	public class Customer
	{
		public int Id { get; set; }

		[Column(TypeName = "varchar(100)")]
		public string Name { get; set; }

		//for if a Person is a Customer https://bit.ly/3vVnIkX
		public int? PersonId { get; set; }

		[ForeignKey("PersonId")]
		public Person Person { get; set; }


		[Column(TypeName = "varchar(100)")]
		public string ContactName { get; set; }

		[Column(TypeName = "varchar(100)")]
		public string ContactTitle { get; set; }


		[Phone(ErrorMessage = "That is not a valid phone number.")]
		[DataType(DataType.PhoneNumber)]
		[Column(TypeName = "varchar(20)")]
		public string Phone { get; set; }

    [EmailAddress(ErrorMessage = "That is not a valid email.")]
		[DataType(DataType.EmailAddress)]
		[Column(TypeName = "varchar(100)")]
		public string Email { get; set; }


		public DateTime? Anniversary { get; set; }

	}

}