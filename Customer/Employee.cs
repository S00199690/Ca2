using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    abstract class Employee
    {
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Type { get; set; }

        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }

        public double HoursWorked { get; set; }

        public abstract decimal CalculateMonthlyPay();


    }

    class FullTimeEmployee : Employee
    {

        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        }

        public FullTimeEmployee(string firstname, string surname, string type, decimal salary)
        {
            FirstName = firstname;
            SurName = surname;
            Type = type;
            Salary = salary;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - {Type} Time");
        }

    }

    class PartTimeEmployee: Employee
    {

        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * (decimal)HoursWorked;
        }

        public PartTimeEmployee(string firstname, string surname, string type, decimal hourlyrate, double hoursworked)
        {
            FirstName = firstname;
            SurName = surname;
            Type = type;
            HourlyRate = hourlyrate;
            HoursWorked = hoursworked;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - {Type} Time");
        }

    }

    

    
}
