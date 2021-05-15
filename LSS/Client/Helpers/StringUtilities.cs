using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSS.Client.Helpers
{
	public class StringUtilities
	{
		public static string toAllCaps(string value) => value.ToUpper();

		public static string removeSpecialCharsPath(string specialCharsStr)
		{
			char[] invalidPathChars = Path.GetInvalidPathChars().ToArray();
			var unwanteds = invalidPathChars.Select(c => c.ToString()).ToList();

			StringBuilder sb = new StringBuilder(specialCharsStr);
			foreach (string unwanted in unwanteds)
			{
				sb.Replace(unwanted, string.Empty).Replace(" ", "-");
			}
			return sb.ToString();
		}

	}

}
