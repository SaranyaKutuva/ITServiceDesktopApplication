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
    class ClientAdd : Client
    {
        private int clientID;

        public int ClientID
        {
            get { return clientID; }
            set
            {
                clientID = value;
                OnPropertyChanged("ClientID");
            }
        }

        private int locationID;
        public int LocationID
        {
            get { return locationID; }
            set
            {
                locationID = value;
                OnPropertyChanged("LocationID");
            }
        }


        private string locationName;
        public string LocationName
        {
            get { return locationName; }
            set
            {
                locationName = value;
                OnPropertyChanged("LocationName");
            }
        }


        public ClientAdd() 
        {

        }
        public ClientAdd(DataRow drClientAdd) : base()
        {
            MapClientProperties(drClientAdd);
        }

        

        private void MapClientProperties(DataRow drClientAdd)
        {
            
            App.Current.Properties["LoginUserId"] = "1";
            this.ClientID = Convert.ToInt32(drClientAdd["Client_Id"].ToString());
           if (!(drClientAdd["Location_Id"].ToString().Equals(""))) {
                this.LocationID = Convert.ToInt32(drClientAdd["Location_Id"].ToString());
            }
            if (!(drClientAdd["Location_Name"].ToString().Equals("")))
            {
                this.LocationName = drClientAdd["Location_Name"].ToString();
            }
          
            this.Street = drClientAdd["StreetAddress"].ToString();
            this.Suburb = drClientAdd["Suburb"].ToString();
            this.State = drClientAdd["State"].ToString();
            this.PostCode = drClientAdd["PostCode"].ToString();
            

        }
        public int UpdateAddress()
        {
            try
            {
                DAL dal = new DAL();
                string SPName = "BitInsertUpdateDeleteClientAddress";
                //  System.Windows.MessageBox.Show(" " + this.UserID.ToString());
                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@ClientId",this.ClientID),
                    new MySqlParameter("@LocationId",this.LocationID),
                    new MySqlParameter("@LocationName",this.LocationName),
                    new MySqlParameter("@PostCode1",this.PostCode),
                    new MySqlParameter("@State1",this.State),
                    new MySqlParameter("@StreetAddress1",this.Street),
                    new MySqlParameter("@Suburb1",this.Suburb),
                    new MySqlParameter("@UserId",this.UserID ),
                    new MySqlParameter("@Mode","UPDATE" ),

                };
                //System.Windows.MessageBox.Show(this.locationID.ToString()
               //     + this.LocationName + this.PostCode + this.State + this.Street +
                 //   this.Suburb + this.UserID
                   // );
                int rowsAffected = dal.InsertSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Client Location could not be Updated in the database! ");
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {

                throw new Exception("Client Location Could not be Updated!!"+ ex);
               // return 0;
            }
            
        }
        public int InsertAddress(int ClientId)
        {
            try
            {
                this.ClientID = ClientId;
                string SPName = "BitInsertUpdateDeleteClientAddress";
              //  System.Windows.MessageBox.Show(" " + this.UserID.ToString() + " " + this.ClientID.ToString());
                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@ClientId",this.ClientID),
                    new MySqlParameter("@LocationId",""),
                    new MySqlParameter("@LocationName",this.LocationName),
                    new MySqlParameter("@PostCode1",this.PostCode),
                    new MySqlParameter("@State1",this.State),
                    new MySqlParameter("@StreetAddress1",this.Street),
                    new MySqlParameter("@Suburb1",this.Suburb),
                    new MySqlParameter("@UserId",this.UserID ),
                    new MySqlParameter("@Mode","INSERT" ),

                };
                DAL dal = new DAL();
                int rowsAffected= dal.InsertSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                   throw new Exception("Client Location could not be Added in the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Client Location Could not be Added!!"+ex);
               // return 0;
            }
           

            /*DAL dal = new DAL();

           
            dal.Insert("insert into bit_client,bit_client_location(ContactFirstName,ContactLastName,StreetAddress,Suburb,State,PostCode,Email,PhoneNo,CompanyName) values ('" + this.FirstName+ "','" + this.LastName + "','" + this.Street+ "','" + this.Suburb + "','" + this.State + "','" + this.PostCode + "','" + this.Email + "','" + this.MobileNumber + "','" + this.CompanyName + "')");*/
        }
        public int DeleteAddress()
        {
            try
            {
                DAL dal = new DAL();

                string SPName = "BitInsertUpdateDeleteClientAddress";
                //  System.Windows.MessageBox.Show(" " + this.UserID.ToString());
                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@ClientId",this.ClientID),
                    new MySqlParameter("@LocationId",this.LocationID),
                    new MySqlParameter("@LocationName",this.LocationName),
                    new MySqlParameter("@PostCode1",this.PostCode),
                    new MySqlParameter("@State1",this.State),
                    new MySqlParameter("@StreetAddress1",this.Street),
                    new MySqlParameter("@Suburb1",this.Suburb),
                    new MySqlParameter("@UserId",this.UserID ),
                    new MySqlParameter("@Mode","DELETE" ),

                };

                int rowsAffected = dal.InsertSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Client Location could not be Deleted from the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Client Location Could not be Deleted!!", ex);
               // return 0;
            }
           
        }
    }
}
