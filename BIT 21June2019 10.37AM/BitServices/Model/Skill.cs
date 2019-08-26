using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using BitServices.Commands;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace BitServices.Model
{
    class Skill : NotificationClass
    {
        private int skill_ID;
        private string skillType;

        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        public int Skill_ID {

            get { return skill_ID; }
            set
            {
                skill_ID = value;
               OnPropertyChanged("Skill_ID");
            }
        }

        public string SkillType {
             
            get { return skillType; }
            set
            {
                if (!Regex.Match(value, "^[a-zA-Z\\s\\,]*$").Success)
                {
                    MessageBox.Show("Please Enter valid skill Type","Skill Type",MessageBoxButton.OK);
                    return;
                }
                skillType = value;
                OnPropertyChanged("SkillType");
            }

        }
        public Skill()
        {

        }
        public Skill(DataRow drSkill)
        {
            MapSkillProperties(drSkill);
        }
       
        private void MapSkillProperties(DataRow drSkill)
        {
            this.skill_ID = Convert.ToInt32(drSkill["Skill_Id"].ToString());
            this.skillType = drSkill["Skill_Type"].ToString();
        }
        //public void Update()
        //{
        //    DAL dal = new DAL();
        //    dal.Update("update bit_skill set Skill_Type = '"+ this.SkillType + "' where skill_id = " + this.skill_ID);
        //}
        //public void Insert()
        //{
        //    DAL dal = new DAL();

        //    // dal.Insert("insert into bit_skill(skill_Id,skillType) values ("+this.skill_ID+",'" +this.skillType + "')");
        //    dal.Insert("insert into bit_skill(skill_Type) values ('" + this.skillType + "')");
        //}

        //public void Delete()
        //{
        //    DAL dal = new DAL();

        //    // dal.Insert("insert into bit_skill(skill_Id,skillType) values ("+this.skill_ID+",'" +this.skillType + "')");
        //    dal.Delete("delete from bit_skill where skill_id = " + this.skill_ID);
        //}
        public int Update()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteSkill";

                MySqlParameter[] parameters =
                    {

                    new MySqlParameter("@Skill_Id1",this.Skill_ID),
                    new MySqlParameter("@Skill_Type1",this.SkillType),
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
                    throw new Exception("Skills with skill '" + this.Skill_ID + "' could not be Updated in the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Skills Could not be Updated!!!", ex);
               // return 0;
            }
            
        }
        public int Insert()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteSkill";

                MySqlParameter[] parameters =
                    {
                    new MySqlParameter("@Skill_Id1",this.Skill_ID),
                    new MySqlParameter("@Skill_Type1",this.SkillType),
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
                    throw new Exception("Skills with skill '" + this.Skill_ID + "' could not be Added in the database! ");
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {

                throw new Exception("Skills Could not be Added!!!", ex);
                //return 0;
            }
           
        }
        public int Delete()
        {
            try
            {
                string SPName = "BitInsertUpdateDeleteSkill";

                MySqlParameter[] parameters =
                    {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Skill_Id1",this.Skill_ID),
                    new MySqlParameter("@Skill_Type1",this.SkillType),
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
                    throw new Exception("Skills with skill '" + this.Skill_ID + "' could not be Deleted from the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Skills Could not be Deleted!!!", ex);
            }
            
        }
    }
}

