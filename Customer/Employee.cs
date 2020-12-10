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

        public Employee(string firstname, string surname)
        {
            FirstName = firstname;
            SurName = surname;
        }

        public override string ToString()
        {
            return string.Format("");

        }
    }

    public class FullTimeEmployee: Employee
    {

    }

    public class PartTimeEmployee: Employee
    {

    }

    

    
}
