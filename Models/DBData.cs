using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //Provider
using System.Data; //DataSet, DataTable
using System.Configuration;

namespace MVCDemoAppJLT.Models
{
    public class DBData
    {
        SqlConnection connection;
        public DBData()
        {
            //connection = new SqlConnection(@"server=MVC\SQLEXPRESS;database=TRAINING;integrated security=true;");
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        }
        //Connected
        public List<Employee> ConnectedDemo()
        {
            try
            {
                String sql = "Select EmpNo,Ename,Sal from emp";
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
                    employee.EmpName = reader["Ename"].ToString();
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
            public List<Department> DisconnectedDemo()
            {
                try
                {
                    string sql = "Select * from dept";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds, "dept");

                    List<Department> departmentList = new List<Department>();
                    foreach (DataRow row in ds.Tables["dept"].Rows)
                    {
                        Department department = new Department();
                        department.DeptNo = row["deptno"] as int?;
                        department.DeptName = row["dname"].ToString();
                        department.Location = row["loc"].ToString();

                        departmentList.Add(department);
                    }
                    return departmentList;
                }
                catch (Exception)
                {
                    throw;

                }
            }

        }
    }
