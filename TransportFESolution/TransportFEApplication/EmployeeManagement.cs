﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEApplication
{
    class EmployeeManagement
    {
        IRepo<Employee> _repo;
        public EmployeeManagement()
        {

        }
        public EmployeeManagement(IRepo<Employee> repo)
        {
            _repo = repo;
        }

        public void CreateEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_repo.Add(employee))
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
        public void ResetPassword()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the employee id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the old password");
            string password = Console.ReadLine();
            Employee employee1 = GetAllEmployee().Find(e => e.Id == id && e.Password == password);
            try
            {
                if (employee != null)
                {
                    Console.WriteLine("Please enter the new password");
                    var newPassword = Console.ReadLine();
                    Console.WriteLine("Please retype new password");
                    var RetypePassword = Console.ReadLine();
                    if(newPassword == RetypePassword)
                    {
                        employee.Password = newPassword;
                        if (_repo.Update(employee))
                        {
                            Console.WriteLine("Password updated");
                        }
                        else
                        {
                            Console.WriteLine("Please try again");
                        }
                    }
                    else
                        Console.WriteLine("Password missmatch");
                }
                else
                    Console.WriteLine("Could not update password");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return employees;
        }
        public void PrintAllEmployee()
        {
            var employees = GetAllEmployee();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public List<CompleteEmployee> SortEmployee()
        {
            List<CompleteEmployee> employees = new List<CompleteEmployee>();
            foreach (var item in GetAllEmployee())
            {
                employees.Add(new CompleteEmployee(item));
            }
            return employees;
        }
        public void PrintEmployeesSortedById()
        {
            var employees = SortEmployee();
            employees.Sort();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}