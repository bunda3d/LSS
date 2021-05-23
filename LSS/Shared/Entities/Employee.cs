using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
	public class Employee
	{
		public int Id { get; set; }


		//for if a Person is an Employee https://bit.ly/3vdDRS5
		public int PersonId { get; set; }

		[ForeignKey("PersonId")]
		public Person Person { get; set; }


		[Column(TypeName = "varchar(100)")]
		public string EmpName { get; set; }

		[Column(TypeName = "varchar(100)")]
		public string EmpTitle { get; set; }


		public int EmpYrsOfService { get; set; }

		[Column(TypeName = "varchar(MAX)")]
		public string EmpImg { get; set; }


		[Required]
		public DateTime? EmpHireDate { get; set; }

		public string EmpSkillsSummary { get; set; }

	}

}