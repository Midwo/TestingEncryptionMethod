using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WCFTestEncryptionMethod
{
    public class ConMsSQL
    {

        private string sqlcon = WCFTestEncryptionMethod.Properties.Settings.Default.conMsSQL;

        public DataSet sqldata(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(sqlcon))
            {
                connection.Open();

                SqlDataAdapter adp = new SqlDataAdapter(cmd, connection);

                DataSet ds = new DataSet();

                try
                {
                    adp.Fill(ds);
                }
                catch
                {
                    connection.Close();
                    return ds;
                }
                connection.Close();
                return ds;
            }
        }

        public void sqlcommand(string cmd)
        {
            //using (SqlConnection connection = new SqlConnection(sqlcon))
            //{

            //    SqlCommand command = new SqlCommand(cmd, connection);
            //    command.CommandTimeout = 120;
            //    command.Connection.Open();
            //    command.ExecuteNonQuery();

            //}
            using (SqlConnection connection = new SqlConnection(sqlcon))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmd, connection);
                command.CommandTimeout = 1;
                command.ExecuteNonQuery();

            }

        }
    }
}