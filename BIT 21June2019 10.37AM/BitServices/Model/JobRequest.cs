using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BitServices.Commands;
using System.Threading.Tasks;
using System.Data;

namespace BitServices.Model
{
    class JobRequest : ClientAdd
    {
       // private int clientId;

        private int jobRequestID;
        public int JobRequestID
        {
            get { return jobRequestID; }
            set
            {
                jobRequestID = value;
                OnPropertyChanged("JobRequestID");
                
            }
        }

        private int jobTypeID;
        public int JobTypeID
        {
            get { return jobTypeID; }
            set
            {
                jobTypeID = value;
                OnPropertyChanged("JobTypeID");

            }
        }

        private DateTime requestDate;
        public DateTime RequestDate
        {
            get { return requestDate; }
            set
            {
                //if (DateTime.Now.Year - value.Year < 30)
                //{
                //    throw new Exception("Under age!");
                //}
                //this.requestDate = value;
                requestDate = value;
                OnPropertyChanged("RequestDate");
            }
        }
        private string requestTime;
        public string RequestTime
        {
            get { return requestTime; }
            set
            {
                requestTime= value;
                OnPropertyChanged("RequestTime");
            }
        }
        private string comments;
        public string Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                OnPropertyChanged("Comments");
            }
        }
        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

       

       // public string Status = "Assigned";
        public JobRequest():base()
        {

        }
      public JobRequest(DataRow drjobRequest) :base()
        {
            MapJobRequestProperties(drjobRequest);
        }

        private void MapJobRequestProperties(DataRow drjobRequest)
        {
            this.jobRequestID = Convert.ToInt32(drjobRequest["JobRequest_Id"].ToString());
         //   this.ClientID = Convert.ToInt32(drjobRequest["ClientID"].ToString());
          
            this.jobTypeID = Convert.ToInt32(drjobRequest["Job_Type_Id"].ToString());
            this.requestDate = Convert.ToDateTime(drjobRequest["RequestDate"].ToString());
            this.requestTime = drjobRequest["RequestTime"].ToString();
            this.comments = drjobRequest["Comments"].ToString();
            this.priority = drjobRequest["Priority"].ToString();
            this.Status = "Requested";
            this.LocationID = Convert.ToInt32(drjobRequest["Location_Id"].ToString());
        }
        public void Add()
        {
            //this.ClientID = ClientId;
            // MessageBox.Show("Something Went Wrong");
            //MessageBox.Show("Job"+jobTypeID.ToString() + " " + this.Priority);
            //MessageBox.Show("Location"+LocationID.ToString() + this.Status + "  " + this.Comments);
            try
            {
                DAL objDal = new DAL();
               objDal.Insert("insert into bit_job_request(Job_Type_Id, RequestDate, Priority, Status, Comments, Location_Id) values(" + this.JobTypeID + ",STR_TO_DATE('" + this.RequestDate+ "','%d/%m/%Y %H:%i:%s'),'" + this.Priority+"','Requested','"+this.Comments+"',"+this.LocationID+ " )");
               // MessageBox.Show(JobTypeID.ToString());

                //insert into bit_job_request(Job_Type_Id, RequestDate, Priority, Status, Comments, Location_Id) values(3, '2019/05/13', 'Low', 'Assigned', 'Need Support', 1);
            }
            catch (Exception ex)
            {

                throw new Exception("Something Went Wrong" + ex);

            }
        }
    }
   
}
