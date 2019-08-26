using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitServices.Model;
using BitServices.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using BitServices.View;
using System.Text.RegularExpressions;

namespace BitServices.ViewModel
{
    class ClientManagementViewModel : NotificationClass
    {
        // This class is the communication class between your view(ClientsManagementPageView.Xaml) and to your Model (Client.cs)
        // Create a list that will generated from Database
        private Client client;
       
    
        //   private Person person;
        private RelayCommand addRelay;
        private RelayCommand updateRelay;
        private RelayCommand deleteRelay;
        private RelayCommand searchRelay;
        private ObservableCollection<Client> clientCollection = new ObservableCollection<Client>();
       
       

        private DataTable clientColRows;
        private string clientSearchString;

        private Boolean isEnabledAdd;
        public Boolean IsEnabledAdd
        {
            get { return isEnabledAdd; }
            set
            {
                isEnabledAdd = value;
                OnPropertyChanged("IsEnabledAdd");
            }
        }
        private Boolean isEnabledSave;
        public Boolean IsEnabledSave
        {
            get { return isEnabledSave; }
            set
            {
                isEnabledSave = value;
                OnPropertyChanged("IsEnabledSave");
            }
        }

        private Boolean isEnabledDelete;
        public Boolean IsEnabledDelete
        {
            get { return isEnabledDelete; }
            set
            {
                isEnabledDelete = value;
                OnPropertyChanged("IsEnabledDelete");
            }
        }

        private Boolean isEnabledAddress;
        public Boolean IsEnabledAddress
        {
            get { return isEnabledAddress; }
            set
            {
                isEnabledAddress = value;
                OnPropertyChanged("IsEnabledAddress");
            }
        }


        private Boolean isEnabledNewjob;
        public Boolean IsEnabledNewjob
        {
            get { return isEnabledNewjob; }
            set
            {
                isEnabledNewjob = value;
                OnPropertyChanged("IsEnabledNewjob");
            }
        }


        public ObservableCollection<Client> ClientCollection
        {
            get { return clientCollection; }
            set { clientCollection = value;
                OnPropertyChanged("ClientCollection");
            }
        }
        
      
        public DataTable ClientColRows
        {
            get { return clientColRows; }
            set
            {
                clientColRows = value;
                OnPropertyChanged("ClientColRows");
            }
        }
        
   
        public Client SelectedClient
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public string ClientSearchString
        {
            get { return clientSearchString; }
            set
            {
                clientSearchString = value;
                OnPropertyChanged("ClientSearchString");
            }

        }

