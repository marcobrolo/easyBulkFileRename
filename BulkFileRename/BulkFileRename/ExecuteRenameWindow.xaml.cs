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
        public List<fileRenameInfo> _changeList { get; set; }

        public ExecuteRenameWindow(List<fileRenameInfo> changeListVal)
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

        }
    }
}
