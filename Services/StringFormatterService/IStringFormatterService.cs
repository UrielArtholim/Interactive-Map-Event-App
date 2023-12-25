using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Event_App.Services.StringFormatterService
{
	public interface IStringFormatterService
	{
		public string GetFormattedTitleName(string title);

		public string GetEscapedTitleName(string title);

		public string GetItemFileName(string name);

		public string GetItemFileNameFromPath(string path);

		public CultureInfo GetCultureInfo();
	}
}
