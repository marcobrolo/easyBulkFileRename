using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkFileRename
{
    // CLASS USED TO HOLD BASIC INFO OF THE FILES SET TO BE RENAMED
    // IDEALLY WE WANT TO USE A SMALLER DATASTRUCT LIKE A TUPLE, UNFORTUNATELY
    // IT MAKES BINDING TO THE UI LIST HARDER, SO WE FALL TO USING A CUSTOM CLASS
    public class fileRenameInfo
    {
        public string originFileName { get; set; }
        public string newFileName { get; set; }

        public fileRenameInfo(string originFileNameVal, string newFileNameVal)
        {
            this.originFileName = originFileNameVal;
            this.newFileName = newFileNameVal;
        }
    }
}
