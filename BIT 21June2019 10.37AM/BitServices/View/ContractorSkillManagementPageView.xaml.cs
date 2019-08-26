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
using BitServices.Model;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for ContractorSkillManagementPageView.xaml
    /// </summary>
    public partial class ContractorSkillManagementPageView : Page
    {
        public ContractorSkillManagementPageView()
        {
            InitializeComponent();
            this.DataContext = new ContractorSkillViewModel();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ////This is where you will list all the remaining suburbs on the left part of the listbox and current preferred suburbs on the right side for that specific driver
            //Contractor contractor = new Contractor();
            //contractor.ContractorID = 
            //DataTable dt = d.ReadOtherSuburbs();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    lstSuburbs.Items.Add(dt.Rows[i][0].ToString());
            //}
        }
    }
}
