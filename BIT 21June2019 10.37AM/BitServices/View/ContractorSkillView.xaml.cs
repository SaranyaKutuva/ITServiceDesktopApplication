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
using System.Windows.Shapes;
using BitServices.ViewModel;
using BitServices.Model;
using System.Data;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for ContractorSkillView.xaml
    /// </summary>
    public partial class ContractorSkillView : Window
    {
        int contractor_Id;
        public ContractorSkillView(string contractor_Id)
        {
            InitializeComponent();

            this.DataContext = new ContractorSkillViewModel(contractor_Id);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //This is where you will list all the remaining suburbs on the left part of the listbox and current preferred suburbs on the right side for that specific driver
            Contractor contractor = new Contractor();
            MessageBox.Show("Hi");
            contractor.ContractorID = contractor_Id;
            DataTable dt = contractor.ReadOtherSkills();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstSkills.Items.Add(dt.Rows[i][0].ToString());
            }
            btnAdd.IsEnabled = false;
            btnRemove.IsEnabled = false;
        }

        private void lstSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            btnRemove.IsEnabled = false;
        }

        private void lstcContractorSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            btnAdd.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnRemove.IsEnabled = false;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = false;
        }
    }
}
