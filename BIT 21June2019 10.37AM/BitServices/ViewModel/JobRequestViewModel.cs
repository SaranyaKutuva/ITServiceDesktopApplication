using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BitServices.Commands;
using BitServices.Model;

namespace BitServices.ViewModel
{
    class JobRequestViewModel :  NotificationClass
    {
        // This class is the communication class between your view(JobRequestPageView.Xaml) and to your model(JobRequest.cs)
        // Create a list that will generated from database
        JobRequest jobRequest;

        //private int clientId;
        //public int ClientId
        //{
        //    get{return clientId; }
        //    set
        //    {
        //        clientId = value;
        //        OnPropertyChanged("ClientId");
        //    }
        //}

        //private RelayCommand addRelay;
        
        private ObservableCollection<JobRequest> jobRequestCollection = new ObservableCollection<JobRequest>();

        public ObservableCollection<JobRequest> JobRequestCollection
        {
            get { return jobRequestCollection; }
            set
            {
                jobRequestCollection = value;
                OnPropertyChanged("JobRequestCollection");
            }
        }
        //private int passedclientId;
        //public int PassedClientId
        //{
        //    get { return passedclientId; }
        //    set
        //    {
        //        MessageBox.Show("set passedclientid");
        //        passedclientId = value;
        //        OnPropertyChanged("PassedClientId");
        //    }

        //}
        private DataTable jobRequestColRows;
        public DataTable JobRequestColRows
        {
            get { return jobRequestColRows; }
            set
            {
                jobRequestColRows = value;
                OnPropertyChanged("JobRequestColRows");
            }
        }
        private DataTable jobRequestLocationRows;
        public DataTable JobRequestLocationRows
        {
            get { return jobRequestLocationRows; }
            set
            {
                jobRequestLocationRows = value;
                OnPropertyChanged("JobRequestLocationRows");
            }
        }
        private JobRequest selectedJobRequest;
        public JobRequest SelectedJobRequest
        {
            get
            {
                return selectedJobRequest;
            }
            set
            {
                {
                    //MessageBox.Show("set selected job request");
                    selectedJobRequest = value;
                    OnPropertyChanged("SelectedJobRequest");
                }
            }
        }

        private string selectedLocationId;
        public string SelectedLocationId
        {
            get { return selectedLocationId; }
            set
            {
                selectedLocationId = value;
            }
        }


        private string selectedJobType;
        public string SelectedJobType
        {
            get { return selectedJobType; }
            set
            {
                selectedJobType = value;
            }
        }
        //private JobRequest selectedClientLocationCols;
        //public JobRequest SelectedClientLocationCols
        //{
        //    get
        //    {
        //        return jobRequest;
        //    }
        //    set
        //    {
        //        jobRequest = value;
        //        OnPropertyChanged("SelectedClientLocationCols");
        //    }
        //}




        public JobRequestViewModel()
        {
        }

            public JobRequestViewModel(string ClientId)
            {
            // MessageBox.Show("ClientID " + ClientId);
            // 1. Its going to connect to DAL and bring in the results of all JobRequest
            // 2. We create objects of type jobRequest and then add that object to our collection
            /*DAL dal = new DAL();
             DataTable dt = dal.Read("select bit_client.Client_Id,concat(bit_client.ContactFirstName,' ' ,bit_client.ContactLastName) as Client_Name,bit_job_request.Location_Id,bit_job_request.JobRequest_Id,bit_job_request.RequestDate,bit_job_request.RequestTime,bit_job_request.Status,bit_job_request.Priority,bit_job_request.Comments,bit_job_request.Job_Type_Id from bit_job_request,bit_client,bit_client_location where bit_job_request.Location_Id = bit_client_location.Location_Id and bit_client_location.Client_Id = bit_client.Client_Id");
       
           // clientId = Convert.ToInt32(ClientId);
            JobRequest job;
            foreach (DataRow dr in dt.Rows)
            {
                 job = new JobRequest(dr);
                JobRequestCollection.Add(job);
            }*/


            //  LoadClientIdCombo();
            //job = new JobRequest();
            //JobRequest job = new JobRequest();
            ///JobRequestCollection.Add(job);
            AddJobRequest();

            LoadJobTypeCombo();
            LoadClientLocationCombo(ClientId);
        }

        private void LoadClientLocationCombo(string ClientId) 
        {
            try
            {
                DAL dal = new DAL();
                //we will pass sql to the database
                DataTable dtfieldNames = dal.Read("SELECT Location_Id,Location_Name FROM `bit_Client_Location` WHERE Client_Id = " + ClientId);
                DataRow dtfieldNames1;
                dtfieldNames1 = dtfieldNames.NewRow();
                dtfieldNames1["Location_Id"] = "0";
                dtfieldNames1["Location_Name"] = "-- Select A Location Name --"; // Here We're 'inserting' the message into that column of the row
                dtfieldNames.Rows.InsertAt(dtfieldNames1, 0);
                //MessageBox.Show(dtfieldNames.Rows.ToString());
                jobRequestLocationRows = dtfieldNames;
            }
            catch (Exception ex)
            {

                MessageBox.Show("LoadClientLocationCombo" + ex.Message);
            }
        }

        private void LoadJobTypeCombo()
        {
            try
            {
                DAL dal = new DAL();
                // we will pass sql to the database
                DataTable dtfieldNames = dal.Read("Select Job_Type_Id,Job_Type from bit_job_type");

                // Add a message to the combobox for the user to select an Client
                DataRow dtfieldNames1;
                //This is not putting our DataRow into the  DataTable. Its just 'copying' the schema of the table to our row.
                dtfieldNames1 = dtfieldNames.NewRow();

                dtfieldNames1["Job_Type_Id"] = "0";
                dtfieldNames1["Job_Type"] = "-- Select A Job Type --"; // Here We're 'inserting' the message into that column of the row
                dtfieldNames.Rows.InsertAt(dtfieldNames1, 0);
                jobRequestColRows = dtfieldNames;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hi" + ex.Message);
            }
        }

       

        //private string selectedJobRequestCols;
        //public string SelectedJobRequestCols
        //{
        //    get { return selectedJobRequestCols; }
        //    set
        //    {
        //        selectedJobRequestCols = value;
        //        OnPropertyChanged("SelectedJobRequestCols");
        //    }
        //}
     

        public RelayCommand Add
        {
            get { return new RelayCommand(AddJobRequest, true); }
        }
        private void AddJobRequest()
        {
            //DataTable dt = new DataTable();
              DAL dal = new DAL();
              DataTable dt = dal.Read("select * from bit_job_request where 1=2");

              JobRequest jobreq = new JobRequest();
              JobRequestCollection.Add(jobreq);
              SelectedJobRequest = jobreq;
              MessageBox.Show("Click Save button after entering the new Job Request details.", "Job Request", MessageBoxButton.OK, MessageBoxImage.Warning);


        }
        public RelayCommand Save
        {
            get { return new RelayCommand(SaveJobRequest, true); }
        }
        private void SaveJobRequest()
        {
            //MessageBox.Show(SelectedJobRequest.RequestDate.ToString());
            try
            {
                SelectedJobRequest.LocationID = Convert.ToInt32(SelectedLocationId);
                SelectedJobRequest.JobTypeID = Convert.ToInt32(SelectedJobType);


                SelectedJobRequest.Add();
                MessageBox.Show("Thank you!  The new Client's Job details have been added to the Database.", "Add Job Request", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Something Went Wrong, But we Dont know what! Job Request details was not added to the database");
            }
            
        }
    }
}
