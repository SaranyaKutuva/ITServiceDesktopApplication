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

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for MainPage1.xaml
    /// </summary>
    public partial class MainPage1 : Page
    {
        public MainPage1()
        {
            InitializeComponent();
        }
        private void menuClient_Click(object sender, RoutedEventArgs e)
        {
            // DockPanel.DockProperty.d
            Main.Content = new ClientManagementPageView();
        }

        private void menuContractor_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ContractorManagementPageView();
        }

        private void menuEmployee_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeeManagementPageView();
        }

        private void menuSkill_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SkillManagementPageView();
        }

        private void menuJobRequest_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new JobAssignmentPageView();
        }

        private void menuPayment_Click(object sender, RoutedEventArgs e)
        {
            //  Main.Content = new ContractorPaymentPageView();
        }

        private void menuAssign_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new JobAssignPageView();
        }

        private void menuPayment_Click_1(object sender, RoutedEventArgs e)
        {
            //  Main.Content = new ContractorPaymentPageView();
        }
    }
}
