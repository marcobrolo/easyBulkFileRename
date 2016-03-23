using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace BulkFileRename
{
    /// <summary>
    /// APP TO HELP RENAME BULK FILES, PRIMARILY IMG FILES
    ///     USEFUL TODO FEATURES: EXIF INFO
    /// 
    /// USEFUL LINKS
    ///     GETTING DATE TAKEN
    ///     http://stackoverflow.com/questions/180030/how-can-i-find-out-when-a-picture-was-actually-taken-in-c-sharp-running-on-vista
    ///     FAST EFFICIENT EFIX LIB
    ///     http://www.codeproject.com/Articles/36342/ExifLib-A-Fast-Exif-Data-Extractor-for-NET-2-0
    ///     
    /// </summary>
    public partial class MainWindow : Window
    {
        private string directoryPath = "D:\\";
        private filesWrapper _fileWrapper = new filesWrapper();     
        private List<FileInfoExtended> fileInfoList = new List<FileInfoExtended>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // DEBUG FUNCTIONALITY TO LOG FILEINFO LIST PROPERTIES
        private void btnPrintFile_Click(object sender, RoutedEventArgs e)
        {
            foreach(FileInfoExtended f in fileInfoList)
            {
                Console.WriteLine(f.FileInfo.Name + f.newFileName);
            }
        }

        // OPENS UP DIRECTORY SELECTION BOX AND HANDLES POST EVENTS
        private void btnOpenDir_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            // ONCE USER HITS OK BTN AND CLOSES THE DIRECTORY SELECTION POPUP
            if (result == System.Windows.Forms.DialogResult.OK)
            {

                Console.WriteLine(dialog.SelectedPath);
                directoryPath = dialog.SelectedPath.Replace(@"\", @"\\");
                labelDirectory.Content = dialog.SelectedPath;

                // INITIATE FILEWRAPPER TO PROCESS ALL FILES IN THE SELECTED DIRECTORY
                _fileWrapper.setDirectory( directoryPath);
                fileInfoList = _fileWrapper.getFilesListExtended();
                DataGridFileNameList.ItemsSource = fileInfoList;
            }
        }

        // BTN TO EXECUTE THE RENAMING OF THE FILES
        // OPTIMIZATION IDEA: RIGHT NOW WE WILL GO THROUGH LIST TO SEE WHICH FILES NEED TO BE RENAMED
        // PERHAPS MAKE A NEW POINTER LIST TO ONLY FILES THAT HAD A CHANGE
        private void btnExecuteRename_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
