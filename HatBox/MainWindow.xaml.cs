using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;
using HatBox.Class;

namespace HatBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PentestViewModel _viewModel = new PentestViewModel();

        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _viewModel.ClearProcess();
        }

        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = string.Empty;

            _viewModel.ClearProcess();
            _viewModel.Url = txtUrl.Text;
            if (_viewModel.Pentest.IsValidUrl)
            {
                _viewModel.ProcessPentest();
            }
            else
            {
                lblError.Content = "Url incorrecte.";
            }
        }

        private void txtLog_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLog.ScrollToEnd();
        }

        private void trvDatabases_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = e.OriginalSource as TreeViewItem;

            if (tvi.ItemsSource.OfType<HatBox.Class.Table>().Count() > 0)
            {
                if (!(tvi.DataContext as Database).Selectable)
                {
                    _viewModel.UpdateTables(tvi.DataContext as Database);
                }
            }
            else if (tvi.ItemsSource.OfType<HatBox.Class.Column>().Count() > 0)
            {
                if (!(tvi.DataContext as Class.Table).Selectable)
                {
                    _viewModel.UpdateColumns(tvi.DataContext as HatBox.Class.Table);
                }
            }
        }

        private void CheckBoxTable_Checked(object sender, RoutedEventArgs e)
        {
            HatBox.Class.Table tbl = (e.OriginalSource as CheckBox).DataContext as HatBox.Class.Table;
            _viewModel.UnselectOtherTables(tbl);
            _viewModel.SelectColumns(tbl);
        }
        private void CheckBoxTable_Unchecked(object sender, RoutedEventArgs e)
        {
            HatBox.Class.Table tbl = (e.OriginalSource as CheckBox).DataContext as HatBox.Class.Table;
            _viewModel.UnselectColumns(tbl);
        }

        private void CheckBoxColumn_Checked(object sender, RoutedEventArgs e)
        {
            HatBox.Class.Column col = (e.OriginalSource as CheckBox).DataContext as HatBox.Class.Column;
            _viewModel.UnselectOtherTables(col.ParentTable);
        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RetrieveData(dgrResults);
        }
        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RetrieveData(dgrResults, true);
        }
    }
}
