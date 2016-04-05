using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BulkFileRename
{
    // CLASS USED TO HOLD BASIC INFO OF THE FILES SET TO BE RENAMED
    // IDEALLY WE WANT TO USE A SMALLER DATASTRUCT LIKE A TUPLE, UNFORTUNATELY
    // IT MAKES BINDING TO THE UI LIST HARDER, SO WE FALL TO USING A CUSTOM CLASS

    // NOTE: PERHAPS IS BETTER TO ELMINATE THIS CLASS IN FAVOUR OF PASSING OUR FileInfoExtended OBJS
    // AROUND, HOWEVER THERE MIGHT BE PERFORMANCE ISSUES WITH THAT, ESPECIALLY WHEN N=NUM OF FILES IS HUGE
    public class fileRenameInfo
    {
        public string originFileName { get; set; }
        public string newFileName { get; set; }
        public string fullFileName { get; set; }

        public fileRenameInfo(string originFileNameVal, string newFileNameVal, string fullFileNameVal)
        {
            this.originFileName = originFileNameVal;
            this.newFileName = newFileNameVal;
            this.fullFileName = fullFileNameVal;
        }

        /*
        // RENAME THE CURRENT FILE
        public void ReNameFile(string newFileName)
        {
            // RENAME LOGIC FOUND AT http://stackoverflow.com/questions/680786/rename-some-files-in-a-folder
            File.Move(fullFileName, Path.Combine(FileInfo.DirectoryName, newFileName));
        }*/
    }
}
