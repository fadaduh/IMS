using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public static DataTable SelectData(string query, List<SqlParameter> param)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);

            SqlCommand command = new SqlCommand(query, connection);
            foreach (SqlParameter p in param)
            {
                command.Parameters.Add(p);
            }

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        public static int NonQuery(string query, List<SqlParameter> param)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);

            SqlCommand command = new SqlCommand(query, connection);
            foreach (SqlParameter p in param)
            {
                command.Parameters.Add(p);
            }

            connection.Open();
            int x = command.ExecuteNonQuery();
            connection.Close();

            return x;
        }

    }
}