        public ClientManagementViewModel()
        {
            //1. Its going to connect to DAL and bring in the results of all Instructors
            //2. we Create objects of type instructor and then add that object to our collection
            DAL dal = new DAL();
            DataTable dt = dal.Read("Select * from bit_client, bit_user_logon where bit_user_logon.account_Type='CLIENT' AND bit_user_logon.account_Ref= bit_client.client_Id and (STATUS='ACTIVE' OR STATUS IS NULL)");
            foreach (DataRow dr in dt.Rows)
            {
                Client client = new Client(dr);
                ClientCollection.Add(client);
            }



            LoadFieldNameCombo();

            IsEnabledAddress = true;
            IsEnabledNewjob = true;
            
            IsEnabledAdd = true;
            IsEnabledSave = true;
            IsEnabledDelete = true;


        }
        private void LoadFieldNameCombo()
        {
            try
            {
                DAL dal = new DAL();
           
                DataTable dtFieldNames = dal.Read("SELECT COLUMN_NAME FROM information_schema.columns WHERE table_schema='bit' AND table_name='bit_client'and column_name not in ('Creation_Date', 'Created_By', 'Updated_By', 'Updated_Date', 'STATUS','Start_Date','End_Date')");


                //Map the database table field names (columns) to more human FRIENDLY names.
                //Define a new column object with the column name "FRIENDLY_NAMES"
                DataColumn colFriendlyNames = new DataColumn("FRIENDLY_NAMES", System.Type.GetType("System.String"));
                //Add our FRIENDLY_NAMES column to our DataTable.
                dtFieldNames.Columns.Add(colFriendlyNames);

                //  MessageBox.Show("Show data successful " + //"Patient");
                DataRow dtFieldNames1;
                dtFieldNames1 = dtFieldNames.NewRow();

                dtFieldNames1["FRIENDLY_NAMES"] = "--Select a Field--";
                dtFieldNames1["COLUMN_NAME"] = "0";
                dtFieldNames.Rows.InsertAt(dtFieldNames1, 0);

                foreach (DataRow dr in dtFieldNames.Rows)
                {

                    //Client client = new Client(dr);

                    //MessageBox.Show(" " + dr["COLUMN_NAME"]);

                    switch (dr[0].ToString())
                    {
                        case "Client_Id":
                            dr[1] = "Client Id";
                            break;
                        case "User_Id":
                            dr[1] = "User Id";
                            break;
                        case "CompanyName":
                            dr[1] = "Company Name";
                            break;
                        case "ContactFirstName":
                            dr[1] = "First Name";
                            break;
                        case "ContactLastName":
                            dr[1] = "Last Name";
                            break;
                        case "DOB":
                            dr[1] = "Date Of Birth";
                            break;
                        case "Gender":
                            dr[1] = "Gender";
                            break;
                        case "PhoneNo":
                            dr[1] = "Phone No";
                            break;
                        case "Email":
                            dr[1] = "Email";
                            break;
                        default:
                            break;
                    }

                    clientColRows = dtFieldNames;
                    // ClientCols.Add(dr);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured loading the search field names. " + ex.Message);

            }
        }

        private string selectedClientCols;
        public string SelectedClientCols
        {
            get { return selectedClientCols; }
            set
            {
                selectedClientCols = value;
            }
        }

        public RelayCommand Save
        {
            get { return new RelayCommand(SaveClient, true); }
        
            
                set {
                    updateRelay = value;
                    OnPropertyChanged("SaveClient");
                }
            
        }
        private void SaveClient()
        {
            if (String.IsNullOrEmpty(SelectedClient.FirstName))
            {
                MessageBox.Show("Please Enter First Name", "First Name Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedClient.LastName)

            )
            {
                MessageBox.Show("Please Enter Last Name", "Last Name Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedClient.MobileNumber))
            {
                MessageBox.Show("Please Enter Mobile Number", "Mobile Number Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedClient.CompanyName))
            {
                MessageBox.Show("Please Enter Company Name", "Company Name Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(String.IsNullOrEmpty(SelectedClient.Email))
            {
                MessageBox.Show("Please Enter Email", "Email Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedClient.DOB.ToString()))
            {
                MessageBox.Show("Please Enter Date of Birth", "DOB Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedClient.Gender.ToString()))
            {
                MessageBox.Show("Please Enter Gender", "Gender Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (!Regex.Match(SelectedClient.MobileNumber, "^0[0-9]{9}$").Success)
            {
                MessageBox.Show("Enter valid phone number.", "Phone Number",
                 MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (SelectedClient.ClientID == 0)
            {
                try
                {
                    SelectedClient.Insert();
                    MessageBox.Show("Thank you!  The new Client's details have been added to the Database.", "Add Client", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {

                    MessageBox.Show("Something Went Wrong, But we Dont know what! Client details was not added to the database");
                }
               
            }
            else
            {
                try
                {
                    SelectedClient.Update();
                    MessageBox.Show("The Client's details have been updated in the Database.", "Update Client?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
              
                         
                catch (Exception ex)
                {

                    MessageBox.Show("An Error Occured, The Client Details were not updated. Please Contact your System Administrator.", "Update Client?" + ex.Message);
                }
               
            }
            IsEnabledAddress = true;
            IsEnabledNewjob = true;

            IsEnabledAdd = true;
            IsEnabledSave = true;
            IsEnabledDelete = true;



        }
        public RelayCommand Search
        {
            get { return new RelayCommand(SearchClient, true); }


            set
            {
                searchRelay = value;
                OnPropertyChanged("SearchClient");
            }

        }
        private void SearchClient()
        { 
             DAL dal = new DAL();

            ClientCollection.Clear();

            DataTable dt = dal.Read("Select * from bit_client , bit_user_logon where bit_user_logon.account_Type='CLIENT' AND bit_user_logon.account_Ref= bit_client.client_Id and  (STATUS='ACTIVE' OR STATUS IS NULL) and " + SelectedClientCols + " like '%" + ClientSearchString +"%'");

            int i = 0;
            int index = 0;
            Client clientFirstRecord = new Client();

            foreach (DataRow dr in dt.Rows)
             {
                index = i;
                if (index == 0)
                {
                    clientFirstRecord = new Client(dr);
                }
                Client client = new Client(dr);
                 ClientCollection.Add(client);
                i++;
             }
            SelectedClient = clientFirstRecord;
           // MessageBox.Show(SelectedClientCols + ClientSearchString);

        }

        public RelayCommand Add
        {
            get { return new RelayCommand(AddClient, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("AddClient");
            }
        }
        private void AddClient()
        {
           // SelectedClient.Insert();

            Client client = new Client();
            ClientCollection.Add(client);
            SelectedClient = client;

            IsEnabledAddress = false;
            IsEnabledNewjob = false;

            IsEnabledAdd =false;
            IsEnabledSave = true;
            IsEnabledDelete = false;

            MessageBox.Show("Click Save button after entering the new Client details.", "Client", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public RelayCommand Delete
        {
            get { return new RelayCommand(DeleteClient, true); }
            set
            {
                deleteRelay = value;
                OnPropertyChanged("DeleteClient");
            }
        }
        private void DeleteClient()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to PERMANENTLY delete the Client's details?", "Delete Client?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SelectedClient.Delete();
                    ClientCollection.Remove(SelectedClient);
                    MessageBox.Show("Thank you!  The Client's details have been deleted!", "Delete Client?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An Error Occured, The Client Details have not been deleted. Please Contact your System Administrator.", "Delete Client?" + ex.Message);
            }
            
        }
    }
}
