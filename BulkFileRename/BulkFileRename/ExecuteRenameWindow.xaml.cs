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
using System.Windows.Shapes;


namespace BulkFileRename
{
    /// <summary>
    /// Interaction logic for ExecuteRename.xaml
    /// </summary>
    public partial class ExecuteRenameWindow : Window
    {
        private List<FileInfoExtended> _changeList { get; set; }
        // USED TO LET PARENT KNOW IF USER CANCELLED WINDOW OR PROCEEDED WITH RENAME PROCESS
        public bool result = false;
        

        public ExecuteRenameWindow(List<FileInfoExtended> changeListVal)
        {
            this._changeList = changeListVal;
            InitializeComponent();
            listViewRenameFileInfo.ItemsSource = this._changeList;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (FileInfoExtended f in _changeList)
                {
                    f.ReNameFile();
                    f.originFileName = f.newFileName;
                }
            }
            catch (Exception err)
            {
                // LOOK INTO LOGGING LIBRARIES SUCH AS LOG4NET TO WRITE LOGS INTO EXTERNAL FILES
                Console.WriteLine(err);
            }

            result = true;
            this.Close();
        }
    }
}
