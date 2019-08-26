using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitServices.Model;
using BitServices.Commands;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Text.RegularExpressions;

namespace BitServices.ViewModel
{
    class ContractorManagementViewModel : NotificationClass
    {
        // This class is the communication class between your view(ContractorManagmementPageView.Xaml) and to your Model(Contractor.cs)
        // Create a list that will generated from database
        private Contractor contractor;
        private RelayCommand addRelay;
        private RelayCommand updateRelay;
        private RelayCommand deleteRelay;
        private RelayCommand appendUserId;
        private RelayCommand searchRelay;
        private ObservableCollection<Contractor> contractorCollection = new ObservableCollection<Contractor>();

        private DataTable contractorColRows;

        private Boolean readOnlyContractor;

        public Boolean ReadOnlyContractor
        {
            get { return readOnlyContractor; }
            set
            {
                readOnlyContractor = value;
                OnPropertyChanged("ReadOnlyContractor");
            }
        }

        public DataTable ContractorColRows
        {
            get { return contractorColRows; }
            set
            {
                contractorColRows = value;
                OnPropertyChanged("ContractorColRows");
            }
        }

        private string contractorSearchString;
        public string ContractorSearchString
        {
            get { return contractorSearchString; }
            set
            {
                contractorSearchString = value;
                OnPropertyChanged("ContractorSearchString");
            }

        }

        private string selectedContractorCols;
        public string SelectedContractorCols
        {
            get { return selectedContractorCols; }
            set
            {
                selectedContractorCols = value;
            }
        }




        private Boolean isEnabledRoster;
        public Boolean IsEnabledRoster
        {
            get { return isEnabledRoster; }
            set
            {
                isEnabledRoster = value;
                OnPropertyChanged("IsEnabledRoster");
            }
        }

        private Boolean isEnabledSkill;
        public Boolean IsEnabledSkill
        {
            get { return isEnabledSkill; }
            set
            {
                isEnabledSkill = value;
                OnPropertyChanged("IsEnabledSkill");
            }
        }
        private Boolean isEnabledSuburb;
        public Boolean IsEnabledSuburb
        {
            get { return isEnabledSuburb; }
            set
            {
                isEnabledSuburb = value;
                OnPropertyChanged("IsEnabledSuburb");
            }
        }

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


        public ObservableCollection<Contractor> ContractorCollection
        {
            get { return contractorCollection; }
        }
        private string selectedContractorUserId;
        public string SelectedContractorUserId
        {
            get { return selectedContractorUserId; }
            set
            {
                selectedContractorUserId = value;
            }
        }
        private DataTable contractorUserIdRows;

        public DataTable ContractorUserIdRows
        {
            get { return contractorUserIdRows; }
            set
            {
                contractorUserIdRows = value;
                OnPropertyChanged("ContractorUserIdRows");
            }
        }

