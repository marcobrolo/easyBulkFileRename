using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExifLib;

namespace BulkFileRename
{
    class filesWrapper
    {
        public string _directory {get; private set;}
        private FileInfo[] fileInfoList;


        public filesWrapper()
        {

        }

        public void setDirectory(string directoryVal)
        {
            _directory = directoryVal;
            // WHEN WE CHANGE DIRECTORY, UPDATE THE FILE LIST
            processDirectory(directoryVal);
        }

        public string[] getFilesList()
        {
            // RETURN FILE NAME LIST IN ARRAY OF STRINGS USING LINQ
            string[] fileNamelist = fileInfoList.Select(name => name.Name).ToArray();
            return fileNamelist;
            
        }

        public FileInfo[] getFileInfoList()
        {
            return fileInfoList;
        }

        private void processDirectory(string targetDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(targetDir);
            fileInfoList = dirInfo.GetFiles();

        }
    }
}
