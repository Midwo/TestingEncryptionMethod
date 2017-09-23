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
                    return ds;
                }
                return ds;
            }
        }

        public void sqlcommand(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(sqlcon))
            {
                SqlCommand command = new SqlCommand(cmd, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}