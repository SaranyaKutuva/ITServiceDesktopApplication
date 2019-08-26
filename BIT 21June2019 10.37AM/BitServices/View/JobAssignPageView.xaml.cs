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
using BitServices.ViewModel;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for JobAssignPageView.xaml
    /// </summary>
    public partial class JobAssignPageView : Page
    {
        public JobAssignPageView()
        {
            InitializeComponent();
            this.DataContext = new JobAssignmentViewModel();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JobAssignmentViewModel javm = (JobAssignmentViewModel)this.DataContext;
            javm.ContractorCollection.Clear();
            javm.FindContractor();
        }

        private void DataGrid_Selected(object sender, RoutedEventArgs e)
        {
            JobAssignmentViewModel obj = (JobAssignmentViewModel)DataContext;
            // obj.IsContractorSelected = true;
            DataGrid dg = (DataGrid)sender;
           // MessageBox.Show(dg.SelectedIndex.ToString());

        }

        private void DataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            JobAssignmentViewModel obj = (JobAssignmentViewModel)DataContext;
            DataGrid dg = (DataGrid)sender;
            MessageBox.Show(dg.SelectedIndex.ToString());
            if (dg.SelectedIndex >0)
            {
                obj.IsContractorSelected = false;
            }
           

        }

        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            //this.IsEnabled = true;
            JobAssignmentViewModel obj = (JobAssignmentViewModel)DataContext;
            obj.IsContractorSelected = true;
        }
    }
}
