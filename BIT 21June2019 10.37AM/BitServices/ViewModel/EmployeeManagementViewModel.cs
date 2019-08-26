using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using BitServices.Commands;
using BitServices.Model;

namespace BitServices.ViewModel
{
    class EmployeeManagementViewModel : NotificationClass
    {
        // This class is the communication class between your view(ContractorManagmementPageView.Xaml) and to your Model(Contractor.cs)
        // Create a list that will generated from database
        public DataTable employeeUserIdRows;
        private Employee employee;
        private RelayCommand addRelay;
        private RelayCommand updateRelay;
        private RelayCommand deleteRelay;
        private RelayCommand searchEmp;
        private RelayCommand searchRelay;
    //    private RelayCommand appendUserId;
     //   private string appendUserIdToCollection;

        private ObservableCollection<Employee> employeeCollection = new ObservableCollection<Employee>();
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



        public ObservableCollection<Employee> EmployeeCollection
        {
            get { return employeeCollection; }
        }
        private string selectedEmployeeUserId;
        private string selectedEmployeeCols;
        public string SelectedEmployeeCols
        {
            get { return selectedEmployeeCols; }
            set
            {
                selectedEmployeeCols = value;
            }
        }
        public string SelectedEmployeeUserId
        {
            get { return selectedEmployeeUserId; }
            set
            {
                selectedEmployeeUserId = value;
            }
        }
 
        private DataTable employeeColRows;
        public DataTable EmployeeColRows
        {
            get { return employeeColRows; }
            set
            {
                employeeColRows = value;
                OnPropertyChanged("EmployeeColRows");
            }
        }
        public DataTable EmployeeUserIdRows
        {
            get { return employeeUserIdRows; }
            set
            {
                employeeUserIdRows = value;
                OnPropertyChanged("EmployeeUserIdRows");
            }
        }
        private void LoadFieldNameCombo()
        {
            try
            {
                DAL dal = new DAL();

                DataTable dtFieldNames = dal.Read("SELECT COLUMN_NAME FROM information_schema.columns WHERE table_schema='bit' AND table_name='bit_employee'and column_name not in ('Creation_Date', 'Created_By', 'Updated_By', 'Updated_Date', 'STATUS','Start_Date','End_Date')");


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
                        case "Employee_Id":
                            dr[1] = "Employee Id";
                            break;
                        case "User_Id":
                            dr[1] = "User Id";
                            break;
                        case "Employee_Type":
                            dr[1] = "Employee Type";
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
                        case "PostCode":
                            dr[1] = "Post Code";
                            break;
                        case "State":
                            dr[1] = "State";
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

                
                    // ClientCols.Add(dr);

                }
                //System.Windows.MessageBox.Show(dtFieldNames.Rows.Count.ToString());
                employeeColRows = dtFieldNames;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("An error occured loading the search field names. " + ex.Message);

            }
        }

        public Employee SelectedEmployee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        
        //Constructor of this viewModel
        public EmployeeManagementViewModel()
        {
            //1. Its going to connect to DAL and bring in the results of all Contractors
            //2. We create objects of type contractor and then add that object to our collection
            DAL dal = new DAL();
            DataTable dt = dal.Read("Select * from bit_employee, bit_user_logon where bit_user_logon.account_Type in ('Admin','Coordinator') AND bit_user_logon.account_Ref= bit_employee.employee_id and (STATUS='ACTIVE' OR STATUS IS NULL)");
            foreach (DataRow dr in dt.Rows)
            {
                Employee employee = new Employee(dr);
                EmployeeCollection.Add(employee);
            }
            //  DAL dal = new DAL();

            /* User ID logic */

            //String appendUserId ="";
            //if (dt.Rows.Count > 0)
            //{
            //    DataRow row = dt.Rows[0];
            //    appendUserId = row["user_Id"].ToString();
            //   // System.Windows.MessageBox.Show(row["user_Id"].ToString());
            //}
            //    //System.Windows.MessageBox.Show(EmployeeCollection.);

            //DataTable dtFieldNames = dal.Read("Select user_Id,user_name from bit_user_logon where user_Id="+SelectedEmployee.UserID   );
            ////  dtFieldNames.NewRow(row["user_Id"].ToString());

            //DataRow dtFieldNames1;
            //dtFieldNames1 = dtFieldNames.NewRow();
            //dtFieldNames1["user_Id"] = appendUserId;
            //dtFieldNames.Rows.InsertAt(dtFieldNames1, 0);

            //EmployeeUserIdRows = dtFieldNames;

            ///* End of User ID logic */
            LoadFieldNameCombo();
            IsEnabledSave = true;
            IsEnabledAdd = true;
            IsEnabledDelete = true;
        }
        private string employeeSearchString;
        public string EmployeeSearchString
        {
            get { return employeeSearchString; }
            set
            {
                employeeSearchString = value;
                OnPropertyChanged("EmployeeSearchString");
            }

        }
        //public RelayCommand AppendUserId
        //{
        //    get { return new RelayCommand(AppendUserIdToCollection, true); }
        //    set
        //    {
        //        appendUserId = value;
        //        OnPropertyChanged("AppendUserIdToCollection");
        //    }

        //}
        //private void AppendUserIdToCollection()
        //{
            
        //    try
        //    {
        //        String appendUserId = SelectedEmployee.UserID.ToString();
        //        DAL dal = new DAL();
        //        EmployeeUserIdRows.Clear();
        //        DataTable dtFieldNames = dal.Read("Select user_Id from bit_user_logon where user_id not in (select user_Id from bit_employee   UNION select user_Id from bit_client    UNION select user_Id from bit_contractor  )");

