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


namespace BitServices.View
{
    /// <summary>
    /// Interaction logic for Roster.xaml
    /// </summary>
    public partial class Roster : Window
    {
        public Roster(string ContractorID)
        {
            InitializeComponent();
            this.DataContext = new AvailabilityViewModel(ContractorID);
            }

            private void dtStartDate_CalendarOpened(object sender, RoutedEventArgs e)
            {
                dtStartDate.DisplayDateStart = DateTime.Now;
                ////dtStartDate.FirstDayOfWeek = DayOfWeek.Monday;
                ////// dtStartDate.DisplayDate = dtStartDate.First
                ////var now = DateTime.Now;
                ////var startOfWeek = new DateTime(now.Year, now.Month, now.Day);
                ////var firstDayOfWeek = startOfWeek.DayOfWeek;

                //DateTime today = DateTime.Today;
                //// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
                //int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
                //DateTime nextMonday = today.AddDays(daysUntilMonday);
                //dtStartDate.SelectedDate = nextMonday;
                //MessageBox.Show(nextMonday + "");
            }

        private void dtStartDate_Loaded(object sender, RoutedEventArgs e)
        {
            dtStartDate.DisplayDateStart = DateTime.Now;
        }

        //private void dtEndDate_CalendarOpened(object sender, RoutedEventArgs e)
        //{
        //    dtEndDate.DisplayDateStart = System.DateTime.Today.AddDays(7);

        //    //DateTime today = DateTime.Today;
        //    //// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
        //    //int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
        //    //DateTime nextMonday = today.AddDays(daysUntilMonday);
        //    //dtStartDate.SelectedDate = nextMonday;
        //    //dtEndDate.FirstDayOfWeek = DayOfWeek.Sunday;
        //    //DateTime today1 = nextMonday;
        //    //// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
        //    //int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today1.DayOfWeek + 7) % 7;
        //    //DateTime nextSunday = today1.AddDays(daysUntilSunday);
        //    //dtEndDate.SelectedDate = nextSunday;
        //    //MessageBox.Show(nextSunday + "");
    }

            //private void btnWeek_Click(object sender, RoutedEventArgs e)
            //{
            //    DateTime today = DateTime.Today;
            //    // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            //    DateTime nextMonday = today.AddDays(daysUntilMonday);
            //    dtStartDate.SelectedDate = nextMonday;
            //    dtEndDate.FirstDayOfWeek = DayOfWeek.Sunday;
            //    DateTime today1 = nextMonday;
            //    // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today1.DayOfWeek + 7) % 7;
            //    DateTime nextSunday = today1.AddDays(daysUntilSunday);
            //    dtEndDate.SelectedDate = nextSunday;
            //    MessageBox.Show(nextSunday + "");
            //}

            //private void btnNextWeek_Click(object sender, RoutedEventArgs e)
            //{


            //    DateTime today = DateTime.Today;
            //    // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            //    DateTime nextMonday = today.AddDays(daysUntilMonday);
            //    //dtStartDate.SelectedDate = nextMonday;
            //    dtEndDate.FirstDayOfWeek = DayOfWeek.Sunday;
            //    DateTime today1 = nextMonday;
            //    // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today1.DayOfWeek + 7) % 7;
            //    DateTime nextSunday = today1.AddDays(daysUntilSunday);
            //    //dtEndDate.SelectedDate = nextSunday;
            //    today = nextSunday;
            //    // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            //    DateTime nextMonday1 = today.AddDays(daysUntilMonday);
            //    dtStartDate.SelectedDate = nextMonday1;
            //    dtEndDate.FirstDayOfWeek = DayOfWeek.Sunday;
            //    today1 = nextMonday1;
            //    MessageBox.Show(today1.ToString());
            //    int daysUntilSunday1 = ((int)DayOfWeek.Sunday - (int)today1.DayOfWeek + 7) % 7;
            //    nextSunday = today1.AddDays(daysUntilSunday1);
            //    dtEndDate.SelectedDate = nextSunday;
            //    // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]


            //    //dtStartDate.Text.Equals("");
            //    //dtEndDate.Text.Equals("");
            //    //DateTime today = DateTime.Today;
            //    //MessageBox.Show(today.ToString());
            //    //// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    //int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            //    //DateTime nextMonday = today.AddDays(daysUntilMonday);
            //    ////dtStartDate.SelectedDate = nextMonday;
            //    //today = nextMonday;
            //    //MessageBox.Show(today.ToString());
            //    //// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    //daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            //    //DateTime nextMonday1 = today.AddDays(daysUntilMonday);
            //    //dtStartDate.SelectedDate = nextMonday1;
            //    //dtEndDate.FirstDayOfWeek = DayOfWeek.Sunday;
            //    //DateTime today1 = nextMonday;
            //    //// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    //int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today1.DayOfWeek + 7) % 7;
            //    //DateTime nextSunday = today1.AddDays(daysUntilSunday);
            //    ////  dtEndDate.SelectedDate = nextSunday;
            //    //// MessageBox.Show(nextSunday + "");
            //    //today1 = nextSunday;
            //    //// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //    //daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today1.DayOfWeek + 7) % 7;
            //    //nextSunday = today1.AddDays(daysUntilSunday);
            //    //dtEndDate.SelectedDate = nextSunday;

