using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BulkFileRename
{   
    // SINCE WE CANNOT INERIHIT SEALED CLASSES, WE WILL TRY TO MAKE A COMPOSITE CLASS
    class FileInfoExtended : IEquatable<FileInfoExtended>
    {
        public FileInfo FileInfo { get; set; }
        public string exifDate { get; set; } // DECIDED TO LEAVE THIS AS A STRING FOR NOW SINCE ITS EASY TO CONVERT
        public string newFileName { get; set; }

        public FileInfoExtended(FileInfo file)
        {
            this.FileInfo = file;
        }


        public bool Equals(FileInfoExtended other)
        {
            return (this.FileInfo.Name == other.FileInfo.Name
                 && this.FileInfo.Length == other.FileInfo.Length);
        }
    }
}
