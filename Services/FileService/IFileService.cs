using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Event_App.Services.FileService
{
	public interface IFileService
	{
		public void ResetPathVariables();
		public IEnumerable<string> ListSubdirectories(string path);
		public bool CreateBaseFolderStructure();
		public bool CreateFolder(string path);
		public bool CheckFolder(string path);
		public bool DeleteFolder(string path);

	}
}
