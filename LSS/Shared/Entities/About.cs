using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
	public class About
	{
		public int Id { get; set; }

		[Column(TypeName = "varchar(100)")]
		public string EmpName { get; set; }

		[Column(TypeName = "varchar(100)")]
		public string EmpTitle { get; set; }


		public int EmpYrsOfService { get; set; }

		public string EmpImg { get; set; }


		[Required]
		public DateTime Date { get; set; }

		public string Summary { get; set; }

	}

	public class OpenHrs
  {

		public string DayOfWk { get; set; }

		public string OpenTime { get; set; }

		public string ClosingTime { get; set; }

		public string OpenHrsMsg { get; set; }


  }

}