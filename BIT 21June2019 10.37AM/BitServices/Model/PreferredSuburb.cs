using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BitServices.Model;

namespace BitServices.Model
{
    class PreferredSuburb : Contractor
    {
       // Skill skill = new Skill();
        public PreferredSuburb() : base()
        {

        }
        public PreferredSuburb(DataRow drContractorPreferredSuburb) : base()
        {
            MapContractorSkillProperties(drContractorPreferredSuburb);
        }

        private void MapContractorSkillProperties(DataRow drContractorPreferredSuburb)
        {
            // this.ContractorID = Convert.ToInt32(drContractorSkill["Contractor_ID"].ToString());
          //  skill.Skill_ID = Convert.ToInt32(drContractorSkill["Skill_ID"].ToString());
            this.Suburb = drContractorPreferredSuburb["Suburb"].ToString();
        }

        public void Update(int ContractorId)
        {
            DAL dal = new DAL();
            dal.Update("update bit_Contractor_Preferred_Suburb set Suburb = " + this.Suburb + " where Contractor_Id =" + this.ContractorID);
        }
        public int Insert(int ContractorId1, string Suburb1)
        {
            try
            {
                DAL dal = new DAL();
                // System.Windows.MessageBox.Show(skillid.ToString());
                int rowsAffected = dal.Insert("insert into bit_Contractor_Preferred_Suburb(Suburb,contractor_id) values ('" + Suburb1 + "'," + ContractorId1 + ")");
                if (rowsAffected == 0)
                {
                    throw new Exception("Contractor Suburb not be added to the database! ");
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {

                throw new Exception("Contractor Suburb could not be added to the database!!", ex);
                //return 0;
            }
           

        }
        public int Delete(int ContractorId1, string Suburb1)
        {
            try
            {
                DAL dal = new DAL();

                int rowsAffected = dal.Delete("delete from bit_Contractor_Preferred_Suburb where contractor_Id = " + ContractorId1 + " AND Suburb ='" + Suburb1 + "'");
                if (rowsAffected == 0)
                {
                    throw new Exception("Contractor Suburb not be deleted from the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Contractor Suburb could not be deleted from the database!!", ex);
                //return 0;
            }
           
        }
    }
}

