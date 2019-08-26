using System;
using System.Collections.Generic;
using System.Linq;
using BitServices.Commands;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using System.ComponentModel;

namespace BitServices.Model
{
    class Person : NotificationClass, IDataErrorInfo
    {
        public string Error { get { return null; } }
        private string firstName;
        private string lastName;
        private string street;
        private string suburb;
        private string state;
        private string gender;
        private DateTime dOB;
        private string status;
        private string postCode;
        private string email;
        private string mobileNumber;
        //public string this[string name]
        //{
        //    string result = null;
        //        switch(name)
        //        {
        //            case "FirstName":
        //                if(String.IsNullOrWhiteSpace(Firstname))
            
        //                {
        //                    MessageBox.Show
        //                }       
        //            break;

        //        }
        //}   
    
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!Regex.Match(value, "^[a-zA-Z\\s\\,]*$").Success && string.IsNullOrEmpty(firstName))
                {
                    MessageBox.Show("Not a valid First Name");

                    return;
                }
                else
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {

            get { return lastName; }
            set
            {
                if (!Regex.Match(value, "^[a-zA-Z\\s\\,]*$").Success && String.IsNullOrEmpty(lastName))
                {
                    MessageBox.Show("Not a valid Last Name");

                    return;
                }
                else
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string Street
        {

            get { return street; }
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }
        public string Suburb
        {

            get { return suburb; }
            set
            {
                //if (!Regex.Match(value, "^[a-zA-Z\\s\\,]*$").Success)
                //{
                //    MessageBox.Show("Please enter valid Suburb Name");
                //    return;
                //}
                //else
                //{
                    suburb = value;
                    OnPropertyChanged("Suburb");
               // }
            }
        }
        public string State
        {
            get { return state; }
            set
            {
                //if (!Regex.Match(value, "[a-zA-Z]{2,3}$").Success)
                //{
                //    MessageBox.Show("State not in the correct format!");
                //    return;
                //}
                //else
                //{
                    state = value;
                    OnPropertyChanged("State");
               // }
                    
            }
        }
        public string PostCode
        {

            get { return postCode; }
            set
            {
               
                {
                    postCode = value;
                    OnPropertyChanged("Postcode");
                }
            }
        }
        //public string LicNum
        //{

        //    get { return licNum; }
        //    set
        //    {
        //        licNum = value;
        //        OnPropertyChanged("LicNum");
        //    }
        //}

        public string Email
        {

            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        //private string  Gender;

        public string  Gender
        {
            get { return gender; }
            set { gender = value;
                OnPropertyChanged("Gender");
            }
        }

   //     private string status;

        public string Status
        {
            get { return status; }
            set { status = value;
                OnPropertyChanged("Status");
            }
        }

    //    private DateTime DOB;

        public DateTime DOB
        {
            get { return dOB; }
            set {
                dOB = value;
                OnPropertyChanged("DOB");
            }
        }

        public string MobileNumber
        {

            get { return mobileNumber; }
            set
            {
               

                // if (value.Length == 0)
                //{
                //    MessageBox.Show("Phone number must be entered !");
                //    return;
                //}

                //if ((!Regex.Match(value, "^0[0-9]{9}$").Success
                //  )  && (value.Length >= 10))
                //{
                //    //Regex.Match(value, "^[a-zA-Z\\s\\,]*$").Success)
                //    //Something here in terms of exception handling
                //    MessageBox.Show("Phone number is in invalid format ! " + value);
                //    return;
                //}
                //else
                //{
                    mobileNumber = value;

                    OnPropertyChanged("MobileNumber");
               }
            
        }
        private string userName;

        public string UserName
        {
            // get { return string.Format("{0}{1}", this.FirstName, this.UserID); }
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");

            }
        }

        public string this[string columnName] => throw new NotImplementedException();
    }

}
