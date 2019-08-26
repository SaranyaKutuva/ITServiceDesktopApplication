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

namespace BitServices.ViewModel
{
    class ClientAddManagementViewModel : NotificationClass
    {
        // This class is the communication class between your view(ClientsManagementPageView.Xaml) and to your Model (Client.cs)
        // Create a list that will generated from Database
        private ClientAdd clientadd;
        //   private Person person;
        private RelayCommand addRelay;
        private RelayCommand updateRelay;
        private RelayCommand deleteRelay;
        private ObservableCollection<ClientAdd> clientaddCollection = new ObservableCollection<ClientAdd>();

        public ObservableCollection<ClientAdd> ClientAddCollection
        {
            get { return clientaddCollection; }
            set {
                clientaddCollection = value;
                OnPropertyChanged("ClientAddCollection");
            }
        }

        private int passedclientId;
        public int PassedClientId
        {
            get { return passedclientId; }
            set
            {
                passedclientId = value;
                 OnPropertyChanged("PassedClientId"); 
            }

        }
       
        public ClientAdd SelectedClientAdd
        {
            get { return clientadd; }
            set
            {

               // MessageBox.Show("set selected Client Address request");
                clientadd = value;
                OnPropertyChanged("SelectedClientAdd");
            }
        }

        public ClientAddManagementViewModel(string ClientId)
        {
            //1. Its going to connect to DAL and bring in the results of all Instructors
            //2. we Create objects of type instructor and then add that object to our collection
            DAL dal = new DAL();
            DataTable dt = dal.Read("Select * from bit_client_location  where Client_Id=" + ClientId);

            PassedClientId = Convert.ToInt32(ClientId);

           // clientadd.UserID = UserId;
            foreach (DataRow dr in dt.Rows)
            {
                ClientAdd client = new ClientAdd(dr);
                ClientAddCollection.Add(client);
            }
        }
        public RelayCommand Save
        {
            get { return new RelayCommand(SaveClientAdd, true); }
        
            
                set {
                    updateRelay = value;
                    OnPropertyChanged("SaveClientAdd");
                }
            
        }
        private void SaveClientAdd()
        {
            if (SelectedClientAdd.ClientID == 0)
            {
                SelectedClientAdd.InsertAddress(PassedClientId);
            }
            else
            {
                SelectedClientAdd.UpdateAddress();
            }
            // System.Windows.MessageBox.Show("Update Address");
            //if (SelectedClientAdd.ClientID == 0)
            //{
            //    try
            //    {
            //        SelectedClientAdd.InsertAddress(PassedClientId);
            //        MessageBox.Show("Thank you!  The new Client's Location details have been added to the Database.", "Add Client Location", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    catch (Exception)
            //    {

            //        MessageBox.Show("Something Went Wrong, But we Dont know what! Client Location details was not added to the database");
            //    }
               
            //}
            //else
            //{
            //    try
            //    {
            //        SelectedClientAdd.UpdateAddress();
            //        MessageBox.Show("The Client's Location details have been updated in the Database.", "Update Client Location?", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("An Error Occured, The Client Location Details were not updated. Please Contact your System Administrator.", "Update Client Location?" + ex.Message);
            //    }
               
            //}
        }
        public RelayCommand Add
        {
            get { return new RelayCommand(AddClientAdd, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("AddClientAdd");
            }
        }
        private void AddClientAdd()
        {
            ClientAdd client = new ClientAdd();
            ClientAddCollection.Add(client);
            SelectedClientAdd = client;
            MessageBox.Show("Click Save button after entering the new Client Address details.", "Client Location", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
        public RelayCommand Delete
        {
            get { return new RelayCommand(DeleteClientAdd, true); }
            set
            {
                deleteRelay = value;
                OnPropertyChanged("DeleteClientAdd");
            }
        }
        private void DeleteClientAdd()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to PERMANENTLY delete the Client's Location details?", "Delete Client Location?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SelectedClientAdd.DeleteAddress();
                    ClientAddCollection.Remove(SelectedClientAdd);
                    MessageBox.Show("Thank you!  The Client's Location details have been deleted!", "Delete Client Location?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    return;
                }
            
            }
            catch (Exception ex)
            {

                MessageBox.Show("An Error Occured, The Client Location Details have not been deleted. Please Contact your System Administrator.", "Delete Client Location?" + ex.Message);
            }
                        
        }
    }
}