            //}

            //private void Monday_Checked(object sender, RoutedEventArgs e)
            //{
            //    cboMonST.IsEnabled = true;
            //    cboMonET.IsEnabled = true;
            //    cboMonST.SelectedIndex = 0;
            //    cboMonET.SelectedIndex = 12;

            //}

            //private void Window_Loaded(object sender, RoutedEventArgs e)
            //{
            //    cboMonST.IsEnabled = false;
            //    cboMonET.IsEnabled = false;
            //    cboTueST.IsEnabled = false;
            //    cboTueET.IsEnabled = false;
            //    cboWedET.IsEnabled = false;
            //    cboWedST.IsEnabled = false;
            //    cboThuET.IsEnabled = false;
            //    cboThuST.IsEnabled = false;
            //    cboFriET.IsEnabled = false;
            //    cboFriST.IsEnabled = false;
            //    cboSatET.IsEnabled = false;
            //    cboSatST.IsEnabled = false;
            //    cboSunET.IsEnabled = false;
            //    cboSunST.IsEnabled = false;
            //}

            //private void Monday_Unchecked(object sender, RoutedEventArgs e)
            //{
            //    cboMonST.IsEnabled = false;
            //    cboMonET.IsEnabled = false;
            //}

            //private void Tuesday_Checked(object sender, RoutedEventArgs e)
            //{
            //    cboTueST.IsEnabled = true;
            //    cboTueET.IsEnabled = true;
            //    cboTueST.SelectedIndex = 0;
            //    cboTueET.SelectedIndex = 12;
            //}

            //private void Tuesday_Unchecked(object sender, RoutedEventArgs e)
            //{
            //    cboTueST.IsEnabled = false;
            //    cboTueET.IsEnabled = false;
            //}

            //private void Wednesday_Checked(object sender, RoutedEventArgs e)
            //{
            //    cboWedET.IsEnabled = true;
            //    cboWedST.IsEnabled = true;
            //    cboWedST.SelectedIndex = 0;
            //    cboWedET.SelectedIndex = 12;
            //}

            //private void Wednesday_Unchecked(object sender, RoutedEventArgs e)
            //{
            //    cboWedET.IsEnabled = false;
            //    cboWedST.IsEnabled = false;
            //}

            //private void Thursday_Checked(object sender, RoutedEventArgs e)
            //{
            //    cboThuET.IsEnabled = true;
            //    cboThuST.IsEnabled = true;
            //    cboThuST.SelectedIndex = 0;
            //    cboThuET.SelectedIndex = 12;
            //}

            //private void Thursday_Unchecked(object sender, RoutedEventArgs e)
            //{
            //    cboThuET.IsEnabled = false;
            //    cboThuST.IsEnabled = false;
            //}

            //private void Friday_Checked(object sender, RoutedEventArgs e)
            //{
            //    cboFriET.IsEnabled = true;
            //    cboFriST.IsEnabled = true;
            //    cboFriST.SelectedIndex = 0;
            //    cboFriET.SelectedIndex = 12;
            //}

            //private void Friday_Unchecked(object sender, RoutedEventArgs e)
            //{
            //    cboFriET.IsEnabled = false;
            //    cboFriST.IsEnabled = false;
            //}

            //private void Saturday_Checked(object sender, RoutedEventArgs e)
            //{
            //    cboSatET.IsEnabled = true;
            //    cboSatST.IsEnabled = true;
            //    cboSatST.SelectedIndex = 0;
            //    cboSatET.SelectedIndex = 12;
            //}

            //private void Saturday_Unchecked(object sender, RoutedEventArgs e)
            //{
            //    cboSatET.IsEnabled = false;
            //    cboSatST.IsEnabled = false;
            //}

            //private void Sunday_Checked(object sender, RoutedEventArgs e)
            //{
            //    cboSunET.IsEnabled = true;
            //    cboSunST.IsEnabled = true;
            //    cboSunST.SelectedIndex = 0;
            //    cboSunET.SelectedIndex = 12;
            //}

            //private void Sunday_Unchecked(object sender, RoutedEventArgs e)
            //{
            //    cboSunET.IsEnabled = false;
            //    cboSunST.IsEnabled = false;
            //}
        }
 


