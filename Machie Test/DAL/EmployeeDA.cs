using Machie_Test.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Machie_Test.DAL
{
    public class EmployeeDA
    {
        public List<Employee> EmployeeGet() {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sSQL = $@"SELECT * FROM Employee;";
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sSQL, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Email = rdr["Email"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.Desgination = rdr["Desgination"].ToString();
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public void EmployeeDelete(int id)
        {
            string sql = @"DELETE FROM Employee WHERE ID="+id+";";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            
        }
    }
}