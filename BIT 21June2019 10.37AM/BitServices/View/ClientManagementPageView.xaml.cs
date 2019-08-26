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
using BitServices.Model;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for ClientManagementPageView.xaml
    /// </summary>
    public partial class ClientManagementPageView : Page
    {
        public string selectedClientCols ="";
        public ClientManagementPageView()
        {
            InitializeComponent();
            this.DataContext = new ClientManagementViewModel();
        }

        private void btnAddress_Click(object sender, RoutedEventArgs e)
        {
            string selectedClientID="";
            int selectedUserID =0;



            foreach (Client row in clientDG.SelectedItems)
            {

                //  MessageBox.Show("k" + row.ClientID);
                // System.Data.DataRow MyRow = (System.Data.DataRow)row.Item;
                // selectedClientID = MyRow["ClientID"].ToString();
                // var rowContainer = this.clientDG.ItemContainerGenerator.ContainerFromItem//(sender) as DataGridRow;
                selectedClientID = row.ClientID.ToString();
                selectedUserID = row.UserID;
            }
            ClientAddress client = new ClientAddress(selectedClientID);
          //  MessageBox.Show(selectedClientID);
            client.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cm = (ComboBox)sender;
           selectedClientCols = cm.SelectedValue.ToString();

        //MessageBox.Show( cm.SelectedValue.ToString());
        }

        private void ClientDOB_CalendarOpened(object sender, RoutedEventArgs e)
        {
            ClientDOB.SelectedDate = System.DateTime.Today.AddYears(-20);
            ClientDOB.DisplayDateStart = System.DateTime.Today.AddYears(-80);
            ClientDOB.DisplayDateEnd = System.DateTime.Today.AddYears(-20);
        }

        private void btnNewJobRequest_Click(object sender, RoutedEventArgs e)
        {
            string selectedClientID = "";
            int selectedUserID = 0;



            foreach (Client row in clientDG.SelectedItems)
            {

                //  MessageBox.Show("k" + row.ClientID);
                // System.Data.DataRow MyRow = (System.Data.DataRow)row.Item;
                // selectedClientID = MyRow["ClientID"].ToString();
                // var rowContainer = this.clientDG.ItemContainerGenerator.ContainerFromItem//(sender) as DataGridRow;
                selectedClientID = row.ClientID.ToString();
                selectedUserID = row.UserID;
            }
            ClientJobRequestView client = new ClientJobRequestView(selectedClientID);
            //  MessageBox.Show(selectedClientID);
            client.Show();
        }

        private void clientDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
