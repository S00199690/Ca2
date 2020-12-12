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

        public abstract decimal CalculateMonthlyPay();


    }

    class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        }

        public FullTimeEmployee(string firstname, string surname, string type)
        {
            FirstName = firstname;
            SurName = surname;
            Type = type;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - {Type} Time");
        }

    }

    class PartTimeEmployee: Employee
    {
        public decimal HourlyRate { get; set; }

        public double HoursWorked { get; set; }

        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * (decimal)HoursWorked;
        }

        public PartTimeEmployee(string firstname, string surname, string type)
        {
            FirstName = firstname;
            SurName = surname;
            Type = type;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - {Type} Time");
        }

    }

    

    
}
