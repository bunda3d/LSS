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

		public static string removeSpecialCharsPath(string uriPath)
		{
      //return string.Join("_", uriPath.Split(Path.GetInvalidPathChars()));

      char[] invalidPathChars = Path.GetInvalidPathChars().ToArray();
      var unwanteds = invalidPathChars.Select(c => c.ToString()).ToList();

      StringBuilder sb = new StringBuilder(uriPath);
      for (int i = 0; i < unwanteds.Count; i++)
      {
        string unwanted = unwanteds[i];
        sb.Replace(unwanted, string.Empty).Replace(" ", "-");
      }
      return sb.ToString();
    }

	}

}
