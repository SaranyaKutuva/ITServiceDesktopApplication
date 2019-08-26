using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices.Commands;
using System.Collections.ObjectModel;
using BitServices.Model;
using System.Data;
using System.Windows;

namespace BitServices.ViewModel
{
    class MainWindowViewModel : NotificationClass
    {
        private login login;
        
        private RelayCommand checkRelay;
        private ObservableCollection<login> loginCollection = new ObservableCollection<login>();
        public ObservableCollection<login> LoginCollection
        {
            get { return loginCollection; }
            set
            {
                loginCollection = value;
                OnPropertyChanged("LoginCollection");
            }
        }
        public login SelectedUser
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public MainWindowViewModel()
        {
            //1. Its going to connect to DAL and bring in the results of all Instructors
            //2. we Create objects of type instructor and then add that object to our collection
            /*DAL dal = new DAL();
             DataTable dt = dal.Read("Select * from bit_user_logon where 1=2");
             foreach (DataRow dr in dt.Rows)
             {
                 MessageBox.Show(" USER " + dr[0].ToString());
                 login login = new login(dr);
                 loginCollection.Add(login);

             }*/

            login login = new login();
            loginCollection.Add(login);
            SelectedUser = login;



        }
        
       /* private RelayCommand LoginButtonClick
        {
            get { return new RelayCommand(CheckUser, true); }

            set
            {
                checkRelay = value;
                OnPropertyChanged("CheckUser");
            }
        }*/
        public string CheckUser(string password)
        {
            
           return SelectedUser.Check(password);
        }
    }
}
