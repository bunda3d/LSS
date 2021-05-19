using System;

namespace LSS.Shared.Entities
{
	public class About
	{
		public int Id { get; set; }
		public string EmpName { get; set; }

		public string EmpTitle { get; set; }

		public int EmpYrsOfService { get; set; }

		public string EmpImg { get; set; }

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