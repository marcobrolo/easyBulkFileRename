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

        public MainWindow()
        {
            InitializeComponent();
        }

        // DEBUG FUNCTIONALITY TO LOG FILEINFO LIST PROPERTIES
        private void btnPrintFile_Click(object sender, RoutedEventArgs e)
        {
            
            if (_fileWrapper != null)
            {
                foreach (var fileExtension in _fileWrapper.fileInfoExtendedList)
                {
                    Console.WriteLine(fileExtension.originFileName + fileExtension.newFileName);
                }
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
                this.directoryPath = dialog.SelectedPath.Replace(@"\", @"\\");
                this.labelDirectory.Content = dialog.SelectedPath;

                // INITIATE FILEWRAPPER TO PROCESS ALL FILES IN THE SELECTED DIRECTORY
                renderFileListDisplay();
                
            }
        }

        // Clears all the new file names
        private void btnClearNewNames_Click(object sender, RoutedEventArgs e)
        {
            if (_fileWrapper != null)
            {
                foreach (var fileExtension in _fileWrapper.fileInfoExtendedList)
                {
                    fileExtension.newFileName = "";
                }
            }
        }

        // SETUP THE DATAGRID VIEW TO SHOW THE FILES LISTED IN THE DIRECTORY
        private void renderFileListDisplay()
        {
            // INITIATE FILEWRAPPER TO PROCESS ALL FILES IN THE SELECTED DIRECTORY
            _fileWrapper.setDirectory(directoryPath);
            DataGridFileNameList.ItemsSource = null;
            DataGridFileNameList.ItemsSource = _fileWrapper.fileInfoExtendedList;
           
        }

        // BTN TO EXECUTE THE RENAMING OF THE FILES
        // OPTIMIZATION IDEA: RIGHT NOW WE WILL GO THROUGH LIST TO SEE WHICH FILES NEED TO BE RENAMED
        // PERHAPS MAKE A NEW POINTER LIST TO ONLY FILES THAT HAD A CHANGE
        private void btnExecuteRename_Click(object sender, RoutedEventArgs e)
        {
            // POPUP OUR NEW WINDOW
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/bced6b99-c8ce-425e-9b34-967a361cedd2/open-new-wpf-window?forum=wpf
            var newWindow = new ExecuteRenameWindow(_fileWrapper.getListOfChangedFileNames());
            newWindow.ShowDialog();
            
            if (newWindow.result == true)
            {
                renderFileListDisplay();
            }
        }


        // CHECK THE NEW FILE NAME ENTERED BY THE USER TO MAKE SURE ITS NOT EMPTY
        private void DateGridFileNameList_OnEndEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            //http://stackoverflow.com/questions/7660212/how-can-i-get-a-string-value-from-a-datagrid-cell
            DependencyObject dep = (DependencyObject)e.EditingElement;
            var rowView = (FileInfoExtended)e.Row.Item;
            string txtValue = ((System.Windows.Controls.TextBox)e.EditingElement).Text;
            if (String.IsNullOrEmpty(txtValue))
            {
                string oldFileName = rowView.originFileName;

                System.Windows.Forms.MessageBox.Show("New file name cannot be empty", 
                                                    "Error", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                ((System.Windows.Controls.TextBox)e.EditingElement).Text = oldFileName;                   
            }          
        }
    }
}
