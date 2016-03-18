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
using System.Collections.Generic;

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
        private List<fileName> fileNameOBJList = new List<fileName>();
        

        private class fileName
        {
            public string originFileName { get; set; }
            public string newFileName { get; set; }

            public fileName() { }
            public fileName(String originalNameVal)
            {
                originFileName = originalNameVal;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        // OPENS UP DIRECTORY SELECTION BOX AND HANDLES POST EVENTS
        private void btnOpenDir_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine(dialog.SelectedPath);
                directoryPath = dialog.SelectedPath.Replace(@"\", @"\\");
                labelDirectory.Content = dialog.SelectedPath;
                _fileWrapper.setDirectory( directoryPath);
                string[] fileNameList = _fileWrapper.getFilesList();
                foreach (string file in fileNameList)
                {
                    this.listViewFileList.Items.Add(new fileName(file));
                    this.fileNameOBJList.Add(new fileName(file));
                    
                }
                DataGridFileNameList.ItemsSource = fileNameOBJList;

            }
        }

        private void listViewFileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // FUNCTION TO GRAB FILES IN CURRENT DIRECTORY
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as fileName;
            if (item != null)
            {
                //listViewFileList.SelectedItems[0].BeginEdit();
                Console.WriteLine("Item's Double Click handled!" + item.originFileName);
                
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

    }
}
