using System;
using System.Collections.Generic;
using System.Text;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEApplication
{
    class EmployeeLogin
    {
        IUserLogin<Employee> _Login;
        public EmployeeLogin()
        {

        }

        public EmployeeLogin(IUserLogin<Employee> login)
        {
            _Login = login;
        }

        public void UserLogin()
        {
            Console.WriteLine("Please Enter the employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the password");
            string password = Console.ReadLine();
            Employee employee = new Employee();
            employee.Id = id;
            employee.Password = password;
            try
            {
                if (_Login.Login(employee))
                {
                    Console.WriteLine("Welcome");
                }
                else
                {
                    Console.WriteLine("Incorrect credintals");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("login exception");
                Console.WriteLine(e.Message);
            }
        }

        public void RegisterEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_Login.Add(employee))
                    Console.WriteLine("Employee added");
                else
                    Console.WriteLine("Sorry cannot add the employee");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add employee");
                Console.WriteLine(e.Message);
            }
        }
    }
}
