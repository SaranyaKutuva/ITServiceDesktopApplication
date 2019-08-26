using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace BitServices.Model
{
    class Employee : Person
    {
      //  private Employee employee;
      //  private int employeeID;
        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value;
                OnPropertyChanged("EmployeeID");
            }
        }
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value;
                OnPropertyChanged("UserID");

            }
        }

       






        private string employeeType;

        public string EmployeeType
        {
            get { return employeeType; }
            set
            {
                employeeType = value;
                OnPropertyChanged("EmployeeType");
            }
        }


        public Employee()
        {

        }
        public Employee(DataRow drEmployee)
        {
            MapEmployeeProperties(drEmployee);
        }

        private void MapEmployeeProperties(DataRow drEmployee)
        {
            this.userID =       Convert.ToInt32(drEmployee["user_Id"]);
            this.UserName =     drEmployee["UserName"].ToString();
            this.employeeID =   Convert.ToInt32(drEmployee["employee_Id"].ToString());
            this.employeeType = drEmployee["Employee_Type"].ToString();
            this.FirstName =    drEmployee["FirstName"].ToString();
            this.LastName =     drEmployee["LastName"].ToString();
            this.DOB =          Convert.ToDateTime(drEmployee["DOB"]);
            this.Gender =       drEmployee["Gender"].ToString();
            this.Street =       drEmployee["StreetAddress"].ToString();
            this.Suburb =       drEmployee["Suburb"].ToString();
            this.State =        drEmployee["State"].ToString();
            this.PostCode =     drEmployee["PostCode"].ToString();
            this.Email =        drEmployee["Email"].ToString();
            this.MobileNumber = drEmployee["PhoneNo"].ToString();
        }
        #region WithoutStoreProc
        //public void Update()
        //{
        //    try
        //    {
        //        DAL dal = new DAL();
        //        dal.Update("update bit_employee set FirstName = '" + this.FirstName + "', LastName= '" + this.LastName + "', StreetAddress = '" + this.Street + "', Suburb= '" + this.Suburb + "',State = '" + this.State + "', PostCode = '" + this.PostCode + "',  Email = '" + this.Email + "',  PhoneNo = '" + this.MobileNumber + "' where Employee_Id =" + this.EmployeeID);
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Something Went Wrong" + ex.Message);
        //    }

        //}
        //public void Insert()
        //{
        //    DAL dal = new DAL();


        //    dal.Insert("insert into bit_employee(FirstName,LastName,StreetAddress,Suburb,State,PostCode,Email,PhoneNo) values ('" + this.FirstName + "','" + this.LastName + "','" + this.Street + "','" + this.Suburb + "','" + this.State + "','" + this.PostCode + "','" + this.Email + "','" + this.MobileNumber + "')");
        //}
        //public void Delete()
        //{
        //    DAL dal = new DAL();
        //    dal.Delete("delete from bit_employee where employee_Id = " + this.EmployeeID);
        //}

        #endregion WithoutStoreProc


        public int Update()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteEmployee";
               // MessageBox.Show(this.DOB.ToString());
                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Employee_Id1",this.EmployeeID),
                    new MySqlParameter("@Employee_Type1",this.EmployeeType),
                    new MySqlParameter("@User_Id1",  this.UserID),
                    new MySqlParameter("@FirstName1",this.FirstName),
                    new MySqlParameter("@LastName1",this.LastName),
                    new MySqlParameter("@DOB1",this.DOB),
                    new MySqlParameter("@Gender1",this.Gender),
                    new MySqlParameter("@PostCode1",this.PostCode),
                    new MySqlParameter("@State1",this.State),
                    new MySqlParameter("@StreetAddress1",this.Street),
                    new MySqlParameter("@Suburb1",this.Suburb),
                    new MySqlParameter("@PhoneNo1",this.MobileNumber),
                    new MySqlParameter("@Email1",this.Email),
                    new MySqlParameter("@Start_Date1",""),
                    new MySqlParameter("@End_Date1",""),
                    new MySqlParameter("@Created_By1",""),
                    new MySqlParameter("@Creation_Date1",""),
                    new MySqlParameter("@Updated_By1",""),
                    new MySqlParameter("@Updated_Date1",""),
                    new MySqlParameter("@STATUS1",this.Status),
                    new MySqlParameter("@Mode","UPDATE"),
                };
                DAL dal = new DAL();
                int rowsAffected = dal.InsertUpdateDeleteSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Employee with employee '" + this.FirstName + "' Could not be Updated in the database");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Employee Could not be Updated!!", ex);
                //return 0;
            }
           
        }
        public int Insert()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteEmployee";

                MySqlParameter[] parameters =
                    {
                    // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                     new MySqlParameter("@Employee_Id1",this.EmployeeID),
                    new MySqlParameter("@Employee_Type1",this.EmployeeType),
                    new MySqlParameter("@User_Id1",  this.UserID),
                    new MySqlParameter("@FirstName1",this.FirstName),
                    new MySqlParameter("@LastName1",this.LastName),
                    new MySqlParameter("@DOB1",this.DOB),
                    new MySqlParameter("@Gender1",this.Gender),
                    new MySqlParameter("@PostCode1",this.PostCode),
                    new MySqlParameter("@State1",this.State),
                    new MySqlParameter("@StreetAddress1",this.Street),
                    new MySqlParameter("@Suburb1",this.Suburb),
                    new MySqlParameter("@PhoneNo1",this.MobileNumber),
                    new MySqlParameter("@Email1",this.Email),
                    new MySqlParameter("@Start_Date1",""),
                    new MySqlParameter("@End_Date1",""),
                    new MySqlParameter("@Created_By1",""),
                    new MySqlParameter("@Creation_Date1",""),
                    new MySqlParameter("@Updated_By1",""),
                    new MySqlParameter("@Updated_Date1",""),
                    new MySqlParameter("@STATUS1","ACTIVE"),
                    new MySqlParameter("@Mode","INSERT"),
                };
                DAL dal = new DAL();
                int rowsAffected =   dal.InsertUpdateDeleteSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Employee with employee '" + this.FirstName + "' could not be Added in the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                throw new Exception("Client Could not be Added!!", ex);
               // return 0;
            }

            

            /*DAL dal = new DAL();

           
            dal.Insert("insert into bit_client,bit_client_location(ContactFirstName,ContactLastName,StreetAddress,Suburb,State,PostCode,Email,PhoneNo,CompanyName) values ('" + this.FirstName+ "','" + this.LastName + "','" + this.Street+ "','" + this.Suburb + "','" + this.State + "','" + this.PostCode + "','" + this.Email + "','" + this.MobileNumber + "','" + this.CompanyName + "')");*/
        }
        public int Delete()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteEmployee";

                MySqlParameter[] parameters =
                    {
                    // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                     new MySqlParameter("@Employee_Id1",this.EmployeeID),
                    new MySqlParameter("@Employee_Type1",this.EmployeeType),
                    new MySqlParameter("@User_Id1",this.UserID),
                    new MySqlParameter("@FirstName1",this.FirstName),
                    new MySqlParameter("@LastName1",this.LastName),
                    new MySqlParameter("@DOB1",this.DOB),
                    new MySqlParameter("@Gender1",this.Gender),
                    new MySqlParameter("@PostCode1",this.PostCode),
                    new MySqlParameter("@State1",this.State),
                    new MySqlParameter("@StreetAddress1",this.Street),
                    new MySqlParameter("@Suburb1",this.Suburb),
                    new MySqlParameter("@PhoneNo1",this.MobileNumber),
                    new MySqlParameter("@Email1",this.Email),
                    new MySqlParameter("@Start_Date1",""),
                    new MySqlParameter("@End_Date1",""),
                    new MySqlParameter("@Created_By1",""),
                    new MySqlParameter("@Creation_Date1",""),
                    new MySqlParameter("@Updated_By1",""),
                    new MySqlParameter("@Updated_Date1",""),
                    new MySqlParameter("@STATUS1",this.Status),
                    new MySqlParameter("@Mode","DELETE"),
                };
                DAL dal = new DAL();
                int rowsAffected = dal.InsertUpdateDeleteSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Employee with employee '" + this.FirstName + "' could not be Deleted from the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Employee Could not be Deleted!!", ex);
               // return 0;
            }
           
        }
    }
}
