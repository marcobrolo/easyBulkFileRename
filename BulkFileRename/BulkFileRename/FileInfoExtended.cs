using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BulkFileRename
{   
    // SINCE WE CANNOT INERIHIT SEALED CLASSES, WE WILL TRY TO MAKE A COMPOSITE CLASS
    public class FileInfoExtended : IEquatable<FileInfoExtended>
    {
        public FileInfo FileInfo { get; set; }
        public string exifDate { get; set; } // DECIDED TO LEAVE THIS AS A STRING FOR NOW SINCE ITS EASY TO CONVERT
        public string originFileName { get; set; }
        public string newFileName { get; set; }

        public FileInfoExtended(FileInfo file)
        {
            this.FileInfo = file;
            this.originFileName = file.Name;
            this.newFileName = file.Name;
        }

        public bool Equals(FileInfoExtended other)
        {
            return (this.FileInfo.Name == other.FileInfo.Name
                 && this.FileInfo.Length == other.FileInfo.Length);
        }

        // RENAME THE CURRENT FILE
        public void ReNameFile()
        {
            // RENAME LOGIC FOUND AT http://stackoverflow.com/questions/680786/rename-some-files-in-a-folder
            File.Move(FileInfo.FullName, Path.Combine(FileInfo.DirectoryName, newFileName));
        }
    }
}