        public Contractor SelectedContractor
        {
            get { return contractor; }
            set
            {
                contractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }
        //Constructor of this viewModel
        public ContractorManagementViewModel()
        {
            //1. Its going to connect to DAL and bring in the results of all Contractors
            //2. We create objects of type contractor and then add that object to our collection
            DAL dal = new DAL();
            DataTable dt = dal.Read("Select * from bit_contractor, bit_user_logon where bit_user_logon.account_Type='CONTRACTOR' AND bit_user_logon.account_Ref= bit_contractor.contractor_Id and (STATUS='ACTIVE' OR STATUS IS NULL)");

            
            foreach (DataRow dr in dt.Rows)
            {
                
                Contractor contractor = new Contractor(dr);
                ContractorCollection.Add(contractor);
            }
            if (ContractorCollection.Count == 0)
            {
               // ReadOnlyContractor = Boolean.Parse("FALSE");
                Contractor contractor = new Contractor();
                ContractorCollection.Add(contractor);
                SelectedContractor = contractor;
            }
            else
            {
               // ReadOnlyContractor = Boolean.Parse("TRUE");
            }
            
            LoadFieldNameCombo();
            IsEnabledRoster = true;
            IsEnabledSkill = true;
            IsEnabledSuburb = true;
            IsEnabledAdd = true;
            IsEnabledSave = true;
            IsEnabledDelete = true;

        }
        private void LoadFieldNameCombo()
        {
            try
            {
                DAL dal = new DAL();

                DataTable dtFieldNames = dal.Read("SELECT COLUMN_NAME FROM information_schema.columns WHERE table_schema='bit' AND table_name='bit_contractor'and column_name not in ('Creation_Date', 'Created_By', 'Updated_By', 'Updated_Date', 'STATUS','Start_Date','End_Date','vehicleNo','LicenceNo','Skill_Id')");


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
                        case "Contractor_Id":
                            dr[1] = "Contractor Id";
                            break;
                        case "User_Id":
                            dr[1] = "User Name";
                            break;
                        case "FirstName":
                            dr[1] = "First Name";
                            break;
                        case "LastName":
                            dr[1] = "Last Name";
                            break;
                        case "DOB":
                            dr[1] = "Date Of Birth";
                            break;
                        case "Gender":
                            dr[1] = "Gender";
                            break;
                        case "StreetAddress":
                            dr[1] = "Street";
                            break;
                        case "Suburb":
                            dr[1] = "Suburb";
                            break;
                        case "State":
                            dr[1] = "State";
                            break;
                        case "PostCode":
                            dr[1] = "Post Code";
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

                    contractorColRows = dtFieldNames;
                    // ClientCols.Add(dr);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured loading the search field names. " + ex.Message);

            }
        }
        public RelayCommand Save
        {
            get { return new RelayCommand(SaveContractor, true); }
            set
            {
                updateRelay = value;
                OnPropertyChanged("SaveContractor");
            }

        }
        private void SaveContractor()

        {
            if (String.IsNullOrEmpty(SelectedContractor.FirstName) )
            {
                MessageBox.Show("Please Enter First Name","First Name Required",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedContractor.LastName) 
              
              )
            {
                MessageBox.Show("Please Enter Last Name", "Last Name Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedContractor.MobileNumber) )
            {
                MessageBox.Show("Please Enter Mobile Number", "Mobile Number Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedContractor.State))
            {
                MessageBox.Show("Please Enter State", "State Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedContractor.Suburb))
            {
                MessageBox.Show("Please Enter Suburb", "Suburb Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedContractor.PostCode))
            {
                MessageBox.Show("Please Enter Postcode", "Postcode Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Regex.Match(SelectedContractor.LastName, "^[a-zA-Z\\s\\,]*$").Success || String.IsNullOrEmpty(SelectedContractor.LastName))
            {
                MessageBox.Show("Not a valid Last Name");

                return;
            }
            if (!Regex.Match(SelectedContractor.FirstName, "^[a-zA-Z\\s\\,]*$").Success || String.IsNullOrEmpty(SelectedContractor.LastName))
            {
                MessageBox.Show("Not a valid First Name");

                return;
            }
            if (!Regex.Match(SelectedContractor.MobileNumber, "^04[0-9]{8}$").Success)
            {
                MessageBox.Show("Enter valid phone number.", "Phone Number",
               MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            if (!Regex.Match(SelectedContractor.State, "[a-zA-Z]{2,3}$").Success)
            {
                MessageBox.Show("State not in the correct format!");
                return;
            }
            if (!Regex.Match(SelectedContractor.Suburb, "^[a-zA-Z\\s\\,]*$").Success)
            {
                MessageBox.Show("Please enter valid Suburb Name");
                return;
            }
            if (!Regex.Match(SelectedContractor.PostCode, "^[2-7]{1}[0-9]{3}$").Success)
            {
                MessageBox.Show("Please enter valid Postcode");
                return;
            }
            //MessageBox.Show(SelectedContractor.FirstName + " " + SelectedContractor.LastName + " " + SelectedContractor.DOB + " " + SelectedContractor.Gender + " " + SelectedContractor.Street + " " + SelectedContractor.State + " " + SelectedContractor.PostCode + " " + SelectedContractor.Suburb + " " + SelectedContractor.MobileNumber + " " + SelectedContractor.Email + " ");
            if (SelectedContractor.ContractorID == 0)
            {
             
                try
                {
                    SelectedContractor.Insert();
                    MessageBox.Show("Thank you!  The new Contractor's details have been added to the Database.", "Add Contractor", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Something went wrong" + ex.Message);
                }
                
            }
            else
            {
                try
                {
                    SelectedContractor.Update();
                    MessageBox.Show("The Contractor's details have been updated in the Database.", "Update Contractor?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An Error Occured, The Contractor Details were not updated. Please Contact your System Administrator.", "Update Contractor?" + ex.Message);
                }

               
            }
            IsEnabledRoster = true;
            IsEnabledSkill = true;
            IsEnabledSuburb = true;
            IsEnabledAdd = true;
            IsEnabledSave = true;
            IsEnabledDelete = true;
        }
    
       
        public RelayCommand Add
        {
            get { return new RelayCommand(AddContractor, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("AddContractor");
            }
        }
        private void AddContractor()
        {



            if (!Regex.Match(SelectedContractor.MobileNumber, "^0[0-9]{9}$").Success)
            {
                MessageBox.Show("Enter valid phone number.", "Phone Number",
               MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            // SelectedContractor.Insert();
            Contractor contractor = new Contractor();
            ContractorCollection.Add(contractor);
            SelectedContractor = contractor;
            IsEnabledRoster = false;
            IsEnabledSkill = false;
            IsEnabledSuburb = false;
            IsEnabledAdd = false;
            IsEnabledSave = true;
            IsEnabledDelete = false;
            MessageBox.Show("Click Save button after entering the new Contractor details.", "Add Contractor", MessageBoxButton.OK, MessageBoxImage.Warning);
           
        }
        public RelayCommand Delete
        {
            get { return new RelayCommand(DeleteContractor, true); }
            set
            {
                deleteRelay = value;
                OnPropertyChanged("DeleteContractor");
            }
        }
        private void DeleteContractor()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to PERMANENTLY delete the Contractor's details?", "Delete Contractor?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SelectedContractor.Delete();
                    ContractorCollection.Remove(SelectedContractor);
                    MessageBox.Show("Thank you!  The Contractor's details have been deleted!", "Delete Contractor?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An Error Occured, The Contractor Details have not been deleted. Please Contact your System Administrator.", "Delete Contractor?" + ex.Message);
            }
           

        }
        public RelayCommand Search
        {
            get { return new RelayCommand(SearchContractor, true); }
            set
            {
                searchRelay = value;
                OnPropertyChanged("SearchContractor");
            }
        }
        private void SearchContractor()
        {
            DAL dal = new DAL();


            ContractorCollection.Clear();

            if (SelectedContractorCols.Equals("User_Id"))
            {
                //ContractorSearchString = "CN" + ContractorSearchString;
                SelectedContractorCols = "bit_user_logon.userName";

            }

            DataTable dt = dal.Read("Select bit_contractor.*,bit_user_logon.userName from bit_contractor , bit_user_logon where bit_user_logon.account_Type='CONTRACTOR' AND bit_user_logon.account_Ref= bit_contractor.contractor_Id and  (STATUS='ACTIVE' OR STATUS IS NULL) and " + SelectedContractorCols + " like '%" + ContractorSearchString + "%'");

            int i = 0;
            int index = 0;
            Contractor contractorFirstRecord = new Contractor();

            foreach (DataRow dr in dt.Rows)
            {
                index = i;
                if (index == 0)
                {
                    contractorFirstRecord = new Contractor(dr);
                }
                Contractor contractor = new Contractor(dr);
                ContractorCollection.Add(contractor);
                i++;
            }
            if (ContractorCollection.Count == 0)
            {
               // ReadOnlyContractor = Boolean.Parse("FALSE");
                Contractor contractor = new Contractor();
                ContractorCollection.Add(contractor);
                SelectedContractor = contractor;
            }
            else
            {
               // ReadOnlyContractor = Boolean.Parse("TRUE");
            }
            SelectedContractor = contractorFirstRecord;
            // MessageBox.Show(SelectedClientCols + ClientSearchString);

        }

    }
}
