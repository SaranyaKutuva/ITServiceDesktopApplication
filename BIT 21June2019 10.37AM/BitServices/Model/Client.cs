using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitServices.Commands;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows;

namespace BitServices.Model
{
    class Client : Person
    {
        private int clientID;

        private int locationID;
       // private int userID;


        private string locationName;


        public int ClientID
        {
            get => clientID;
            set
            {
                clientID = value;
                OnPropertyChanged("ClientID");
            }

        }
        private int userID;
        public int UserID
        {
            get => userID;
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }

        }


        public int LocationID
        {
            get { return locationID; }
            set { locationID = value;
                OnPropertyChanged("LocationID");

            }
        }

        private string companyName;
        public string CompanyName

        {
            get { return  companyName; }
            set { companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public string LocationName

        {
            get { return locationName; }
            set
            {
                locationName = value;
                OnPropertyChanged("LocationName");
            }
        }


        public Client() : base()
        {

        }
        public Client(DataRow drClient) : base()
        {
            MapClientProperties(drClient);
        }



        private void MapClientProperties(DataRow drClient)
        {
            App.Current.Properties["LoginUserId"] = "1";
            this.clientID = Convert.ToInt32(drClient["Client_Id"].ToString());
             this.UserName = drClient["UserName"].ToString();
            this.companyName = drClient["CompanyName"].ToString();
          /*  if (!(drClient["Location_Id"].ToString().Equals(""))) {
                this.locationID = Convert.ToInt32(drClient["Location_Id"].ToString());
            }
            if (!(drClient["Location_Name"].ToString().Equals("")))
            {
                this.locationName = drClient["Location_Name"].ToString();
            }*/
            this.FirstName = drClient["ContactFirstName"].ToString();
            this.LastName = drClient["ContactLastName"].ToString();
            if (!(drClient["Gender"].ToString().Equals(""))) { 
                this.Gender = drClient["Gender"].ToString();
             }
            if (!(drClient["DOB"].ToString().Equals("")))
            {
                this.DOB = Convert.ToDateTime(drClient["DOB"].ToString());
            }
            /*this.Street = drClient["StreetAddress"].ToString();
            this.Suburb = drClient["Suburb"].ToString();
            this.State = drClient["State"].ToString();
            this.PostCode = drClient["PostCode"].ToString();*/
            if (!(drClient["Email"].ToString().Equals("")))
            {
                this.Email = drClient["Email"].ToString();
            }
            if (!(drClient["PhoneNo"].ToString().Equals("")))
            {
                this.MobileNumber = drClient["PhoneNo"].ToString();
            }
            //   System.Windows.MessageBox.Show(" " + drClient["User_Id"]);
            if (!(drClient["User_Id"].ToString().Equals("")))
            {
                this.UserID = Convert.ToInt32(drClient["User_Id"].ToString());
            }

        }
        public int Update()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteClient";

                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Client_Id1",this.ClientID),
                    new MySqlParameter("@User_Id1",  this.UserID),
                    new MySqlParameter("@CompanyName1",this.CompanyName),
                    new MySqlParameter("@ContactFirstName1",this.FirstName),
                    new MySqlParameter("@ContactLastName1",this.LastName),
                    new MySqlParameter("@DOB1",this.DOB),
                    new MySqlParameter("@Gender1",this.Gender),
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
                int rowsaffected=dal.InsertUpdateDeleteSP(SPName, parameters);
                if(rowsaffected == 0)
                {
                    throw new Exception("Client with Client '" + this.FirstName + "' Could not be Updated in the database");
                }
                return rowsaffected;
            }
            catch (Exception ex)
            {
                throw new Exception("Client Could not be Updated!!"+ ex.Message);
                throw ex;

                //MessageBox.Show("Something went wrong, but we don't know what! Client was not added tot he database","Add Client",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
           
        }
        public int Insert()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteClient";

                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Client_Id1",""),
                    new MySqlParameter("@User_Id1",  App.Current.Properties["LoginUserId"]),
                    new MySqlParameter("@CompanyName1",this.CompanyName),
                    new MySqlParameter("@ContactFirstName1",this.FirstName),
                    new MySqlParameter("@ContactLastName1",this.LastName),
                    new MySqlParameter("@DOB1",this.DOB),
                    new MySqlParameter("@Gender1",this.Gender),
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
                int rowsAffected = dal.InsertUpdateDeleteSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Client with Client '" + this.FirstName + "' could not be Added in the database! ");
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {

                throw new Exception("Client Could not be Added!!"+ ex.Message);
                throw ex;
               // return 0;
            }

            
            /*DAL dal = new DAL();

           
            dal.Insert("insert into bit_client,bit_client_location(ContactFirstName,ContactLastName,StreetAddress,Suburb,State,PostCode,Email,PhoneNo,CompanyName) values ('" + this.FirstName+ "','" + this.LastName + "','" + this.Street+ "','" + this.Suburb + "','" + this.State + "','" + this.PostCode + "','" + this.Email + "','" + this.MobileNumber + "','" + this.CompanyName + "')");*/
        }
        public int Delete()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteClient";

                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Client_Id1",this.ClientID),
                    new MySqlParameter("@User_Id1",  this.UserID),
                    new MySqlParameter("@CompanyName1",this.CompanyName),
                    new MySqlParameter("@ContactFirstName1",this.FirstName),
                    new MySqlParameter("@ContactLastName1",this.LastName),
                    new MySqlParameter("@DOB1",this.DOB),
                    new MySqlParameter("@Gender1",this.Gender),
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
                //dal.InsertUpdateDeleteSP(SPName, parameters);
                int rowsAffected = dal.InsertUpdateDeleteSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                   throw new Exception("Client with Client '" + this.FirstName + "' could not be Deleted from the database! ");
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {

                throw new Exception("Client Could not be Deleted!!", ex);
            }
           
        }
    }
}
