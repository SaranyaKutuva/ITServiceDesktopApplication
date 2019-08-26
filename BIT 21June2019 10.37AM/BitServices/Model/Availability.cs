using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BitServices.Commands;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Windows.Controls;

namespace BitServices.Model
{
    class Availability : Contractor
    {
        //CultureInfo myCI = new CultureInfo("en-US");
        //Calendar myCal = myCI.Calendar;

        private int availID;
        public int AvailID
        {
            get { return availID; }
            set
            {
                availID = value;
                OnPropertyChanged("AvailID");
            }
        }
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                
               // DayOfWeek SelectedDate = StartDate.Date.;
                //DatePicker datePicker = StartDate as DatePicker;
                //if (datePicker.SelectedDate.Value.DayOfWeek != DayOfWeek.Monday)
                //{
                //    DateTime selectedDate = new DateTime(datePicker.SelectedDate.Value.Year,
                //        datePicker.SelectedDate.Value.Month, datePicker.SelectedDate.Value.Day);
                //    int mondayGap = DayOfWeek.Monday - datePicker.SelectedDate.Value.DayOfWeek;

                //    if (mondayGap > 0)
                //    {
                //        selectedDate = selectedDate.AddDays(mondayGap);
                //        MessageBox.Show("Not a Monday!");
                //        datePicker.SelectedDate = selectedDate;
                //    }
                //    if (mondayGap < 0)
                //    {
                //        selectedDate = selectedDate.AddDays(7 + mondayGap);
                //        MessageBox.Show("Not a Monday!");
                //        datePicker.SelectedDate = selectedDate;
                //    }
                //}
                //else
                {
                    startDate = value;
                    OnPropertyChanged("StartDate");
                }
                
            }
        }
        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                //int diff = (int)(EndDate - StartDate).TotalDays;
                //if (EndDate < StartDate || diff>7)
                //{
                //    MessageBox.Show("Date not in Correct Format");
                //    return;
                //}
                //else
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }
        private bool monday;
        public bool Monday
        {
            get { return monday; }
            set
            {
                monday = value;
                OnPropertyChanged("Monday");
            }
        }

      

        private bool tuesday;
        public bool Tuesday
        {
            get { return tuesday; }
            set
            {
                tuesday = value;
                OnPropertyChanged("Tuesday");
            }
        }

        private bool wednesday;
        public bool Wednesday
        {
            get { return wednesday; }
            set
            {
                wednesday = value;
                OnPropertyChanged("Wednesday");
            }
        }

        private bool thursday;
        public bool Thursday
        {
            get { return thursday; }
            set
            {
                thursday = value;
                OnPropertyChanged("Thursday");
            }
        }    

        
        private bool friday;
        public bool Friday
        {
            get { return friday; }
            set
            {
                friday = value;
                OnPropertyChanged("Friday");
            }
        }
        private bool saturday;
        public bool Saturday
        {
            get { return saturday; }
            set
            {
                saturday = value;
                OnPropertyChanged("Saturday");
            }
        }
        private bool sunday;
        public bool Sunday
        {
            get { return sunday; }
            set
            {
                sunday = value;
                OnPropertyChanged("Sunday");
            }
        }
        private TimeSpan mondayST;
        public TimeSpan MondayST
        {
            get { return mondayST; }
            set
            {
                //if (mondayST >= mondayET)
                //{
                //    MessageBox.Show("Incorrect Time");
                //    return;
                //}
                //else
                {
                    mondayST = value;
                    OnPropertyChanged("MondayST");
                }
            }
        }
        private TimeSpan mondayET;
        public TimeSpan MondayET
        {
            get { return mondayET; }
            set
            {
                //if (mondayET <= mondayST)
                //{
                //    MessageBox.Show("Wrong Input");
                //    return;
                //}
                //else
                //{
                    mondayET = value;
                    OnPropertyChanged("MondayET");
                //}
            }
        }
        private TimeSpan tuesdayST;
        public TimeSpan TuesdayST
        {
            get { return tuesdayST; }
            set
            {
                tuesdayST= value;
                OnPropertyChanged("TuesdayST");
            }
        }
            private TimeSpan tuesdayET;
            public TimeSpan TuesdayET
            {
                get { return tuesdayET; }
                set
                {
                    tuesdayET= value;
                    OnPropertyChanged("TuesdayET");
                }
            }
            private TimeSpan wednesdayST;
            public TimeSpan WednesdayST
        {
                get { return wednesdayST; }
                set
                {
                wednesdayST = value;
                    OnPropertyChanged("WednesdayST");
                }
            }
            private TimeSpan wednesdayET;
            public TimeSpan WednesdayET
            {
                get { return wednesdayET; }
                set
                {
                wednesdayET = value;
                    OnPropertyChanged("WednesdayET");
                }
            }
            private TimeSpan thursdayST;
            public TimeSpan ThursdayST
            {
                get { return thursdayST; }
                set
                {
                thursdayST = value;
                    OnPropertyChanged("ThursdayST");
                }
            }
            private TimeSpan thursdayET;
            public TimeSpan ThursdayET
            {
                get { return thursdayET; }
                set
                {
                thursdayET = value;
                    OnPropertyChanged("ThursdayET");
                }
            }
            private TimeSpan fridayST;
            public TimeSpan FridayST
        {
                get { return fridayST; }
                set
                {
                fridayST = value;
                    OnPropertyChanged("FridayST");
                }
            }
            private TimeSpan fridayET;
            public TimeSpan FridayET
        {
                get { return fridayET; }
                set
                {
                fridayET = value;
                    OnPropertyChanged("FridayET");
                }
            }
            private TimeSpan saturdayST;
            public TimeSpan SaturdayST
            {
                get { return saturdayST; }
                set
                {
                saturdayST = value;
                    OnPropertyChanged("SaturdayST");
                }
            }
            private TimeSpan saturdayET;
            public TimeSpan SaturdayET
            {
                get { return saturdayET; }
                set
                {
                saturdayET = value;
                    OnPropertyChanged("SaturdayET");
                }
            }
            private TimeSpan sundayST;
            public TimeSpan SundayST
            {
                get { return sundayST; }
                set
                {
                  sundayST = value;
                    OnPropertyChanged("SundayST");
                }
            }
            private TimeSpan sundayET;
            public TimeSpan SundayET
           {
                get { return sundayET; }
                set
                {
                    sundayET = value;
                     OnPropertyChanged("SundayET");
                }
            }

        public Availability() : base()
        {

        }
        public Availability(DataRow drAvail) : base()
        {
            MapAvailProperties(drAvail);
        }

        private void MapAvailProperties(DataRow drAvail)
        {
           // MessageBox.Show(StartDate.ToString());
            
            this.ContractorID = Convert.ToInt32(drAvail["Contractor_Id"].ToString());
            this.availID = Convert.ToInt32(drAvail["Availability_Id"].ToString());
            this.StartDate= (DateTime)drAvail["StartDate"];
            this.EndDate = (DateTime)drAvail["EndDate"];
            this.Monday = Convert.ToBoolean(drAvail["Monday"].ToString());// == "0" ? false : true;
            this.MondayST = (TimeSpan)drAvail["MondayStartTime"];
                this.MondayET = (TimeSpan)drAvail["MondayEndTime"];
            this.Tuesday = Convert.ToBoolean(drAvail["Tuesday"].ToString()); //== "0" ? false : true;
            this.TuesdayST = (TimeSpan)drAvail["TuesdayStartTime"]; 
                this.TuesdayET = (TimeSpan)drAvail["TuesdayEndTime"];
            this.Wednesday = Convert.ToBoolean(drAvail["Wednesday"].ToString());//== "0" ? false : true;
            this.WednesdayST = (TimeSpan)drAvail["WednesdayStartTime"];
                this.WednesdayET = (TimeSpan)drAvail["WednesdayEndTime"];
            this.Thursday = Convert.ToBoolean(drAvail["Thursday"].ToString());// == "0" ? false : true;
            this.ThursdayST = (TimeSpan)drAvail["ThursdayStartTime"];
                this.ThursdayET = (TimeSpan)drAvail["ThursdayEndTime"];
            this.Friday = Convert.ToBoolean(drAvail["Friday"].ToString()); //== //"0" ? false : true;
            this.FridayST = (TimeSpan)drAvail["FridayStartTime"];
                this.FridayET = (TimeSpan)drAvail["FridayEndTime"];
            this.Saturday = Convert.ToBoolean(drAvail["Saturday"].ToString());// == //"0" ? false : true;
            this.SaturdayST = (TimeSpan)drAvail["SaturdayStartTime"];
                this.SaturdayET = (TimeSpan)drAvail["SaturdayEndTime"];
            this.Sunday = Convert.ToBoolean(drAvail["Sunday"].ToString()); //== "0" ? false : true;
            this.SundayST = (TimeSpan)drAvail["SundayStartTime"];
                this.SundayET = (TimeSpan)drAvail["SundayEndTime"];

            /*
             Updated_Date
              Created_By
              Updated_By
              Creation_Date

             */
             
        }
        public int insert(int contractorId)
        {
          //MessageBox.Show(contractorId.ToString());
           
            try
            {
                DAL dal = new DAL();
                int rowsAffected = 0;
                //   MessageBox.Show(" Insert " + StartDate.ToString());

                /*   objDal.Insert("insert into bit_contractor_availability(Contractor_Id,StartDate,EndDate,Monday,MondayStartTime,MondayEndTime,Tuesday,TuesdayStartTime,TuesdayEndTime,Wednesday,WednesdayStartTime,WednesdayEndTime,Thursday,ThursdayStartTime,ThursdayEndTime,Friday,FridayStartTime,FridayEndTime,Saturday,SaturdayStartTime,SaturdayEndTime,Sunday,SundayStartTime,SundayEndTime)Values("+contractorId+",'10/06/2019','"+this.EndDate+"',"+this.monday+",'"+this.MondayST+"','"+this.MondayET+"',"+this.tuesday+",'"+this.TuesdayST+ "','" + this.TuesdayET + "',"+this.wednesday+",'" + this.WednesdayST + "','" + this.WednesdayET + "',"+this.thursday+",'" + this.ThursdayST + "','" + this.ThursdayET + "',"+this.friday+",'" + this.FridayST + "','" + this.FridayET + "',"+this.saturday+",'" + this.SaturdayST + "','" + this.SaturdayET + "',"+this.sunday+",'" + this.SundayST + "','" + this.SundayET + "')");*/
               /* MessageBox.Show("SELECT  1 from bit_contractor_availability where Contractor_Id = " + contractorId + " AND EXISTS (SELECT 1 from bit_contractor_availability where Contractor_Id = " + contractorId + " and (STR_TO_DATE('" + this.StartDate + "','%d/%m/%Y %H:%i:%s') between StartDate and EndDate  or STR_TO_DATE('" + this.EndDate + "','%d/%m/%Y %H:%i:%s')   between StartDate and End Date))");*/
                DataTable dt = dal.Read("SELECT  1 from bit_contractor_availability where Contractor_Id = " + contractorId + " AND EXISTS (SELECT 1 from bit_contractor_availability where Contractor_Id = " + contractorId + " and (STR_TO_DATE('" + this.StartDate + "','%d/%m/%Y %H:%i:%s') between StartDate and EndDate  or STR_TO_DATE('" + this.EndDate + "','%d/%m/%Y %H:%i:%s')   between StartDate and EndDate))");
                int overlapExists = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    overlapExists = 1;
                }
                if (overlapExists == 0)
                {
                    string SPName = "BitInsertUpdateDeleteAvailability";

                    MySqlParameter[] parameters =
                        {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Availability_Id1",""),
                    new MySqlParameter("@Contractor_Id1",  contractorId),
                    new MySqlParameter("@StartDate1",this.StartDate),
                    new MySqlParameter("@EndDate1",this.EndDate),
                    new MySqlParameter("@Monday1",this.Monday),
                    new MySqlParameter("@MondayStartTime1",this.MondayST),
                    new MySqlParameter("@MondayEndTime1",this.MondayET),
                    new MySqlParameter("@Tuesday1",this.Tuesday),
                    new MySqlParameter("@TuesdayStartTime1",this.TuesdayST),
                    new MySqlParameter("@TuesdayEndTime1",this.TuesdayET),
                    new MySqlParameter("@Wednesday1",this.Wednesday),
                    new MySqlParameter("@WednesdayStartTime1",this.WednesdayST),
                    new MySqlParameter("@WednesdayEndTime1",this.WednesdayET),
                    new MySqlParameter("@Thursday1",this.Thursday),
                    new MySqlParameter("@ThursdayStartTime1",this.ThursdayST),
                    new MySqlParameter("@ThursdayEndTime1",this.ThursdayET),
                      new MySqlParameter("@Friday1",this.Friday),
                    new MySqlParameter("@FridayStartTime1",this.FridayST),
                    new MySqlParameter("@FridayEndTime1",this.FridayET),
                      new MySqlParameter("@Saturday1",this.Saturday),
                    new MySqlParameter("@SaturdayStartTime1",this.SaturdayST),
                    new MySqlParameter("@SaturdayEndTime1",this.SaturdayET),
                      new MySqlParameter("@Sunday1",this.Sunday),
                    new MySqlParameter("@SundayStartTime1",this.SundayST),
                    new MySqlParameter("@SundayEndTime1",this.SundayET),
                    new MySqlParameter("@Mode","INSERT"),
                };


                    rowsAffected = dal.InsertUpdateDeleteSP(SPName, parameters);
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Contractor Availability not be added to the database! ");
                    }
                } //if no overlap exists
                else
                {
                    rowsAffected = -100;
                }
                return rowsAffected;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
               throw new Exception("Something Wrong with Availability Insert" + ex.Message);
               // return 0;
            }
        }
        public int update(int contractorId)
        {
            /* try
             {
                 DAL objDal = new DAL();

                 objDal.Update("update bit_contractor_availability set Availability_Id = " + this.AvailID + ",StartDate = '" + this.StartDate +"', EndDate = '"+this.EndDate+"',Monday = "+this.Monday+", MondayStartTime = '"+this.MondayST+"', MondayEndTime = '"+this.MondayET+"',Tuesday = "+this.Tuesday+", TuesdayStartTime = '"+this.TuesdayST+"', TuesdayEndTime = '"+this.TuesdayET+"',Wednesday = "+this.Wednesday+", WednedayStartTime = '"+this.WednesdayST+"', WednesdayEndTime = '"+this.WednesdayET+"',Thursday = "+this.Thursday+", ThursdayStartTime = '"+this.ThursdayST+"', ThursdayEndTime = '"+this.ThursdayET+"',Friday = "+this.Friday+", FridayStartTime = '"+this.FridayST+"', FridayEndTime = '"+this.FridayET+"',Saturday = "+this.Saturday+", SaturdayStartTime = '"+this.SaturdayST+"', SaturdayEndTime = '"+this.SaturdayET+"',Sunday = '"+this.Sunday+"',, SundayStartTime = '"+this.SundayST+"',, SundayEndTime = '"+this.SundayET+"' where bit_contractor.Contractor_Id = this.ContractorID");
             }
             catch (Exception ex)
             {
                 throw new Exception("Something Wrong with AVailability" + ex.Message);
             }*/

            try
            {
                DAL dal = new DAL();
                int rowsAffected = 0;
               
               
                    string SPName = "BitInsertUpdateDeleteAvailability";

                    MySqlParameter[] parameters =
                        {
                   // new SqlParameter("@OldPatient_Id",this.Patient_Id),
                    new MySqlParameter("@Availability_Id1",this.AvailID),
                    new MySqlParameter("@Contractor_Id1",contractorId ),
                    new MySqlParameter("@StartDate1",this.StartDate),
                    new MySqlParameter("@EndDate1",this.EndDate),
                    new MySqlParameter("@Monday1",this.Monday),
                    new MySqlParameter("@MondayStartTime1",this.MondayST),
                    new MySqlParameter("@MondayEndTime1",this.MondayET),
                    new MySqlParameter("@Tuesday1",this.Tuesday),
                    new MySqlParameter("@TuesdayStartTime1",this.TuesdayST),
                    new MySqlParameter("@TuesdayEndTime1",this.TuesdayET),
                    new MySqlParameter("@Wednesday1",this.Wednesday),
                    new MySqlParameter("@WednesdayStartTime1",this.WednesdayST),
                    new MySqlParameter("@WednesdayEndTime1",this.WednesdayET),
                    new MySqlParameter("@Thursday1",this.Thursday),
                    new MySqlParameter("@ThursdayStartTime1",this.ThursdayST),
                    new MySqlParameter("@ThursdayEndTime1",this.ThursdayET),
                      new MySqlParameter("@Friday1",this.Friday),
                    new MySqlParameter("@FridayStartTime1",this.FridayST),
                    new MySqlParameter("@FridayEndTime1",this.FridayET),
                      new MySqlParameter("@Saturday1",this.Saturday),
                    new MySqlParameter("@SaturdayStartTime1",this.SaturdayST),
                    new MySqlParameter("@SaturdayEndTime1",this.SaturdayET),
                      new MySqlParameter("@Sunday1",this.Sunday),
                    new MySqlParameter("@SundayStartTime1",this.SundayST),
                    new MySqlParameter("@SundayEndTime1",this.SundayET),
                    new MySqlParameter("@Mode","UPDATE"),
                };


                    rowsAffected = dal.InsertUpdateDeleteSP(SPName, parameters);
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Contractor Availability not be updated to the database! ");
                    }
               
               return rowsAffected;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                throw new Exception("Something Wrong with Availability Insert" + ex.Message);
                // return 0;
            }

        }
    }

}
    
