using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices.Model
{
    class ContractorJob : Contractor 
    {
        private string contractorJobStatus;
        public string ContractorJobStatus
        {
            get { return contractorJobStatus; }
            set
            {
                contractorJobStatus = value;
                OnPropertyChanged("ContractorJobStatus");
            }
        }
        public ContractorJob()
        {

        }
        public ContractorJob(DataRow drContractorJob)

        {
            MapContractorJobProperties(drContractorJob);
        }

        private void MapContractorJobProperties(DataRow drContractorJob)
        {

            if (drContractorJob["ContractorJobStatus"].ToString().Equals("") || drContractorJob["ContractorJobStatus"].ToString().Equals(null))
            {
                this.contractorJobStatus = "Not Proposed";
            }
            else
            {
                this.contractorJobStatus = drContractorJob["ContractorJobStatus"].ToString();
            }
          
            this.ContractorID = Convert.ToInt32(drContractorJob["contractor_Id"].ToString());
            //  this.UserName = drContractor["UserId"].ToString();
            this.UserID = Convert.ToInt32(drContractorJob["User_Id"].ToString());
            this.FirstName = drContractorJob["FirstName"].ToString();
            this.LastName = drContractorJob["LastName"].ToString();
            //  skill.SkillType = drContractor["Skill_Type"].ToString();
            this.DOB = Convert.ToDateTime(drContractorJob["DOB"]);
            this.Gender = drContractorJob["Gender"].ToString();
            this.Street = drContractorJob["StreetAddress"].ToString();
            this.Suburb = drContractorJob["Suburb"].ToString();
            this.State = drContractorJob["State"].ToString();
            this.PostCode = drContractorJob["PostCode"].ToString();
            this.Email = drContractorJob["Email"].ToString();
            this.MobileNumber = drContractorJob["PhoneNo"].ToString();

        }
    }
}
