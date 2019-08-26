using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BitServices.Model
{
    class JobAssignment : JobRequest
    {
        private int contractorID;
       // private int contractorName;
        private string locationName;
        private string jobType;
        public string LocationName
        {
            get { return locationName; }
            set
            {
                locationName = value;
                OnPropertyChanged("LocationName");
            }
        }
        public string JobType
        {
            get { return jobType; }
            set
            {
                jobType = value;
                OnPropertyChanged("JobType");
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

        

        public JobAssignment()
        {

        }
        public JobAssignment(DataRow drJobAssignment)
        {
            MapEmployeeProperties(drJobAssignment);
        }

        private void MapEmployeeProperties(DataRow drJobAssignment)
        {
            this.JobRequestID = Convert.ToInt32(drJobAssignment["JobRequest_Id"].ToString());
            //   this.ClientID = Convert.ToInt32(drjobRequest["ClientID"].ToString());
            this.LocationName = drJobAssignment["Location_Name"].ToString();
            this.JobType = drJobAssignment["Job_Type"].ToString();
            this.JobTypeID = Convert.ToInt32(drJobAssignment["Job_Type_Id"].ToString());
            this.RequestDate = Convert.ToDateTime(drJobAssignment["RequestDate"].ToString());
      //      this.RequestTime = drJobAssignment["RequestTime"].ToString();
            this.Comments = drJobAssignment["Comments"].ToString();
            this.Priority = drJobAssignment["Priority"].ToString();
            this.Status = drJobAssignment["Status"].ToString();
            this.LocationID = Convert.ToInt32(drJobAssignment["Location_Id"].ToString());
            //this.ContractorJobStatus = drJobAssignment["ContractorJobStatus"].ToString();
        }
        public DataTable Find()
        {
            DataTable dt =null;
            try
            {
                DAL dal = new DAL();
                //System.Windows.MessageBox.Show(" Req " + this.RequestDate + " Job "+
                //     this.JobTypeID + " Client " +
                //      this.ClientID + " Loc " +
                //      this.LocationID + " "+
                //      this.JobRequestID
                //    );
                dt = dal.Read("select  (select status from bit_contractor_job bcj where bcj.contractor_id =bc.contractor_id and bcj.JobRequest_Id=" + this.JobRequestID + ") ContractorJobStatus,bc.*  from bit_contractor_availability bca, bit_contractor bc where /*STR_TO_DATE('" + this.RequestDate + "','%d/%m/%Y %H:%i:%s') between StartDate and EndDate and*/ exists (select RequestDate from bit_job_request where JobRequest_Id=" + this.JobRequestID + " and RequestDate  between bca.StartDate and bca.EndDate) and bc.contractor_id = bca.contractor_id and SUBSTRING(concat(Sunday,monday, tuesday, Wednesday, Thursday, Friday, Saturday), (dayofweek(STR_TO_DATE('" + this.RequestDate + "','%d/%m/%Y %H:%i:%s'))), 1)=1 and bca.Contractor_Id in (select Contractor_Id from bit_contractor_skill where skill_id in (select skill_id from bit_job_type where job_type_id = " + this.JobTypeID + ") and exists(select Suburb from bit_contractor_preferred_suburb where bit_contractor_preferred_suburb.Contractor_Id = bca.Contractor_Id and suburb in (select suburb from bit_client_location where location_id = " + this.LocationID + ")))  /*AND (bca.contractor_id," + this.JobRequestID + ") not in (select contractor_id,JobRequest_Id from bit_contractor_job)*/");
                // MessageBox.Show(dt.Rows.Count.ToString());
                //  dal.Read("select Contractor_Id from bit_contractor_availability bca where SUBSTRING(concat(monday, tuesday, Wednesday, Thursday, Friday, Saturday, Sunday), (dayofweek('" + this.RequestDate + "') - 1), 1) = 1 and Contractor_Id in (select Contractor_Id from bit_contractor_skill where skill_id in (select skill_id from bit_job_type where job_type_id = " + this.JobTypeID + ") ) and exists(select Suburb from bit_contractor_preferred_suburb where Contractor_Id = bca.Contractor_Id and suburb in (select suburb from bit_client_location where client_id =" + this.ClientID +" and location_id ="+ this.LocationID+" )");
                ////   dal.Update("update bit_job_request set Contractor_Id = '" + this.ContractorID + "'");
               

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
               throw new Exception("Cannot Find the Contractor", e);
               // return dt;
            }
        }
        public void Assign(int contractorid)
        {
            try
            {
              //  MessageBox.Show(this.JobRequestID +  "  " + contractorid + " " );
                DAL dal = new DAL();

                dal.Update("update bit_job_request set STATUS = 'Acknowledged', Contractor_Id = " + contractorid +" where JobRequest_Id=" + this.JobRequestID);

               //MessageBox.Show("insert into bit_contractor_job (JobRequest_Id,Contractor_Id,Job_Date,Job_Time) " +
                 //   "values (" + this.JobRequestID + "," + contractorid + ",'STR_TO_DATE(" + this.RequestDate + "', '%d/%m/%Y %H:%i:%s')" + ",'" + this.RequestTime + "')");
              dal.Update("insert into bit_contractor_job (JobRequest_Id,Contractor_Id,Job_Date,Job_Time,status) " +
               "values (" + this.JobRequestID +","+ contractorid + ",STR_TO_DATE('" + this.RequestDate + "', '%d/%m/%Y %H:%i:%s'),'" + this.RequestTime+ "','Proposed')");

            }
            catch (Exception e)
            {

                throw new Exception("Cannot Assign the Contractor", e);
            }
        }
    }
}
