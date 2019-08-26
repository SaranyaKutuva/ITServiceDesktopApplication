
using BitServices.Commands;
using BitServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BitServices.ViewModel
{
    class SkillManagementViewModel  : NotificationClass

    {
        // This class is the communication class between your view(Skill Management.Xaml) and to your Model(Skill.cs)
        // Create a list that will generated from database
        private Skill skill;
        private DataTable skillColRows;
        private RelayCommand addRelay;
        private RelayCommand updateRelay;
        private RelayCommand deleteRelay;
        private RelayCommand searchRelay;

        private ObservableCollection<Skill> skillCollection  = new ObservableCollection<Skill>();



        public ObservableCollection<Skill> SkillCollection
        {
            get { return skillCollection; }
            set { skillCollection = value;
                OnPropertyChanged("SkillCollection");
            }
        }

        public DataTable SkillColRows
        {
            get { return skillColRows; }
            set
            {
                skillColRows = value;
                OnPropertyChanged("SkillColRows");
            }
        }
        //Constructor of this viewmodel
        private string selectedSkillCols;
        public string SelectedSkillCols
        {
            get { return selectedSkillCols; }
            set
            {
                selectedSkillCols = value;
            }
        }
        private string skillSearchString;
        public string SkillSearchString
        {
            get { return skillSearchString; }
            set
            {
                skillSearchString = value;
                OnPropertyChanged("SkillSearchString");
            }

        }
        private Boolean isEnabledAdd;
        public Boolean IsEnabledAdd
        {
            get { return isEnabledAdd; }
            set
            {
                isEnabledAdd = value;
                OnPropertyChanged("IsEnabledAdd");
            }
        }
        private Boolean isEnabledSave;
        public Boolean IsEnabledSave
        {
            get { return isEnabledSave; }
            set
            {
                isEnabledSave = value;
                OnPropertyChanged("IsEnabledSave");
            }
        }

        private Boolean isEnabledDelete;
        public Boolean IsEnabledDelete
        {
            get { return isEnabledDelete; }
            set
            {
                isEnabledDelete = value;
                OnPropertyChanged("IsEnabledDelete");
            }
        }
        public Skill SelectedSkill
        {
            get { return skill; }
            set { skill = value;
                OnPropertyChanged("SelectedSkill");
            }
        }
        // Constructor of this viewModel
        public SkillManagementViewModel()
        {
            // 1. Its goind to connect to DAL and bring in the results to all skills
            // 2. We create objects of type skill and then add that object to our collection

            DAL dal = new DAL();
            DataTable dt = dal.Read("Select * from bit_skill where (STATUS='ACTIVE' or status is null)");
            foreach (DataRow dr in dt.Rows)
            {
                Skill skill = new Skill(dr);
                SkillCollection.Add(skill);
            }
            LoadFieldNameCombo();
        }

        private void LoadFieldNameCombo()
        {
            try
            {
                DAL dal = new DAL();

                DataTable dtFieldNames = dal.Read("SELECT COLUMN_NAME FROM information_schema.columns WHERE table_schema='bit' AND table_name='bit_skill'and column_name not in ('Creation_Date', 'Created_By', 'Updated_By', 'Updated_Date', 'STATUS','Start_Date','End_Date')");


                //Map the database table field names (columns) to more human FRIENDLY names.
                //Define a new column object with the column name "FRIENDLY_NAMES"
                DataColumn colFriendlyNames = new DataColumn("FRIENDLY_NAMES", System.Type.GetType("System.String"));
                //Add our FRIENDLY_NAMES column to our DataTable.
                dtFieldNames.Columns.Add(colFriendlyNames);

                //  MessageBox.Show("Show data successful " + //"Patient");
                DataRow dtFieldNames1;
                dtFieldNames1 = dtFieldNames.NewRow();

                dtFieldNames1["FRIENDLY_NAMES"] = "--Select a Field--";
                dtFieldNames1["COLUMN_NAME"] = "0";
                dtFieldNames.Rows.InsertAt(dtFieldNames1, 0);

                foreach (DataRow dr in dtFieldNames.Rows)
                {

                    //Client client = new Client(dr);

                    //MessageBox.Show(" " + dr["COLUMN_NAME"]);

                    switch (dr[0].ToString())
                    {
                        case "Skill_Id":
                            dr[1] = "Skill Id";
                            break;
                        case "Skill_Type":
                            dr[1] = "Skill Type";
                            break;
                        default:
                            break;
                    }

                    skillColRows = dtFieldNames;
                    // ClientCols.Add(dr);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured loading the search field names. " + ex.Message);

            }
        }


       

        public RelayCommand Search
        {
            get { return new RelayCommand(SearchSkill, true); }


            set
            {
                searchRelay = value;
                OnPropertyChanged("SearchSkill");
            }

        }
        private void SearchSkill()
        {
            DAL dal = new DAL();

            /*for (int i = SkillCollection.Count - 1; i >= 0; i--)
            {

                SkillCollection.RemoveAt(i);

            }*/

            SkillCollection.Clear();

        DataTable dt = dal.Read("Select * from bit_skill  WHERE (STATUS='ACTIVE' OR STATUS IS NULL) and " + SelectedSkillCols + " like '%" + SkillSearchString + "%'");
            int i = 0;
            int index = 0;
            Skill skillFirstRecord = new Skill();
            foreach (DataRow dr in dt.Rows)
            {
                index = i;
                if (index == 0)
                {
                     skillFirstRecord = new Skill(dr);
                }

                Skill skill = new Skill(dr);                
                SkillCollection.Add(skill);
                i++;
            }
            SelectedSkill = skillFirstRecord;

             //MessageBox.Show(SelectedSkillCols + SkillSearchString);

        }

        public RelayCommand Save
        {
                get { return new RelayCommand(SaveSkill, true); }
            set { updateRelay = value;
                OnPropertyChanged("SaveSkill");
            }
        }
        private void SaveSkill()
        {
            //if (String.IsNullOrEmpty(SelectedSkill.Skill_ID.ToString()))
            //{
            //    MessageBox.Show("Please Enter First Name", "First Name Required", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}
            if (String.IsNullOrEmpty(SelectedSkill.SkillType)

            )
            {
                MessageBox.Show("Please Enter skill Type", "Skill Type Required", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (SelectedSkill.Skill_ID == 0)
            {
                try
                { 
                    SelectedSkill.Insert();
                    MessageBox.Show("Thank you!  The new Skill's details have been added to the Database.", "Skill", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {

                    MessageBox.Show("Something Went Wrong, But we Dont know what! Skill was not added to the database");
                }
              

            }
            else
            {
                try
                {
                    SelectedSkill.Update();
                    MessageBox.Show("The skill's details have been updated in the Database.", "Update Skill?", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An Error Occured, The Skill Details were not updated. Please Contact your System Administrator.","Update Skill?" + ex.Message );
                }
               
            }
            IsEnabledAdd = true;
            IsEnabledSave = true;
            IsEnabledDelete = true;
        }

        public RelayCommand Add
        {
            get { return new RelayCommand(AddSkill, true);}
            set {// new RelayCommand(AddSkill, true) = value;
                addRelay = value;
                OnPropertyChanged("AddSkill");

            }
        }
        public RelayCommand Delete
        {
            get { return new RelayCommand(DeleteSkill, true); }
            set
            {// new RelayCommand(AddSkill, true) = value;
                deleteRelay = value;
                OnPropertyChanged("DeleteSkill");

            }
        }
        private void AddSkill()
        {
            //SelectedSkill.Insert();
            Skill skill = new Skill();
            SkillCollection.Add(skill);
            SelectedSkill = skill;
            MessageBox.Show("Click Save button after entering the new skill.", "Skill", MessageBoxButton.OK, MessageBoxImage.Warning);
            IsEnabledAdd = false;
            IsEnabledSave = true;
            IsEnabledDelete = false;

        }

        private void DeleteSkill()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to PERMANENTLY delete the skill's details?", "Delete Skill?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                    SelectedSkill.Delete();
                    SkillCollection.Remove(SelectedSkill);
                    MessageBox.Show("Thank you!  The Skill's details have been deleted!", "Delete Skill?", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                else
                {
                    return;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured, The Skill Details have not been deleted. Please Contact your System Administrator.", "Delete Skill?" + ex.Message);

            }
           
        }
    }
}

