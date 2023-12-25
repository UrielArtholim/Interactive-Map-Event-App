using Interactive_Map_Event_App.Services.StringFormatterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Event_App.Services.FileService
{
	public class FileService: IFileService
	{
		private readonly IStringFormatterService stringFormatterService;
		private readonly string defaultBaseFolderPath;
		private readonly string defaultMapsFolderPath;

		private string baseFolder;
		private string mapsFolder;

		public FileService(IStringFormatterService stringFormatterService)
		{
			this.stringFormatterService = stringFormatterService;
			this.defaultBaseFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			this.defaultMapsFolderPath = string.Concat(defaultBaseFolderPath, "maps");
			this.baseFolder = defaultBaseFolderPath;
			this.mapsFolder = defaultMapsFolderPath;
		}

		public void ResetPathVariables()
		{
			this.baseFolder = defaultBaseFolderPath;
			this.mapsFolder = defaultMapsFolderPath;
		}

		public string BaseFolder { get => baseFolder; set => baseFolder = value; }
		public string MapsFolder { get => mapsFolder; set => mapsFolder = value; }

		public IEnumerable<string> ListSubdirectories(string path)
		{
			var maps = Directory.GetDirectories(path);
			return maps.Select(map => stringFormatterService.GetItemFileNameFromPath(map));
		}

		public bool CreateBaseFolderStructure()
		{
			bool structureModified = false;
			if(!Directory.Exists(BaseFolder))
			{
				Directory.CreateDirectory(BaseFolder);
				structureModified = true;
			}
			if(!Directory.Exists(MapsFolder))
			{
				Directory.CreateDirectory(MapsFolder);
				structureModified = true;
			}
			return structureModified;
		}

		public bool CreateFolder(string path)
		{
			bool folderCreated = false;
			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
				folderCreated = true;
			}
			return folderCreated;
		}

		public bool CheckFolder(string path)
		{
			return Directory.Exists(path);
		}

		public bool DeleteFolder(string path)
		{
			bool folderDeleted = false;
			if(Directory.Exists(path)) 
			{ 
				Directory.Delete(path, true);
				folderDeleted = true;
			}
			return folderDeleted;
		}

	}
}
