using System;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEApplication
{
    class Program
    {
        EmployeeLogin Login;
        EmployeeManagement employee;
        EmployeeBL employees;
        DriverBl drivers;
        DriverManagement driver;
        public Program()
        {
            employees = new EmployeeBL();
            drivers = new DriverBl();
            Login = new EmployeeLogin(employees);
            employee = new EmployeeManagement(employees);
            driver = new DriverManagement(drivers);
        }
        public void PrintMenu()
        {
            Program program = new Program();
            int choice = 0;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Menu");
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Driver");
                Console.WriteLine("3. Exit");
                Console.WriteLine("----------------------------");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        program.PrintEmployeeMenu();
                        break;
                    case 2:
                        program.PrintDriversMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting............!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalied choice..........!!");
                        break;
                }
            } while (choice != 3);
        }

        public void PrintEmployeeMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Menu");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Print all");
                Console.WriteLine("5. Sort employees");
                Console.WriteLine("6. Print employee by id");
                Console.WriteLine("7. Exit");
                Console.WriteLine("----------------------------");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Login.RegisterEmployee();
                        break;
                    case 2:
                        Login.UserLogin();
                        break;
                    case 3:
                        employee.ResetPassword();
                        break;
                    case 4:
                        employee.PrintAllEmployee();
                        break;
                    case 5:
                        employee.SortEmployee();
                        break;
                    case 6:
                        employee.PrintEmployeesSortedById();
                        break;
                    case 7:
                        Console.WriteLine("Exiting............!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalied choice..........!!");
                        break;
                }
            } while (choice != 7);
        }

        public void PrintDriversMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Drivers Menu");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Print all");
                Console.WriteLine("4. Sort employees");
                Console.WriteLine("5. Print employee by id");
                Console.WriteLine("6. Exit");
                Console.WriteLine("----------------------------");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        driver.CreateDriver();
                        break;
                    case 2:
                        driver.UpdateDriver();
                        break;
                    case 3:
                        driver.PrintAllDrivers();
                        break;
                    case 4:
                        driver.SortDriver();
                        break;
                    case 5:
                        driver.PrintDriversSortedById();
                        break;
                    case 6:
                        Console.WriteLine("Exiting............!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalied choice..........!!");
                        break;
                }
            } while (choice != 6);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PrintMenu();
            Console.ReadKey();
        }
    }
}
