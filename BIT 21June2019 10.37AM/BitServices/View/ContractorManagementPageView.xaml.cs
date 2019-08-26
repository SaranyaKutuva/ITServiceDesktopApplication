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
using BitServices.ViewModel;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BitServices.Model;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for ContractorManagementPageView.xaml
    /// </summary>
    public partial class ContractorManagementPageView : Page
    {
        public ContractorManagementPageView()
        {
            InitializeComponent();
            this.DataContext = new ContractorManagementViewModel();
        }

        private void btnRoster_Click(object sender, RoutedEventArgs e)
        {
            string selectedContractorID = "";
            int selectedUserID = 0;



            foreach (Contractor row in dgContractor.SelectedItems)
            {

                //  MessageBox.Show("k" + row.ClientID);
                // System.Data.DataRow MyRow = (System.Data.DataRow)row.Item;
                // selectedClientID = MyRow["ClientID"].ToString();
                // var rowContainer = this.clientDG.ItemContainerGenerator.ContainerFromItem//(sender) as DataGridRow;
                selectedContractorID = row.ContractorID.ToString();
                selectedUserID = row.UserID;
            }
           
            AvailabilityView avail = new AvailabilityView(selectedContractorID);
            avail.Show();
         
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void btnNewSkills_Click(object sender, RoutedEventArgs e)
        {
            string selectedContractorID = "";
            int selectedUserID = 0;



            foreach (Contractor row in dgContractor.SelectedItems)
            {

                //  MessageBox.Show("k" + row.ClientID);
                // System.Data.DataRow MyRow = (System.Data.DataRow)row.Item;
                // selectedClientID = MyRow["ClientID"].ToString();
                // var rowContainer = this.clientDG.ItemContainerGenerator.ContainerFromItem//(sender) as DataGridRow;
                selectedContractorID = row.ContractorID.ToString();
                selectedUserID = row.UserID;
            }
            ContractorSkillView skill = new ContractorSkillView(selectedContractorID);
            skill.Show();
        }

        private void ContractorDOB_CalendarOpened(object sender, RoutedEventArgs e)
        {
            ContractorDOB.SelectedDate = System.DateTime.Now.AddYears(-20);
            ContractorDOB.DisplayDateStart = System.DateTime.Now.AddYears(-80);
            ContractorDOB.DisplayDateEnd = System.DateTime.Now.AddYears(-20);
        }


       

        //private void dgContractor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    MessageBox.Show("Hope you have Saved all your work Before You Move On");
        //}

        private void btnPreferredSuburb_Click(object sender, RoutedEventArgs e)
        {
            string selectedContractorID = "";
            int selectedUserID = 0;



            foreach (Contractor row in dgContractor.SelectedItems)
            {

                //  MessageBox.Show("k" + row.ClientID);
                // System.Data.DataRow MyRow = (System.Data.DataRow)row.Item;
                // selectedClientID = MyRow["ClientID"].ToString();
                // var rowContainer = this.clientDG.ItemContainerGenerator.ContainerFromItem//(sender) as DataGridRow;
                selectedContractorID = row.ContractorID.ToString();
                selectedUserID = row.UserID;
            }
            PreferredSuburbView suburb = new PreferredSuburbView(selectedContractorID);
            suburb.Show();
        }

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    btnAdd.IsEnabled = false;
        //    btnDelete.IsEnabled = false;
        //    btnNewSkills.IsEnabled = false;
        //    btnPreferredSuburb.IsEnabled = false;
        //    btnRoster.IsEnabled = false;
        //}

        //private void btnSave_Click(object sender, RoutedEventArgs e)
        //{
        //    btnAdd.IsEnabled = true;
        //    btnDelete.IsEnabled = true;
        //    btnNewSkills.IsEnabled = true;
        //    btnPreferredSuburb.IsEnabled = true;
        //    btnRoster.IsEnabled = true;
        //}

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
          /*  btnAdd.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnNewSkills.IsEnabled = false;
            btnPreferredSuburb.IsEnabled = false;
            btnRoster.IsEnabled = false; */
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            /*btnAdd.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnNewSkills.IsEnabled = true;
            btnPreferredSuburb.IsEnabled = true;
            btnRoster.IsEnabled = true;*/
        }
    }
}
