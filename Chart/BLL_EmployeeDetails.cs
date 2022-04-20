using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Chart
{
    public class BLL_EmployeeDetails
    {
        public static string connectionstring()
        {
            string cstr = string.Empty;
            cstr = ConfigurationManager.ConnectionStrings["myConnectionstring"].ConnectionString;
            return cstr;
        }

        public DataTable GetStates()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter sqlDa = null;
            DataTable dtStates = null;

            using (connection = new SqlConnection(connectionstring()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_GetStates";
                sqlDa = new SqlDataAdapter(command);
                dtStates = new DataTable();
                sqlDa.Fill(dtStates);
            }
            return dtStates;
        }

        public DataTable GetEmployeeDetails(string state)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter sqlDa = null;
            DataTable dtEmployees = null;

            using (connection = new SqlConnection(connectionstring()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_GetEmployeesByState";
                command.Parameters.Add("@State",SqlDbType.VarChar).Value = state;
                sqlDa = new SqlDataAdapter(command);
                dtEmployees = new DataTable();
                sqlDa.Fill(dtEmployees);
            }
            return dtEmployees;
        }
    }
}