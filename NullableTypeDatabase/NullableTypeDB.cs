using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NullableTypeDatabase
{
    public class NullableTypeDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\faithnielsen\documents\visual studio 2013\Projects\NullableTypeDatabase\NullableTypeDatabase\EmployeeInfo.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            return connection;

        }


        public static int AddNewEmployee(string fname, string lname, int? maritalStat, int? age)
        {

            int returnAffectedRow;
            
            SqlConnection con = GetConnection();
            string queryStatement = "INSERT INTO Employee(firstname, lastname, married, age) VALUES (@fname, @lname, @maritalStat, @age)";
            SqlCommand sqlCmd = new SqlCommand(queryStatement, con);
            sqlCmd.Parameters.AddWithValue("@fname", fname);
            sqlCmd.Parameters.AddWithValue("@lname", lname);

            if(maritalStat == 0)
            {
                string convertIndex0 = "True";
                sqlCmd.Parameters.AddWithValue("@maritalStat", convertIndex0);
            }

            else if (maritalStat == 1)
            {
                string convertIndex1 = "False";
                sqlCmd.Parameters.AddWithValue("@maritalStat", convertIndex1);
            }

            else
            {
                sqlCmd.Parameters.AddWithValue("@maritalStat", DBNull.Value);
            }



            if (age.Value == 0)
            {
                sqlCmd.Parameters.AddWithValue("@age", DBNull.Value);
            }
            else
            {
                sqlCmd.Parameters.AddWithValue("@age", age.Value);
            }
      
            try
            {
                con.Open();
               returnAffectedRow = sqlCmd.ExecuteNonQuery();
    
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return returnAffectedRow;
        }



        public static List<Employee> GetEmployees()
        {
            List<Employee> empListToReturn = new List<Employee>();
            SqlConnection conn = GetConnection();
            string queryStatment = "SELECT firstname, lastname, age FROM Employee";
            SqlCommand sqlCmd = new SqlCommand(queryStatment, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.FirstName = reader[0].ToString();
                    emp.LastName = reader[1].ToString();

                    if (reader["age"] == DBNull.Value)
                        emp.Age = null;
                    else
                        emp.Age = Convert.ToInt32(reader["age"]);

  
        
                  //emp.Married = (reader["married"]);

                    empListToReturn.Add(emp);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return empListToReturn;

        }


        public int? ReplaceNull(int? value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return value;
            }
        }
  
    }
}
