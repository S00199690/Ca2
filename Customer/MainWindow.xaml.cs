using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Customer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //read name from textbox
            string firstName = tbxFirstName.Text;
            string surname = tbxSurname.Text;
            //string type = 

          //  FullTimeEmployee employee = new FullTimeEmployee(firstName, surname, type);

           // Employees.Add(employee);



            //add to list
            

            //refresh display
          

            
        }

            private void lbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            //tbxFirstName.Clear();
            //tbxSurname.Clear();
            //tbxHourlyRate.Clear();
            //tbxHoursWorked.Clear();
            //tbxSalary.Clear();
                Employee selectedEmployee = (Employee)lbxEmployees.SelectedItem;

                if (selectedEmployee is PartTimeEmployee)
                {
                    tbxFirstName.Text = selectedEmployee.FirstName;
                    tbxSurname.Text = selectedEmployee.SurName;
                    tbxHourlyRate.Text = selectedEmployee.HourlyRate.ToString();
                    tbxHoursWorked.Text = selectedEmployee.HoursWorked.ToString();
                    rbtnPartTime.IsChecked = true;
                }
                else if(selectedEmployee is FullTimeEmployee)
                {
                tbxFirstName.Text = selectedEmployee.FirstName;
                tbxSurname.Text = selectedEmployee.SurName;
                tbxSalary.Text = selectedEmployee.Salary.ToString();
                rbtnFullTime.IsChecked = true;
                }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FullTimeEmployee ft1 = new FullTimeEmployee("Steve", "Rogers", "Full", 30000);
            FullTimeEmployee ft2 = new FullTimeEmployee("Peggy", "Carter", "Full", 55000);

            PartTimeEmployee pt1 = new PartTimeEmployee("Tony", "Stark", "Part", 20, 50.5);
            PartTimeEmployee pt2 = new PartTimeEmployee("Pepper", "Potts", "Part", 15, 42);

            employees.Add(ft1);
            employees.Add(ft2);
            employees.Add(pt1);
            employees.Add(pt2);

           // lbxEmployees.ItemsSource = employees;
           
        }

        private void tbxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
        }

        private void tbxSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSurname.Clear();
        }

        private void cbxFullTime_Checked(object sender, RoutedEventArgs e)
        {
            filteredEmployees.Clear();
            lbxEmployees.ItemsSource = null;


            if (cbxFullTime.IsChecked == true && cbxPartTime.IsChecked == true)
            {
                foreach (Employee employee in employees)
                {
                    filteredEmployees.Add(employee);
                }
                lbxEmployees.ItemsSource = filteredEmployees;
            }
            else
            {
                if (cbxFullTime.IsChecked == true)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee is FullTimeEmployee)
                        {
                            filteredEmployees.Add(employee);
                        }
          
                    }
                    lbxEmployees.ItemsSource = filteredEmployees;
                }
                else if (cbxPartTime.IsChecked == true)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee is PartTimeEmployee)
                        {
                            filteredEmployees.Add(employee);
                        }
                       
                    }
                    lbxEmployees.ItemsSource = filteredEmployees;

                }
                else if (cbxPartTime.IsChecked == false && cbxFullTime.IsChecked == false)
                {
                    filteredEmployees.Clear();
                    lbxEmployees.ItemsSource = filteredEmployees;
                }

            }
        }

        private void cbxFullTime_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxPartTime.IsChecked == false && cbxFullTime.IsChecked == false)
            {
                filteredEmployees.Clear();
                lbxEmployees.ItemsSource = filteredEmployees;
            }
            else if (cbxFullTime.IsChecked == false)
            {
                foreach (Employee employee in employees)
                {
                    if (employee is FullTimeEmployee)
                    {
                        filteredEmployees.Remove(employee);
                    }
                }
            }
            else if(cbxPartTime.IsChecked == false)
            {
                foreach (Employee employee in employees)
                {
                    if (employee is PartTimeEmployee)
                    {
                        filteredEmployees.Remove(employee);
                    }
                }
            }
        }
    }
}
