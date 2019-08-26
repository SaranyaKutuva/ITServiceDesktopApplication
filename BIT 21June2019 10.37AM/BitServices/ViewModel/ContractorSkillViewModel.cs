using System;
using System.Collections.Generic;
using System.Linq;
using BitServices.Model;
using BitServices.View;
using System.Data;
using System.Text;
using BitServices.Commands;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace BitServices.ViewModel
{
    class ContractorSkillViewModel : NotificationClass
    {
        Contractor contractor = new Contractor();
        private ContractorSkill contractorSkill;
        private RelayCommand addRelay;
    //    private RelayCommand updateRelay;
        private RelayCommand deleteRelay;
        private ObservableCollection<ContractorSkill> contractorSkillCollection = new ObservableCollection<ContractorSkill>();

        public ObservableCollection<ContractorSkill> ContractorSkillCollection
        {
            
            get { return contractorSkillCollection; }
            set
            {
                contractorSkillCollection = value;
                OnPropertyChanged("ContractorSkillCollection");
            }
        }
        public ContractorSkill SelectedContractorSkill
        {
            get { return contractorSkill; }
            set
            {
                contractorSkill = value;
                OnPropertyChanged("SelectedContractorSkill");
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

        public ContractorSkillViewModel(string ContractorId)
        {
            try
            {
               
                DAL dal = new DAL();
                // we will pass sql to the database
                //DataTable dtfieldNames = dal.Read("select  bit_skill.Skill_Id,bit_skill.Skill_Type from bit_contractor_skill,bit_skill WHERE bit_contractor_skill.Skill_Id = bit_skill.Skill_Id and Contractor_Id = 2");
                DataTable dtfieldNames = dal.Read("select  bit_contractor_skill.Skill_Id as Skill_Id,bit_skill.Skill_Type as Skill_Type from bit_contractor_skill,bit_skill WHERE bit_contractor_skill.Skill_Id = bit_skill.Skill_Id and Contractor_Id = "+ ContractorId);
                PassedContractorId = Convert.ToInt32(ContractorId);

                // Add a message to the combobox for the user to select an Client
              //  DataRow dtfieldNames1;
                //This is not putting our DataRow into the  DataTable. Its just 'copying' the schema of the table to our row.
              //  dtfieldNames1 = dtfieldNames.NewRow();

               // dtfieldNames1["Skill_Id"] = "0";
              //  dtfieldNames1["Skill_Type"] = "-- Select a Skill Type--"; // Here We're 'inserting' the message into that column of the row
               // dtfieldNames.Rows.InsertAt(dtfieldNames1, 0);
                contractorSkillColRows = dtfieldNames;
                foreach (DataRow dr in dtfieldNames.Rows)
                {
                     
                    ContractorSkill skill = new ContractorSkill(dr);
                    ContractorSkillCollection.Add(skill);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not Load Contractor Skill", "Loading Skill" + ex.Message);
            }


            LoadSkillTypeList();

         
        }
        private void LoadSkillTypeList()
        {
            try
            {
                DAL dal = new DAL();
                // we will pass sql to the database
                DataTable dtfieldNames = dal.Read("Select Skill_Id,Skill_Type from bit_Skill where (STATUS != 'INACTIVE' or STATUS is NULL) and skill_id not in (select skill_id from bit_contractor_skill where contractor_id = "+ PassedContractorId+")");

                // Add a message to the combobox for the user to select an Client
              //  DataRow dtfieldNames1;
                //This is not putting our DataRow into the  DataTable. Its just 'copying' the schema of the table to our row.
             //   dtfieldNames1 = dtfieldNames.NewRow();
              
              //  dtfieldNames1["Skill_Id"] = "0";
              //  dtfieldNames1["Skill_Type"] = "-- Select A Skill Type --"; // Here We're 'inserting' the message into that column of the row
              //  dtfieldNames.Rows.InsertAt(dtfieldNames1, 0);
               skillColRows = dtfieldNames;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not Load Contractor Skill" ,"Loading Contractor Skill"+ ex.Message);
            }
        }

        private DataTable skillColRows;

        public DataTable SkillColRows
        {
            get { return skillColRows; }
            set
            {
                skillColRows = value;
                OnPropertyChanged("SkillColRows");
            }
        }
        private DataTable contractorSkillColRows;

        public DataTable ContractorSkillColRows
        {
            get { return contractorSkillColRows; }
            set
            {
                contractorSkillColRows = value;
                OnPropertyChanged("ContractorSkillColRows");
            }
        }
        private string selectedSkillType;
        public string SelectedSkillType
        {
            get { return selectedSkillType; }
            set
            {
                selectedSkillType = value;
                OnPropertyChanged("SelectedSkillType");
            }
        }
        private string selectedContractorSkillType;
        public string SelectedContractorSkillType
        {
            get { return selectedContractorSkillType; }
            set
            {
                selectedContractorSkillType = value;
                OnPropertyChanged("SelectedContractorSkillType");
            }
        }

     
        public RelayCommand Add
        {
            get { return new RelayCommand(AddContractorSkill, true); }
            set
            {
                addRelay = value;
                OnPropertyChanged("AddContractorSkill");
            }
        }
        private void AddContractorSkill()
        {
           

            ContractorSkillColRows.AcceptChanges();
            SkillColRows.AcceptChanges();
            SelectedContractorSkill = new ContractorSkill();
            SelectedContractorSkill.Insert(PassedContractorId, SelectedSkillType);
            foreach (DataRow dr in SkillColRows.Rows)
            {
                // MessageBox.Show(dr[0].ToString()+ " " + SelectedSkillType);
               // MessageBox.Show(SkillColRows.Rows.Count.ToString());
                if (dr[0].ToString().Equals(SelectedSkillType))
                {
                   DataRow dr1 = ContractorSkillColRows.NewRow();
                    dr1[0] = dr[0];
                    dr1[1] =dr[1];
                    ContractorSkillColRows.Rows.Add(dr1);
                    //SkillColRows.Rows.Remove(dr);
                    dr.Delete();
                    
                }

            }
            ContractorSkillColRows.AcceptChanges();
            SkillColRows.AcceptChanges();
            MessageBox.Show("Skill Added", "Add Contractor Skill", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
        public RelayCommand Delete
        {
            get { return new RelayCommand(DeleteContractorSkill, true); }
            set
            {
                deleteRelay = value;
                OnPropertyChanged("DeleteContractorSkill");
            }
        }

   
        private void DeleteContractorSkill()
        {
            ContractorSkillColRows.AcceptChanges();
            SkillColRows.AcceptChanges();

            SelectedContractorSkill = new ContractorSkill();
            SelectedContractorSkill.Delete(PassedContractorId, SelectedContractorSkillType);
            foreach (DataRow dr in ContractorSkillColRows.Rows)
            {
               // MessageBox.Show(dr[0].ToString()+ " " + SelectedContractorSkillType);
                // MessageBox.Show(SkillColRows.Rows.Count.ToString());
                if (dr[0].ToString().Equals(SelectedContractorSkillType))
                {
                    DataRow dr1 = SkillColRows.NewRow();
                    dr1[0] = dr[0];
                    dr1[1] = dr[1];
                    SkillColRows.Rows.Add(dr1);
                    //SkillColRows.Rows.Remove(dr);
                    dr.Delete();

                }

            }
            ContractorSkillColRows.AcceptChanges();
            SkillColRows.AcceptChanges();
            MessageBox.Show("Skill Removed", "Remove Contractor Skill", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}

