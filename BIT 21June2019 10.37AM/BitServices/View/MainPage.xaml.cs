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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            //   Main.Content = new MainWindowPageView(this.Main);
        }
        private void menuColorChange(object sender)
        {
            //clear previously set backgrounds...
            foreach (Button menuItem in mainMenu.Items.OfType<Button>())
            {
                menuItem.SetValue(Button.BackgroundProperty, null);
                menuItem.SetValue(Button.BorderBrushProperty, null);
            }


            Button mi = (Button)sender;
            var converter = new System.Windows.Media.BrushConverter();

            mi.Background = (SolidColorBrush)converter.ConvertFromString("#3D26A0DA");
            mi.BorderBrush = (SolidColorBrush)converter.ConvertFromString("#FF26A0DA");

        }
        ClientManagementPageView cmpv;

        private void menuClient_Click(object sender, RoutedEventArgs e)
        {
            // DockPanel.DockProperty.d

            menuColorChange(sender);

            Main.Content = new ClientManagementPageView();
        }

        private void menuContractor_Click(object sender, RoutedEventArgs e)
        {
            menuColorChange(sender);
            Main.Content = new ContractorManagementPageView();
        }

        private void menuEmployee_Click(object sender, RoutedEventArgs e)
        {
            menuColorChange(sender);
            Main.Content = new EmployeeManagementPageView();
        }

        private void menuSkill_Click(object sender, RoutedEventArgs e)
        {
            menuColorChange(sender);
            Main.Content = new SkillManagementPageView();
        }

        private void menuJobRequest_Click(object sender, RoutedEventArgs e)
        {
            menuColorChange(sender);
            Main.Content = new JobAssignmentPageView();
        }

        private void menuPayment_Click(object sender, RoutedEventArgs e)
        {
            //  Main.Content = new ContractorPaymentPageView();
        }

        private void menuAssign_Click(object sender, RoutedEventArgs e)
        {
            menuColorChange(sender);
            Main.Content = new JobAssignPageView();
        }

        private void menuPayment_Click_1(object sender, RoutedEventArgs e)
        {
            //  Main.Content = new ContractorPaymentPageView();
        }

        private void menuClient_MouseEnter(object sender, MouseEventArgs e)
        {
            //Button bt = sender as Button;
            // converter.ConvertFromStrin
            //  var converter = new System.Windows.Media.BrushConverter();
            // bt.Background = (SolidColorBrush) converter.ConvertFromString("#36486b");
        }

        private void mainMenu_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void menulogout_Click(object sender, RoutedEventArgs e)
        {

           // Main.cl
           // Main.GoBack();
           // Main.Margin = new Thickness(-10);
         //   Main.Content = new MainWindowPageView();

            //MessageBox.Show("karthik");
            //MainWindowPageView mpv = new MainWindowPageView();
            //mpv.Main.Content =  new MainWindowPageView();
            //  MainWindowPageView page = new MainWindowPageView();
            // MainWindowPageView.
          //  new MainWindowPageView
            //this.NavigationService.Navigate(new Uri("MainWindowPageView.xaml", UriKind.Relative));

        }

    }
}
