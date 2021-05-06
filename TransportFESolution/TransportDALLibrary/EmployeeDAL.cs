using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TransportDALLibrary
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        string strConnection;

        public EmployeeDAL()
        {
            strConnection = "server=DESKTOP-87C5QHV;Integrated security=true;Initial catalog=dbSofttransport";
            con = new SqlConnection(strConnection);
        }

        public bool AddEmployee(Employee employee)
        {
            cmd = new SqlCommand("proc_InsertEmployee",con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eName", employee.Name);
                cmd.Parameters.AddWithValue("@ePassword", employee.Password);
                cmd.Parameters.AddWithValue("@eLocation", employee.Location);
                cmd.Parameters.AddWithValue("@ePhone", employee.Phone);
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdatePassword(Employee employee)
        {
            cmd = new SqlCommand("proc_UpdatePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eId", employee.Id);
                cmd.Parameters.AddWithValue("@ePassword", employee.Password);
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public ICollection<Employee> SelectAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlCommand cmd = new SqlCommand("proc_GetAllEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daEmployee = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();//collection of datatables
            try
            {
                daEmployee.Fill(ds, "Employee");
                Employee employee;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employee = new Employee();
                    employee.Id = Convert.ToInt32(dr[0]);
                    employee.Name = dr[1].ToString();
                    employee.Password = dr[2].ToString();
                    employee.Location = dr[3].ToString();
                    employee.Phone = dr[4].ToString();
                    employee.VechicleNumber = dr[5].ToString();
                    employees.Add(employee);
                }
                return employees;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}