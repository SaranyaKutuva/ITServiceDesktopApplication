using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace BitServices.Model
{
    class Contractor : Person
    {
        private int contractorID;
        Skill skill = new Skill();
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
        public int ContractorID
        {
            get { return contractorID; }
            set
            {
                contractorID = value;
                OnPropertyChanged("ContractorID");
            }
        }
        public Contractor()
        {
        }
        public Contractor(DataRow drContractor) : base()
        {
            MapContractorProperties(drContractor);
        }

        private void MapContractorProperties(DataRow drContractor)
        {
            this.contractorID = Convert.ToInt32(drContractor["contractor_Id"].ToString());
            this.UserName = drContractor["UserName"].ToString();
            this.userID = Convert.ToInt32(drContractor["User_Id"].ToString());
            this.FirstName =    drContractor["FirstName"].ToString();
            this.LastName =     drContractor["LastName"].ToString();
            //  skill.SkillType = drContractor["Skill_Type"].ToString();
            this.DOB = Convert.ToDateTime(drContractor["DOB"]);
            this.Gender = drContractor["Gender"].ToString();
            this.Street =       drContractor["StreetAddress"].ToString();
            this.Suburb =       drContractor["Suburb"].ToString();
            this.State =        drContractor["State"].ToString();
            this.PostCode =     drContractor["PostCode"].ToString();
            this.Email =        drContractor["Email"].ToString();
            this.MobileNumber = drContractor["PhoneNo"].ToString();
        }
        #region WithoutStorProc
        //public void Update()
        //{
        //    DAL dal = new DAL();
        //    dal.Update("update bit_contractor,bit_contractor_skill set FirstName = '" + this.FirstName + "', LastName='" + this.LastName + "', StreetAddress = '" + this.Street + "', Suburb= '" + this.Suburb + "',  state = '" + this.State + "', PostCode = '" + this.PostCode + "',  Email = '" + this.Email + "',  PhoneNo = '" + this.MobileNumber + "' where bit_contractor.Contractor_Id = bit_contractor_skill.Contractor_Id and bit_contractor.Contractor_Id =" + this.ContractorID);
        //}
        //public void Insert()
        //{
        //    DAL dal = new DAL();


        //    dal.Insert("insert into bit_contractor(FirstName,LastName,StreetAddress,Suburb,State,PostCode,Email,PhoneNo) values ('" + this.FirstName + "','" + this.LastName + "','" + this.Street + "','" + this.Suburb + "','" + this.State + "','" + this.PostCode + "','" + this.Email + "','" + this.MobileNumber + "')");
        //}
        //public void Delete()
        //{
        //    DAL dal = new DAL();

        //    dal.Delete("delete from bit_contractor where contractor_Id = " + this.contractorID);
        //}
        #endregion WithoutStorProc
        public int Update()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteContractor";
               // System.Windows.MessageBox.Show(this.MobileNumber.ToString());
                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Contractor_Id1",this.ContractorID),

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
                    throw new Exception("Contractor with contractor '" + this.FirstName + "' Could not be Updated in the database");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Contractor Could not be Updated!!"+ex.Message);
                //return 0;
            }
            
        }
        public int Insert()
        {
          //  MessageBox.Show(this.ContractorID + " " + this.FirstName + " " + this.LastName + " " + this.DOB + " " + this.Street + " " +this.State + " " + this.Suburb + " " + this.PostCode + " "+ this.MobileNumber + " " + this.Email + " " + this.Gender);
            try
            {
                string SPName = "BitInsertUpdateDeleteContractor";

                MySqlParameter[] parameters =
                    {
                    // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                     new MySqlParameter("@Contractor_Id1",this.ContractorID),
                  //  new MySqlParameter("@Employee_Type1",this.EmployeeType),
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
                int rowsAffected = dal.InsertUpdateDeleteSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                
                    throw new Exception("Contractor with contractor '" + this.FirstName + "' could not be Added in the database! ");
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                throw new Exception("Contractor Could not be Added!!", ex);
                throw ex;
            }
            
            /*DAL dal = new DAL();

           
            dal.Insert("insert into bit_client,bit_client_location(ContactFirstName,ContactLastName,StreetAddress,Suburb,State,PostCode,Email,PhoneNo,CompanyName) values ('" + this.FirstName+ "','" + this.LastName + "','" + this.Street+ "','" + this.Suburb + "','" + this.State + "','" + this.PostCode + "','" + this.Email + "','" + this.MobileNumber + "','" + this.CompanyName + "')");*/
        }
        public int Delete()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteContractor";

                MySqlParameter[] parameters =
                    {
                    // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                     new MySqlParameter("@Contractor_Id1",this.ContractorID),
                   // new MySqlParameter("@Employee_Type1",this.EmployeeType),
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
                    throw new Exception("Contractor with contractor '" + this.FirstName + "' could not be Deleted from the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Contractor Could not be Deleted!!", ex);
                throw ex;
            }
            
        }

        public DataTable ReadOtherSkills()
        {
            DAL dalObj = new DAL();
          
            return dalObj.Read("select distinct skill_Type from bit_contractor_skill where Contractor_Id <> " + this.ContractorID);
        }

        public DataTable ReadOtherSuburbs()
        {
            DAL dalObj = new DAL();

            return dalObj.Read("select distinct suburb from bit_contractor_preferred_suburb where Contractor_Id <> " + this.ContractorID);
        }
    }
}
