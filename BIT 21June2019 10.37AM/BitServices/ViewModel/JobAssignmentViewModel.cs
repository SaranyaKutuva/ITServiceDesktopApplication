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
    class JobAssignmentViewModel : NotificationClass
    {
        // This class is the communication class between your view(jobAssignmentPageView.Xaml and to your Model(Job
        // JobAssignmentViewModel.cs)
        // Create a list that will generated from database
        private JobAssignment jobAssignment;
        private Contractor contractor;
        private ContractorJob contractorjob;
        private RelayCommand findRelay;
        private RelayCommand assignRelay;
        private ObservableCollection<JobAssignment> jobCollection = new ObservableCollection<JobAssignment>();
        private ObservableCollection<Contractor> contractorCollection = new ObservableCollection<Contractor>();
        private ObservableCollection<ContractorJob> contractorJobCollection = new ObservableCollection<ContractorJob>();
        

        public ObservableCollection<Contractor> ContractorCollection
        {
            get { return contractorCollection; }
        }
        public ObservableCollection<ContractorJob> ContractorJobCollection
        {
            get { return contractorJobCollection; }
        }
        public ObservableCollection<JobAssignment> JobCollection
        {
            get { return jobCollection; }
        }
        public JobAssignment SelectedJob
        {
            get { return jobAssignment; }
            set
            {
                jobAssignment = value;
                OnPropertyChanged("SelectedJob");
            }
        }
        Boolean isContractorSelected;
        public Boolean IsContractorSelected
        {
            get { return isContractorSelected; }
            set
            {
                isContractorSelected = value;
                OnPropertyChanged("IsContractorSelected");
            }
        }
        public Contractor SelectedContractor
        {
            get { return contractor; }
            set
            {
                contractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }
        public ContractorJob SelectedContractorJob
        {
            get { return contractorjob; }
            set
            {
                contractorjob = value;
                OnPropertyChanged("SelectedContractorJob");
            }
        }
        public void Load()
        {
            JobCollection.Clear();
            DAL dal = new DAL();
            DataTable dt = dal.Read("select JobRequest_Id,bit_job_type.Job_Type,bit_job_type.Job_Type_Id,RequestDate,Priority,Comments,Status,bit_client_location.Location_Name,bit_client_location.Location_Id from bit_job_request, bit_job_type, bit_client_location where bit_job_request.Job_Type_Id = bit_job_type.Job_Type_Id and   bit_job_request.Location_Id = bit_client_location.Location_Id and   Status in('Requested','Acknowledged') order by JobRequest_Id");
            foreach (DataRow dr in dt.Rows)
            {
                JobAssignment job = new JobAssignment(dr);
                JobCollection.Add(job);
            }

        }
        public JobAssignmentViewModel()
        {

            //1. Its going to connect to DAL  and bring in the results of all contractors
            //2. We create objects of type contractor and then add that object to our collection
            Load();
            IsContractorSelected = false;


        }
        public RelayCommand Find
        {
            get { return new RelayCommand(FindContractor, true); }
            set
            {
                findRelay = value;
                OnPropertyChanged("FindContractor");
            }
        }
        public void FindContractor()
        {

            DataTable dt = SelectedJob.Find();

            
            contractorJobCollection.Clear();
            // MessageBox.Show(dt.Rows.Count.ToString());
            int i = 0;
            int assigned = 0;
            IsContractorSelected = true;
            foreach (DataRow dr in dt.Rows)
            {
                 if (i == 0)
                {
                    SelectedContractor = new ContractorJob(dr);
                }
                i++;
                // MessageBox.Show(dr[0].ToString());
                if (dr[0].ToString().Equals("Proposed") || dr[0].ToString().Equals("Accepted") || dr[0].ToString().Equals("Completed"))
                {
                    assigned++;
                    //   MessageBox.Show(IsContractorSelected.ToString());
                }


                //  Contractor contractor = new Contractor(dr);
                // MessageBox.Show(dr[0].ToString());
                if(!(dr[0].ToString().Equals("Rejected"))) {
                    ContractorJob contractorjob = new ContractorJob(dr);
                    contractorJobCollection.Add(contractorjob);
                }
               
            }
            if (contractorJobCollection.Count == 0)
            {
                IsContractorSelected = false;
                MessageBox.Show("No contractor availiable!","Find Contractor",MessageBoxButton.OK ,MessageBoxImage.Information);
            }
            else {
                if (assigned ==0)
                {
                    IsContractorSelected = true;
                }
                else
                {
                    IsContractorSelected = false;
                }
            }


            //MessageBox.Show(IsContractorSelected.ToString());




        }

        public RelayCommand Assign
        {
            get { return new RelayCommand(AssignContractor, true); }
            set
            {
                assignRelay = value;
                OnPropertyChanged("AssignContractor");
            }
        }
        private void AssignContractor()
        {

           try
            {
                if (SelectedContractorJob.ContractorID == 0)
                {
                  
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Select contractor and then click on Assign", "Contractor not selected", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SelectedJob.Assign(SelectedContractorJob.ContractorID);
            SelectedJob.Status = "Acknowledged";
            FindContractor();
        }

    }
}

