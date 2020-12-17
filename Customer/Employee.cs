using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    //base abstract class for employee
    //icomparable allows objects to be compared 
    abstract class Employee: IComparable
    {   
        //employee properties
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Type { get; set; }

        //employee constructor
        public Employee(string firstname, string surname, string type)
        {
            FirstName = firstname;
            SurName = surname;
            Type = type;
        }
        
        //abstract monthly pay method
        public abstract decimal CalculateMonthlyPay();

        //sort method
        public int CompareTo(object obj)
        {
            int returnValue;
            //Get a reference to the next object in the collection
            Employee that = (Employee)obj;



            //Indicate what field to be compared
            if (this.SurName == that.SurName)
                returnValue = this.FirstName.CompareTo(that.FirstName);
            else
                returnValue = this.SurName.CompareTo(that.SurName);



            //return
            return returnValue;
        }
    }

    //full time employee class
    class FullTimeEmployee : Employee
    {
        //salary property
        public decimal Salary { get; set; }

        //overrides the abstract method in the base class and returns monthly pay for full time employees
        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        }

        //full time constructor which inherits base class constructor
        public FullTimeEmployee(string firstname, string surname, string type, decimal salary): base(firstname, surname, type)
        {
            Salary = salary;   
        }

        //ToString method that formats the full time output into a string
        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - {Type} Time");
        }

    }

    //part time employee class
    class PartTimeEmployee: Employee
    {
        //part time properties
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        //overrides the abstract method in the base class and returns monthly pay for part time employees
        public override decimal CalculateMonthlyPay()
        {
            return HourlyRate * (decimal)HoursWorked;
        }

        //part time constructor that inherits base class constructor
        public PartTimeEmployee(string firstname, string surname, string type, decimal hourlyrate, double hoursworked): base (firstname, surname, type)
        {
            HourlyRate = hourlyrate;
            HoursWorked = hoursworked;
        }

        //ToString method that formats the part time output into a string
        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()}, {FirstName} - {Type} Time");
        }

    }

    

    
}
