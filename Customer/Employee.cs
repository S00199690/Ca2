using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    abstract class Employee: IComparable
    {
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }

        public double HoursWorked { get; set; }

        public abstract decimal CalculateMonthlyPay();

        public int CompareTo(object obj)
        {
            int returnValue;
            //Get a reference to the next object in the collection
            Employee that = (Employee)obj;



            //Indicate what field I want to compare
            if (this.SurName == that.SurName)
                returnValue = this.FirstName.CompareTo(that.FirstName);
            else
                returnValue = this.SurName.CompareTo(that.SurName);



            //return
            return returnValue;
        }
    }

    class FullTimeEmployee : Employee
    {

        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        }

        public FullTimeEmployee(string firstname, string surname, decimal salary)
        {
            FirstName = firstname;
            SurName = surname;
            Salary = salary;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - Full Time");
        }

    }

    class PartTimeEmployee: Employee
    {

        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * (decimal)HoursWorked;
        }

        public PartTimeEmployee(string firstname, string surname, decimal hourlyrate, double hoursworked)
        {
            FirstName = firstname;
            SurName = surname;
            HourlyRate = hourlyrate;
            HoursWorked = hoursworked;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - Part Time");
        }

    }

    

    
}
