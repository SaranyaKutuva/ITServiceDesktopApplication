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
    /// Interaction logic for JobAssignmentPageView.xaml
    /// </summary>
    public partial class JobAssignmentPageView : Page
    {
        public string clientId;
        public string selectedJobRequestcols = "";
        public JobAssignmentPageView()
        {
            InitializeComponent();
           // this.DataContext = new JobRequestViewModel(ClientId);
        }

        private void JobRequestDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            JobRequestDate.SelectedDate = System.DateTime.Today;
            JobRequestDate.DisplayDateStart = System.DateTime.Now;
            var startDate = System.DateTime.Now;
            JobRequestDate.DisplayDateEnd = startDate.AddMonths(1);
        }
      
        private void aboClientId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cm = (ComboBox)sender;
            selectedJobRequestcols = cm.SelectedValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
