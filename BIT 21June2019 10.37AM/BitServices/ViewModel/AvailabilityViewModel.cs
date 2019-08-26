using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices.Model;
using BitServices.View;
using BitServices.Commands;
using System.Windows;

namespace BitServices.ViewModel
{
    class AvailabilityViewModel : NotificationClass
    {
       public Availability availability;
        private RelayCommand addRelay;
       // private RelayCommand updateRelay;
      //  private RelayCommand deleteRelay;
        private ObservableCollection<Availability> availCollection = new ObservableCollection<Availability>();
        public AvailabilityViewModel(string ContractorId)
        {
          //  MessageBox.Show(ContractorId);
                
            DAL dal = new DAL();
            DataTable dt = dal.Read("Select * from bit_contractor_availability where Contractor_Id = " + ContractorId);
            PassedContractorId = Convert.ToInt32(ContractorId);
            foreach (DataRow dr in dt.Rows)
            {
                Availability availability = new Availability(dr);
                AvailCollection.Add(availability);
            }
            
        }



        // private ObservableCollection<DataRow> clientcols = new ObservableCollection<DataRow>();



        public ObservableCollection<Availability> AvailCollection
        {
            get { return availCollection; }
            set
            {
                availCollection = value;
                OnPropertyChanged("AvailCollection");
            }
        }
        public Availability SelectedAvailability
        {
            get { return availability; }
            set
            {
                availability = value;
                OnPropertyChanged("SelectedAvailability");
            }
        }
        //public Availability NewAvailabilty
        //{
        //    get { return availability; }
        //    set
        //    {
        //        availability = value;
        //        OnPropertyChanged("NewAvailability");
        //    }
        //}
        //private void SaveClientAdd()
        //{
        //    // System.Windows.MessageBox.Show("Update Address");
        //    if (SelectedClientAdd.ClientID == 0)
        //    {
        //        SelectedClientAdd.InsertAddress(PassedClientId);
        //    }
        //    else
        //    {
        //        SelectedClientAdd.UpdateAddress();
        //    }
        //}
        private int passedContractorId;
        public int PassedContractorId
        {
            get { return passedContractorId; }
            set
            {
                passedContractorId = value;
                OnPropertyChanged("PassedContractorId");
            }

        }

        public RelayCommand Save
        {
            
            get { return new RelayCommand(SaveAvailability, true); }
        }

        private void SaveAvailability()
        {

            if (SelectedAvailability.AvailID == 0)
            {
                if (!(SelectedAvailability.Monday || SelectedAvailability.Tuesday || SelectedAvailability.Wednesday || SelectedAvailability.Thursday ||
                 SelectedAvailability.Friday || SelectedAvailability.Saturday || SelectedAvailability.Sunday))
                {
                    MessageBox.Show("Atleast one day must be selected!", "Select Date Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    int rowcount = SelectedAvailability.insert(PassedContractorId);
                    if (rowcount == -100)
                    {
                        MessageBox.Show("Start Date and End Date overlaps with existing availiability!", "Date Overlap Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Thank you!  The new Availability details have been added to the Database.", "Add Contractor Availability", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                catch (Exception)
                {

                    MessageBox.Show("Something Went Wrong, But we Dont know what! Contractor Availability details was not added to the database");
                }
            }
            else
            {

                if (!(SelectedAvailability.Monday || SelectedAvailability.Tuesday || SelectedAvailability.Wednesday || SelectedAvailability.Thursday ||
                SelectedAvailability.Friday || SelectedAvailability.Saturday || SelectedAvailability.Sunday))
                {
                    MessageBox.Show("Atleast one day must be selected!", "Select Date Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                try
                {
                    int rowcount = SelectedAvailability.update(PassedContractorId);
                  
                    MessageBox.Show("Thank you!  The new Availability details have been updated to the Database.", "Update Contractor Availability", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                catch (Exception)
                {

                    MessageBox.Show("Something Went Wrong, But we Dont know what! Contractor Availability details was not updated to the database");
                }

            }
        }
        public RelayCommand Add
        {
            get { return new RelayCommand(AddAvailability, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("AddAvailability");
            }
        }

        private void AddAvailability()
        {
         
            Availability availability = new Availability();
            AvailCollection.Add(availability);
            SelectedAvailability = availability;
            MessageBox.Show("Click Save button after entering the Contractor Availability details.", "Add Contractor Availability", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}


