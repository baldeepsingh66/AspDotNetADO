using CrudApp.Utility;
using System.Data;
using System.Data.SqlClient;

namespace CrudApp.Models
{
    public class DataAccessLayer
    {
        string connectionSting = ConnectionString.CName;

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();

            using(SqlConnection conn = new SqlConnection(connectionSting))
            {
                SqlCommand cmd = new SqlCommand("select * from Employee", conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.FirstName = Convert.ToString(reader["FirstName"]);
                    emp.LastName = Convert.ToString(reader["LastName"]);
                    emp.FatherNames= Convert.ToString(reader["FatherNames"]);
                    emp.Department = Convert.ToString(reader["Department"]);
                    emp.MotherName= Convert.ToString(reader["MotherName"]);
                    emp.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    emp.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);

                    list.Add(emp);
                }
                conn.Close();
            }

            //using(SqlConnection conn = new SqlConnection(connectionSting))
            //{
            //    SqlCommand cmd= new SqlCommand("CrudEmployee", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    conn.Open();
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Employee employee = new Employee();
            //        employee.Id = Convert.ToInt32(reader["Id"]);
            //        employee.FirstName = Convert.ToString(reader["FirstName"]);
            //        employee.LastName = Convert.ToString(reader["LastName"]);
            //        employee.Department = Convert.ToString(reader["Department"]);
            //        employee.Salary = Convert.ToDouble(reader["Salary"]);
            //        employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            //        employee.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
            //        employee.FatherNames = Convert.ToString(reader["FatherNames"]);
            //        //employee.DepartmentId = Convert.ToInt32(reader["DepartmentId"]==null?0: reader["DepartmentId"]);
            //        employee.MotherName = Convert.ToString(reader["MotherName"]);
            //        list.Add(employee);
            //    }
            //    conn.Close();
            //}
            return list;
        }

        public int AddEmployee(Employee input)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionSting))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", input.Id);
                cmd.Parameters.AddWithValue("@FirstName", input.FirstName);
                cmd.Parameters.AddWithValue("@LastName", input.LastName);
                cmd.Parameters.AddWithValue("@Department", input.Department);
                cmd.Parameters.AddWithValue("@Salary", input.Salary);
                cmd.Parameters.AddWithValue("@DateOfBirth", input.DateOfBirth);
                cmd.Parameters.AddWithValue("@IsDeleted", false);
                cmd.Parameters.AddWithValue("@FatherNames", input.FatherNames);
                cmd.Parameters.AddWithValue("@DepartmentId", 2);
                cmd.Parameters.AddWithValue("@MotherName", input.MotherName);


                conn.Open();
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return result;            
        }
    }
}
