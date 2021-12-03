using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



namespace MVCDemoAppJLT.Models
{
    public class EmpDataStore
    {
        SqlConnection connection;
        public EmpDataStore()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);



        }
        public List<Employee> GetEmployee()
        {
            try
            {
                string sql = "select Empno,Ename,Sal from emp";
                SqlCommand command = new SqlCommand(sql, connection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = command.ExecuteReader();
                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmpId = reader["EmpNo"] as int?;
                    employee.EmpName = reader["EName"].ToString();
                    employee.Salary = reader["Sal"] as decimal?;
                    employees.Add(employee);



                }
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public Employee GetEmployeeById(int id)
        {
            try
            {
                string sql = "select * from emp where empno= @eno";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@eno", id);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataReader reader = command.ExecuteReader();
                Employee employee = null;
                if (reader.Read())
                {
                    employee = new Employee();
                    employee.EmpId = reader["EmpNo"] as int?;
                    employee.EmpName = reader["EName"].ToString();
                    employee.Salary = reader["Sal"] as decimal?;

                }
                return employee;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public int AddEmployee(Employee employee)
        {
            try
            {
                string sql = "insert into emp(empno, ename, sal) values(@eno, @ename, @esal)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("eno", employee.EmpId);
                command.Parameters.AddWithValue("ename", employee.EmpName);
                command.Parameters.AddWithValue("esal", employee.Salary);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                int count = command.ExecuteNonQuery();
                return count;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public int UpdateEmployee(Employee employee)
        {
            try
            {
                string sql = "update emp set ename=@ename,sal=@esal where empno = @eno";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("eno", employee.EmpId);
                command.Parameters.AddWithValue("ename", employee.EmpName);
                command.Parameters.AddWithValue("esal", employee.Salary);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                int count = command.ExecuteNonQuery();
                return count;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public int DeleteEmployee(Employee employee)
        {
            try
            {
                string sql = "delete from emp where empno = @eno";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("eno", employee.EmpId);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                int count = command.ExecuteNonQuery();
                return count;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
    }
}