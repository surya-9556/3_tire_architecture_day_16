using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TransportDALLibrary;

namespace TransportFEApplication
{
    public class CompleteEmployee : Employee, IComparable<Employee>
    {
        const string INITIAL_PASSWORD = "1234";
        public CompleteEmployee()
        {

        }
        public CompleteEmployee(Employee employee)
        {
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.Password = employee.Password;
            this.VechicleNumber = employee.VechicleNumber;
            this.Location = employee.Location;
            this.Phone = employee.Phone;
        }
        public int CompareTo([AllowNull] Employee other)
        {
            return this.Id.CompareTo(other.Id);
        }
        public void TakeEmployeeData()
        {
            Console.WriteLine("Please enter the employee Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the employee Location");
            Location = Console.ReadLine();
            Console.WriteLine("Please enter the employee Phone number");
            Phone = Console.ReadLine();
            Password = INITIAL_PASSWORD;
        }

        public override string ToString()
        {
            string MaskedPassword = GetMaskedPassword(Password);
            return "Id: "+Id+" Name: "+Name+" Location: "+" Phone: "+Phone+" Password : " + MaskedPassword;
        }

        private string GetMaskedPassword(string password)
        {
            string result = password.Substring(0, 2);
            for (int i = 2; i < password.Length; i++)
            {
                result += "*";
            }
            return result;
        }
    }
}
