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
using BitServices.ViewModel;
using System.Windows.Shapes;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for MainWindowPageView.xaml
    /// </summary>
    public partial class MainWindowPageView : Page
    {
       // Frame Frame;
        public MainWindowPageView()
        { 
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
            // Frame = frame;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //MainPage mainPage = new MainPage();
            //mainPage.Show();
            // Frame.Content = null;
            // Main.Content = new MainPage();
            //
            MainWindowViewModel mp = (MainWindowViewModel)this.DataContext;
            //   mp.CheckUser();
            //MessageBox.Show(Password.Password.ToString());
            if (mp.CheckUser(Password.Password.ToString()).ToUpper().Equals("COORDINATOR"))
            {
                ////MessageBox.Show("COORDINATOR");
                Main.Content = new MainPage1();
            }
            else if (mp.CheckUser(Password.Password.ToString()).ToUpper().Equals("ADMIN"))
            {
              //  MessageBox.Show("ADMIN");
                Main.Content = new MainPage();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password!", "Invalid Login Details",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
