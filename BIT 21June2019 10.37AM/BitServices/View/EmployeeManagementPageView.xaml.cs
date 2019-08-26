using System;
using System.Collections.Generic;
using System.Data;
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
using BitServices.Model;
using BitServices.ViewModel;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for EmployeeManagementPageView.xaml
    /// </summary>
    public partial class EmployeeManagementPageView : Page
    {
        public EmployeeManagementPageView()
        {
            InitializeComponent();
            this.DataContext = new EmployeeManagementViewModel();
          
        }

        private void EmployeeDOB_CalendarOpened(object sender, RoutedEventArgs e)
        {
            EmployeeDOB.SelectedDate = System.DateTime.Today.AddYears(-20);
          // var startDate = System.DateTime.Today;
            EmployeeDOB.DisplayDateStart = DateTime.Now.AddYears(-100);
            EmployeeDOB.DisplayDateEnd = System.DateTime.Now.AddYears(-20);
        }
    }
}