        //        SelectedEmployeeUserId = appendUserId;
        //        DataRow dtFieldNames1;
        //        dtFieldNames1 = dtFieldNames.NewRow();
        //        dtFieldNames1["user_Id"] = appendUserId;
        //        dtFieldNames.Rows.InsertAt(dtFieldNames1, 0);

        //        EmployeeUserIdRows = dtFieldNames;
        //    }
        //    catch(Exception e)
        //    {

        //    }
        //    /* End of User ID logic */

        //    //System.Windows.MessageBox.Show(SelectedEmployee.UserID.ToString());
        //}


        public RelayCommand Search
        {
            get { return new RelayCommand(SearchEmployee, true); }
            set
            {
                searchRelay = value;
                OnPropertyChanged("SearchEmployee");
            }

        }
        private void SearchEmployee()
        {
            DAL dal = new DAL();
            EmployeeCollection.Clear();
            DataTable dt = dal.Read("Select * from bit_employee , bit_user_logon where bit_user_logon.account_Type='EMPLOYEE' AND bit_user_logon.account_Ref= bit_employee.employee_id and (STATUS='ACTIVE' OR STATUS IS NULL) and " + SelectedEmployeeCols + " like '%" + EmployeeSearchString + "%'");

            int i = 0;
            int index = 0;
            Employee employeeFirstRecord = new Employee();
            foreach (DataRow dr in dt.Rows)
            {
                index = i;
                if (index == 0)
                {
                    employeeFirstRecord = new Employee(dr);
                }
                Employee employee = new Employee(dr);
                EmployeeCollection.Add(employee);
                i++;
            }
           SelectedEmployee = employeeFirstRecord;
            
           // System.Windows.MessageBox.Show(EmployeeCollection.Count.ToString());

            // MessageBox.Show(SelectedClientCols + ClientSearchString);

        }

        public RelayCommand Save
        {
            get { return new RelayCommand(SaveEmployee, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("SaveEmployee");
            }
        }
        private void SaveEmployee()
        {


            if (String.IsNullOrEmpty(SelectedEmployee.FirstName))
            {
                MessageBox.Show("Please Enter First Name", "First Name Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedEmployee.LastName)

              )
            {
                MessageBox.Show("Please Enter Last Name", "Last Name Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedEmployee.MobileNumber))
            {
                MessageBox.Show("Please Enter Mobile Number", "Mobile Number Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedEmployee.State))
            {
                MessageBox.Show("Please Enter State", "State Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedEmployee.Suburb))
            {
                MessageBox.Show("Please Enter Suburb", "Suburb Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedEmployee.PostCode))
            {
                MessageBox.Show("Please Enter Postcode", "Postcode Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedEmployee.Gender))
            {
                MessageBox.Show("Please Enter Gender", "Gender Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrEmpty(SelectedEmployee.EmployeeType))
            {
                MessageBox.Show("Please Enter Employee Type", "Employee Type Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedEmployee.Street))
            {
                MessageBox.Show("Please Enter Street", "Street Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(SelectedEmployee.Email))
            {
                MessageBox.Show("Please Enter Email", "Email Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Regex.Match(SelectedEmployee.LastName, "^[a-zA-Z\\s\\,]*$").Success || String.IsNullOrEmpty(SelectedEmployee.LastName))
            {
                MessageBox.Show("Not a valid Last Name");

                return;
            }
            if (!Regex.Match(SelectedEmployee.FirstName, "^[a-zA-Z\\s\\,]*$").Success || String.IsNullOrEmpty(SelectedEmployee.LastName))
            {
                MessageBox.Show("Not a valid First Name");

                return;
            }


            if (!Regex.Match(SelectedEmployee.MobileNumber, "^0[0-9]{9}$").Success)
            {
                MessageBox.Show("Enter valid phone number.", "Phone Number",
               MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            SelectedEmployee.UserID = Convert.ToInt32(SelectedEmployeeUserId);

            if (SelectedEmployee.EmployeeID == 0)
            {
                try
                {
                    SelectedEmployee.Insert();
                    MessageBox.Show("Thank you!  The new Employee's details have been added to the Database.", "Add Employee", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {

                    MessageBox.Show("Something Went Wrong, But we Dont know what! Employee details was not added to the database");
                }
               

            }
            else
            {
                try
                {
                    SelectedEmployee.Update();
                    MessageBox.Show("The employee's details have been updated in the Database.", "Update Employee?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An Error Occured, The Employee Details were not updated. Please Contact your System Administrator.", "Update Employee?" + ex.Message);
                }
               
            }
            IsEnabledSave = true;
            IsEnabledAdd = true;
            IsEnabledDelete = true;
        }

        public RelayCommand Add
        {
            get { return new RelayCommand(AddEmployee, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("AddEmployee");
            }
        }
        private void AddEmployee()
        {
            Employee employee = new Employee();
            EmployeeCollection.Add(employee);
            SelectedEmployee = employee;
            IsEnabledSave = true;
            IsEnabledAdd =false;
            IsEnabledDelete = false;
            MessageBox.Show("Click Save button after entering the new Employee details.", "Add Employee", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public RelayCommand Delete
        {
            get { return new RelayCommand(DeleteEmployee, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("DeleteEmployee");
            }
        }
        private void DeleteEmployee()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to PERMANENTLY delete the Employee details?", "Delete Employee?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SelectedEmployee.Delete();
                    EmployeeCollection.Remove(SelectedEmployee);
                    MessageBox.Show("Thank you!  The Employee's details have been deleted!", "Delete Employee?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An Error Occured, The Employee Details have not been deleted. Please Contact your System Administrator.", "Delete Employee?" + ex.Message);
            }
            
        }
    }
}
