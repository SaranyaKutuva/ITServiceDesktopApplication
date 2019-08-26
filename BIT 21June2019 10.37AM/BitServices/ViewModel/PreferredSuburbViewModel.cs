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
    class PreferredSuburbViewModel : NotificationClass
    {
        Contractor contractor = new Contractor();
        private PreferredSuburb preferredSuburb;
        private PreferredSuburb availableSuburb;
        private RelayCommand addRelay;
        //    private RelayCommand updateRelay;
        private RelayCommand deleteRelay;
        private ObservableCollection<PreferredSuburb> preferredSuburbCollection = new ObservableCollection<PreferredSuburb>();

        public ObservableCollection<PreferredSuburb> PreferredSuburbCollection
        {

            get { return preferredSuburbCollection; }
            set
            {
                preferredSuburbCollection = value;
                OnPropertyChanged("PreferredSuburbCollection");
            }
        }
        public PreferredSuburb SelectedPreferredSuburb
        {
            get { return preferredSuburb; }
            set
            {
                preferredSuburb = value;
                OnPropertyChanged("SelectedPreferredSuburb");
            }
        }



        private ObservableCollection<PreferredSuburb> availableSuburbCollection = new ObservableCollection<PreferredSuburb>();

        public ObservableCollection<PreferredSuburb> AvailableSuburbCollection
        {

            get { return availableSuburbCollection; }
            set
            {
                availableSuburbCollection = value;
                OnPropertyChanged("AvailableSuburbCollection");
            }
        }
        public PreferredSuburb SelectedAvailableSuburb
        {
            get { return availableSuburb; }
            set
            {
                availableSuburb = value;
                OnPropertyChanged("SelectedAvailableSuburb");
            }
        }


        private int passedContractorId;
        public int PassedContractorId
        {
            get { return passedContractorId; }
            set
            {
                passedContractorId = value;
                OnPropertyChanged("PassedContractorId");
            }

        }

        public PreferredSuburbViewModel()
        {

        }

        public PreferredSuburbViewModel(string ContractorId)
        {
            try
            {

                DAL dal = new DAL();
                // we will pass sql to the database
                //DataTable dtfieldNames = dal.Read("select  bit_skill.Skill_Id,bit_skill.Skill_Type from bit_contractor_skill,bit_skill WHERE bit_contractor_skill.Skill_Id = bit_skill.Skill_Id and Contractor_Id = 2");
                //MessageBox.Show(ContractorId.ToString());
                DataTable dtfieldNames = dal.Read("SELECT suburb Row, suburb FROM bit_contractor_preferred_suburb where Contractor_Id = " + ContractorId);
                PassedContractorId = Convert.ToInt32(ContractorId);
                //MessageBox.Show(dtfieldNames.Rows.Count.ToString());
                // Add a message to the combobox for the user to select an Client
                DataRow dtfieldNames1;
                //This is not putting our DataRow into the  DataTable. Its just 'copying' the schema of the table to our row.
             //   dtfieldNames1 = dtfieldNames.NewRow();

             //   dtfieldNames1["Row"] = "0";
              //  dtfieldNames1["suburb"] = "-- Select a Suburb--"; // Here We're 'inserting' the message into that column of the row
             //   dtfieldNames.Rows.InsertAt(dtfieldNames1, 0);
                preferredSuburbColRows = dtfieldNames;
                foreach (DataRow dr in dtfieldNames.Rows)
                {

                    PreferredSuburb suburb = new PreferredSuburb(dr);
                    AvailableSuburbCollection.Add(suburb);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not Load Contractor Suburb", "Loading Suburb" + ex.Message);
            }


           LoadSuburbList();


        }
        private void LoadSuburbList()
        {
            try
            {
                DAL dal = new DAL();
                // we will pass sql to the database
                DataTable dtfieldNames = dal.Read("Select distinct suburb Row, suburb from postcodes_geo where suburb not in (select suburb from bit_contractor_preferred_suburb where contractor_id = " + PassedContractorId + ") order by suburb");

                // Add a message to the combobox for the user to select an Client
                DataRow dtfieldNames1;
                //This is not putting our DataRow into the  DataTable. Its just 'copying' the schema of the table to our row.
            //    dtfieldNames1 = dtfieldNames.NewRow();

            //    dtfieldNames1["Row"] = "0";
            //    dtfieldNames1["suburb"] = "-- Select A Suburb --"; // Here We're 'inserting' the message into that column of the row
             // dtfieldNames.Rows.InsertAt(dtfieldNames1,0);
             //   MessageBox.Show("DisplayMember", +dtfieldNames.D)
                suburbColRows = dtfieldNames;
                foreach (DataRow dr in dtfieldNames.Rows)
                {

                    PreferredSuburb suburb = new PreferredSuburb(dr);
                    AvailableSuburbCollection.Add(suburb);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not Load Suburb", "Loading Suburb" + ex.Message);
            }
        }

        private DataTable suburbColRows;

        public DataTable SuburbColRows
        {
            get { return suburbColRows; }
            set
            {
                suburbColRows = value;
                OnPropertyChanged("SuburbColRows");
            }
        }
        private DataTable preferredSuburbColRows;

        public DataTable PreferredSuburbColRows
        {
            get { return preferredSuburbColRows; }
            set
            {
                preferredSuburbColRows = value;
                OnPropertyChanged("PreferredSuburbColRows");
            }
        }
        private string selectedSuburbType;
        public string SelectedSuburbType
        {
            get { return selectedSuburbType; }
            set
            {
                selectedSuburbType = value;
                OnPropertyChanged("SelectedSuburbType");
            }
        }
        private string selectedContractorSuburbType;
        public string SelectedContractorSuburbType
        {
            get { return selectedContractorSuburbType; }
            set
            {
                selectedContractorSuburbType = value;
                OnPropertyChanged("SelectedContractorSuburbType");
            }
        }


        public RelayCommand Add
        {
            get { return new RelayCommand(AddContractorSuburb, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("AddContractorSuburb");
            }
        }
        private void AddContractorSuburb()
        {
            PreferredSuburbColRows.AcceptChanges();
            SuburbColRows.AcceptChanges();
            SelectedPreferredSuburb = new PreferredSuburb();
            //MessageBox.Show(PassedContractorId + " " + SelectedSuburbType);
            SelectedPreferredSuburb.Insert(PassedContractorId, SelectedSuburbType);
            foreach (DataRow dr in SuburbColRows.Rows)
            {
                // MessageBox.Show(dr[0].ToString()+ " " + SelectedSkillType);
                // MessageBox.Show(SkillColRows.Rows.Count.ToString());
                if (dr[0].ToString().Equals(SelectedSuburbType))
                {
                    DataRow dr1 = PreferredSuburbColRows.NewRow();
                    dr1[0] = dr[0];
                    dr1[1] = dr[1];
                    PreferredSuburbColRows.Rows.Add(dr1);
                    //SkillColRows.Rows.Remove(dr);
                    dr.Delete();

                }

            }
            PreferredSuburbColRows.AcceptChanges();
            SuburbColRows.AcceptChanges();
            MessageBox.Show("Suburb Added", "Add Contractor Preferred Suburb", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public RelayCommand Delete
        {
            get { return new RelayCommand(DeleteContractorSuburb, true); }
            set
            {
                deleteRelay = value;
                OnPropertyChanged("DeleteContractorSuburb");
            }
        }


        private void DeleteContractorSuburb()
        {
            PreferredSuburbColRows.AcceptChanges();
            SuburbColRows.AcceptChanges();

            SelectedPreferredSuburb = new PreferredSuburb();
            SelectedPreferredSuburb.Delete(PassedContractorId, SelectedContractorSuburbType);
            foreach (DataRow dr in PreferredSuburbColRows.Rows)
            {
                 //MessageBox.Show(dr[0].ToString()+ " " + SelectedContractorSuburbType);
                // MessageBox.Show(SkillColRows.Rows.Count.ToString());
                if (dr[0].ToString().Equals(SelectedContractorSuburbType))
                {
                    DataRow dr1 = SuburbColRows.NewRow();
                    dr1[0] = dr[0];
                    dr1[1] = dr[1];
                    //  PreferredSuburbColRows.Rows.Add(dr1);
                    SuburbColRows.Rows.Add(dr1);
                    dr.Delete();

                }

            }
            PreferredSuburbColRows.AcceptChanges();
            SuburbColRows.AcceptChanges();
            MessageBox.Show("Suburb Removed", "Remove Contractor Preferred Suburb", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
        

    }
}
