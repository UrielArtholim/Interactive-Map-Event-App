using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Event_App.Services.StringFormatterService
{
	public class StringFormatterService : IStringFormatterService
	{
		private readonly TextInfo ti = Thread.CurrentThread.CurrentCulture.TextInfo;

		public StringFormatterService(){}

		public string GetFormattedTitleName(string title)
		{
			return ti.ToTitleCase(title.Replace("-", " "));
		}

		public string GetEscapedTitleName(string title)
		{
			return ti.ToLower(title.Replace(" ", "-"));
		}

		public string GetItemFileName(string name)
		{
			return $"{GetEscapedTitleName(name)}.html";
		}

		public string GetItemFileNameFromPath(string path)
		{
			return GetItemFileName(path.Split('/').Last().Split('.').First());
		}

		public CultureInfo GetCultureInfo()
		{
			return CultureInfo.InvariantCulture;
		}
	}
}
