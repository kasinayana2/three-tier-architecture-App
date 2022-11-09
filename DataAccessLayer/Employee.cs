using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BusinessObjects;

namespace DataAccessLayer
{
    public class Employee
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public int SaveEmp(BusinessObjects.Employee objemp)
        {
            con.Open();
            SqlCommand com = new SqlCommand("uspInsertEmployee", con);           
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@GenderId", objemp.GenderId);
            com.Parameters.AddWithValue("@CountryId", objemp.CountryId);
            com.Parameters.AddWithValue("@HobbyId", objemp.HobbyId);
            com.Parameters.AddWithValue("@EmployeeName", objemp.EmployeeName);
            com.Parameters.AddWithValue("@MobileNumber", objemp.MobileNumber);
            com.Parameters.AddWithValue("@Email", objemp.Email);
            com.Parameters.AddWithValue("@DateOfJoin", objemp.DateOfJoin);            
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int DeleteEmp(BusinessObjects.Employee objemp)
        {
            con.Open();
            SqlCommand com = new SqlCommand("uspDeleteEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", objemp.EmployeeId);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int UpdateEmp(BusinessObjects.Employee objemp)
        {
            con.Open();
            SqlCommand com = new SqlCommand("uspUpdateEmployeeById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", objemp.EmployeeId);
            com.Parameters.AddWithValue("@GenderId", objemp.GenderId);
            com.Parameters.AddWithValue("@CountryId", objemp.CountryId);
            com.Parameters.AddWithValue("@HobbyId", objemp.HobbyId);
            com.Parameters.AddWithValue("@EmployeeName", objemp.EmployeeName);
            com.Parameters.AddWithValue("@MobileNumber", objemp.MobileNumber);
            com.Parameters.AddWithValue("@Email", objemp.Email);
            com.Parameters.AddWithValue("@DateOfJoin", objemp.DateOfJoin);
            //com.Parameters.AddWithValue("@DatePublished", objemp.DatePublished);
            //com.Parameters.AddWithValue("@DateCreated", objemp.DateCreated);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataSet GetEmp()
        {
            SqlDataAdapter da = new SqlDataAdapter("uspGetEmployee", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"emp");
            return ds;
        }      
    }
}
