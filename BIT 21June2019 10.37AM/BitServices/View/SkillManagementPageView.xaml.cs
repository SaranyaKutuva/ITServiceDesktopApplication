using BitServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using BitServices.Model;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for SkillManagementPageView.xaml
    /// </summary>
    public partial class SkillManagementPageView : Page
    {
        public SkillManagementPageView()
        {
            InitializeComponent();
            this.DataContext = new SkillManagementViewModel();
        }
    }
    

}
