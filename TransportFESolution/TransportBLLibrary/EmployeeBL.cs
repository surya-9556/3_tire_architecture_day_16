using System;
using System.Collections.Generic;
using System.Linq;
using TransportDALLibrary;

namespace TransportBLLibrary
{
    public class EmployeeBL : IRepo<Employee>, IUserLogin<Employee>
    {
        EmployeeDAL dal;
        public EmployeeBL()
        {
            dal = new EmployeeDAL();
        }

        public bool Add(Employee t)
        {
            try
            {
                return dal.AddEmployee(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ICollection<Employee> GetAll()
        {
            List<Employee> employees;
            try
            {
                employees = dal.SelectAllEmployees().ToList();
                return employees;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Login(Employee t)
        {
            bool result = false;
            
            try
            {
                List<Employee> employees = GetAll().ToList();
                Employee employee = employees.Find(e => e.Id == t.Id && e.Password == t.Password);
                if (employee != null)
                    result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public bool Update(Employee t)
        {
            try
            {
                return dal.UpdatePassword(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}