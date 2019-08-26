using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BitServices.Model
{
    class DAL
    {
        MySqlConnection conn;
        private void ConnectDB()
        {
            //databse connection string from app.configuration
          
            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            conn = new MySqlConnection(connString);
        }
        public int Update(string queryStr)
        {
            try
            {
                ConnectDB();
                MySqlCommand updatecmd = new MySqlCommand(queryStr, conn);
                updatecmd.Connection.Open();
                int rowsaffected = updatecmd.ExecuteNonQuery();
                updatecmd.Connection.Close();
                return rowsaffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;

            }
            
        }
        public int Insert(string queryStr)
        {
            ConnectDB();
            MySqlCommand insertcmd = new MySqlCommand(queryStr, conn);

            insertcmd.Connection.Open();            
            int rowsaffected =insertcmd.ExecuteNonQuery();
            insertcmd.Connection.Close();
            return rowsaffected;
        }

        public int InsertUpdateDeleteSP(string sql, MySqlParameter[] parameters)
        {
            ConnectDB();
            MySqlCommand insertcmd = new MySqlCommand(sql, conn);
            FillParameters(insertcmd, parameters);
            insertcmd.CommandType = CommandType.StoredProcedure;
            insertcmd.Connection.Open();
            // insertcmd.Parameters.Add(parameters);
            int rowsaffected =insertcmd.ExecuteNonQuery();
            insertcmd.Connection.Close();
            return rowsaffected;
        }

        public int InsertSP (string sql, MySqlParameter[] parameters)
        {
            ConnectDB();
            MySqlCommand insertcmd = new MySqlCommand(sql, conn);
            FillParameters(insertcmd, parameters);
            insertcmd.CommandType = CommandType.StoredProcedure;
            insertcmd.Connection.Open();           
           // insertcmd.Parameters.Add(parameters);
            int rowaffected = insertcmd.ExecuteNonQuery();
            insertcmd.Connection.Close();
            return rowaffected;

        }

        private void FillParameters(MySqlCommand cmd, MySqlParameter[] parameters)
        {
            //Loop through the parameters and add each one to the command object's parameter collection.
            //for(int i=0;i<parameters.Length; i++)
            //{
            //    cmd.Parameters.Add(parameters[i]);
            //}
            // this is an easier way to do the above
            foreach (MySqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
        }

        public int Delete(string queryStr)
        {
            try
            {
                ConnectDB();
                MySqlCommand updatecmd = new MySqlCommand(queryStr, conn);
                updatecmd.Connection.Open();
                int rowsaffected = updatecmd.ExecuteNonQuery();
                updatecmd.Connection.Close();
                return rowsaffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;

            }

        }
        public DataTable Read(string queryString)
        {
            //open connection
           
                ConnectDB();
                MySqlCommand cmd = new MySqlCommand(queryString, conn);
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                return dt;

          
        }
    }
}
