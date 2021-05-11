using System;

namespace LSS.Shared.Entities
{
	public class About
	{
		public string EmpName { get; set; }
		public string EmpTitle { get; set; }
		public int EmpYrsOfService { get; set; }

		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public string Summary { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
	}
}