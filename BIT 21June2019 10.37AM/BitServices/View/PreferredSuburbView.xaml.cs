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
using System.Windows.Shapes;
using BitServices.Model;
using BitServices.ViewModel;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for PreferredSuburbView.xaml
    /// </summary>
    public partial class PreferredSuburbView : Window
    {
        int contractor_Id;
        public PreferredSuburbView(string contractor_Id)
        {
            InitializeComponent();
            this.DataContext = new PreferredSuburbViewModel(contractor_Id);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //This is where you will list all the remaining suburbs on the left part of the listbox and current preferred suburbs on the right side for that specific Contractor
            Contractor contractor = new Contractor();
            MessageBox.Show("Hi");
            contractor.ContractorID = contractor_Id;
            //DataTable dt = contractor.ReadOtherSuburbs();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    lstSkills.Items.Add(dt.Rows[i][0].ToString());
            //}
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnRemove.IsEnabled = false;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = false;
        
        }

        private void lstSuburb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            btnRemove.IsEnabled = false;
        }

        private void lstContractorSuburb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            btnAdd.IsEnabled = false;
        }
    }
}

