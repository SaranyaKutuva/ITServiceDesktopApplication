using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BitServices.Model
{
    class ContractorSkill : Contractor
    {
        Skill skill = new Skill();
        public ContractorSkill():base()
        {

        }
        public ContractorSkill(DataRow drContractorSkill) : base()
        {
            MapContractorSkillProperties(drContractorSkill);
        }

        private void MapContractorSkillProperties(DataRow drContractorSkill)
        {
           // this.ContractorID = Convert.ToInt32(drContractorSkill["Contractor_ID"].ToString());
            skill.Skill_ID = Convert.ToInt32(drContractorSkill["Skill_ID"].ToString());

        }

        public void Update(int ContractorId)
        {
            DAL dal = new DAL();
            dal.Update("update bit_contractor_skill set Skill_Id = " + skill.Skill_ID +" where Contractor_Id =" + this.ContractorID);
        }
        public int Insert(int ContractorId,string skillid)
        {
            try
            {
                DAL dal = new DAL();
                // System.Windows.MessageBox.Show(skillid.ToString());
                int rowsAffected = dal.Insert("insert into bit_contractor_skill(Skill_Id,contractor_id) values (" + skillid + "," + ContractorId + ")");
                // int rowsAffected = dal.InsertSP(SPName, parameters);
                if (rowsAffected == 0)
                {
                    throw new Exception("Contractor could not be added to the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Contractor could not be added to the database!!", ex);
               // return 0;
            }
           

            
        }
        public int Delete(int ContractorId,string skillid)
        {
            try
            {
                DAL dal = new DAL();

                int rowsAffected = dal.Delete("delete from bit_contractor_skill where contractor_Id = " + ContractorId + " AND Skill_ID =" + skillid);
                if (rowsAffected == 0)
                {
                    throw new Exception("Contractor Skill could not be deleted from the database! ");
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw new Exception("Contractor Skill could not be deleted from the database!!" + ex);
               //return 0;
            }
           
        }
    }
}
