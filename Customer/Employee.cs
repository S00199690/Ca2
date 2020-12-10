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

        abstract decimal CalculateMonthlyPay()
        {
            
        }

        public Employee()
        {
            
        }

        public override string ToString()
        {
            return string.Format("");

        }
    }

    abstract class FullTimeEmployee: Employee
    {
        public decimal Salary { get; set; }
    }

    abstract class PartTimeEmployee: Employee
    {
        public decimal HourlyRate { get; set; }

        public double HoursWorked { get; set; }
    }

    

    
}
