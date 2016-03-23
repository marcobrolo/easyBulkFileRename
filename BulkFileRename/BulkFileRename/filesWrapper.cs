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
        private string[] exifExtensions = {".jpg", ".jpeg", ".wav", ".tiff"};
       // private FileInfoExtended[] fileInfoExtendedList;
        private List<FileInfoExtended> fileInfoExtendedList = new List<FileInfoExtended>();

        public filesWrapper()
        {

        }

        // PUBLIC ACCESS TO CHANGE DIRECTORY INWHICH WE ARE LOOKING FOR FILES
        public void setDirectory(string directoryVal)
        {
            _directory = directoryVal;
            // WHEN WE CHANGE DIRECTORY, UPDATE THE FILE LIST
            processDirectory(directoryVal);
        }

        // PUBLIC ACCESS TO GET LIST OF FILE NAMES
        public string[] getFilesList()
        {
            // RETURN FILE NAME LIST IN ARRAY OF STRINGS USING LINQ
            string[] fileNamelist = fileInfoList.Select(name => name.Name).ToArray();
            return fileNamelist;
            
        }

        // PUBLIC ACCESS TO GET FileInfo LIST OF SELECTED DIR
        public FileInfo[] getFileInfoList()
        {
            return fileInfoList;
        }

        public List<FileInfoExtended> getFilesListExtended()
        {
            return fileInfoExtendedList;
        }

        // GRAB ALL FILES IN TARGET DIRECTORY AND SET LIST AS PROPERTY
        private void processDirectory(string targetDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(targetDir);
            fileInfoList = dirInfo.GetFiles();

            foreach (FileInfo f in fileInfoList)
            {
                FileInfoExtended newFile = new FileInfoExtended(f);
                if (exifExtensions.Contains(f.Extension))
                {
                    newFile.exifDate = getExifInfo(f.FullName);
                }
                fileInfoExtendedList.Add(newFile);
            }
        }

        // GETS EXIF DATA FROM ANY VALID FILE, JPG, WAV, TAR
        // http://www.codeproject.com/Articles/36342/ExifLib-A-Fast-Exif-Data-Extractor-for-NET
        public string getExifInfo (string path)
        {
            try
            {
                using (ExifReader reader = new ExifReader(path))
                {
                    DateTime datePictureTaken;
                    if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
                    {
                        return datePictureTaken.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                if (e.ToString() != "Unable to locate Exif data")
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return null;
        }
    }
}
