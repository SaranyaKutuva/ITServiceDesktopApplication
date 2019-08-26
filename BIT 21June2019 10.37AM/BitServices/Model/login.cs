using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BitServices.Commands;

namespace BitServices.Model
{
    public class login : NotificationClass
    {
        private string userName;
        private string password;
        private string accountType;
        public string UserName
        {
            get { return userName; }
            set
            {
                /* if (string.IsNullOrEmpty(userName))
                 {
                     MessageBox.Show("UserName Cannot be Empty");
                     return;
                 }
                 else*/
                //{
                userName = value;
                OnPropertyChanged("UserName");
                // }
            }
        }
        public string Password { get; set; }
        public string AccountType { get; set; }

        public login()
        {

        }
        public login(DataRow drUser)
        {
            MapUserProperties(drUser);
        }

        private void MapUserProperties(DataRow drUser)
        {
            this.userName = drUser["UserName"].ToString();
            this.password = drUser["Password"].ToString();
            this.accountType = drUser["account_Type"].ToString();
        }
        public string Check(string givenpassword)
        {

            DAL dal = new DAL();
            //DataTable dt = dal.Read("Select * from bit_user_logon where bit_user_logon.account_Type in ('Admin','Coordinator') and UserName = " + this.userName + "and Password =" + this.password);
           // MessageBox.Show("User Name " + this.UserName +  " password " + this.Password);
            DataTable dt = dal.Read("select account_Type from bit_user_logon where UserName = '" + this.UserName + "' and Password = '" + givenpassword + "' and User_Status='ACTIVE'" );
            //MessageBox.Show(dt.Rows[0]["account_Type"].ToString());
            string acccountType ="None";
            foreach (DataRow dr in dt.Rows)
            {
                //MessageBox.Show(" Account Type " + dr[0].ToString());
                // login login = new login(dr);
                //loginCollection.Add(login);
                acccountType = dr[0].ToString();

            }
            

         //   DataRow dr = dt.NewRow();
         //    if(dr["account_Type"] == "ADMIN")
         //        return 1;
         //    else
         //        return 0;
         ////}
         //    if (dt.Rows.Equals("ADMIN"))

            //    else
            return acccountType;
        }
    }
  
}
