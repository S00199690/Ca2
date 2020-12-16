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
        List<Employee> employees = new List<Employee>();
        ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();


        public MainWindow()
        {
            InitializeComponent();
            cbxFullTime.IsChecked = true;
            cbxPartTime.IsChecked = true;
            FullTimeEmployee ft1 = new FullTimeEmployee("Steve", "Rogers", 30000);
            FullTimeEmployee ft2 = new FullTimeEmployee("Peggy", "Carter", 55000);

            PartTimeEmployee pt1 = new PartTimeEmployee("Tony", "Stark", 20, 50.5);
            PartTimeEmployee pt2 = new PartTimeEmployee("Pepper", "Potts", 15, 42);

            employees.Add(ft1);
            employees.Add(ft2);
            employees.Add(pt1);
            employees.Add(pt2);

            employees.Sort();

            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //read name from textbox
            

            if (rbtnPartTime.IsChecked == true)
            {
               PartTimeEmployee employee = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxHoursWorked.Text), double.Parse(tbxHourlyRate.Text));
                employees.Add(employee);
            }
            else if(rbtnFullTime.IsChecked == true)
            {
                FullTimeEmployee employee = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxSalary.Text));
                employees.Add(employee);
            }


            //refresh display
            employees.Sort();
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;

            
        }

            private void lbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

                Employee selectedEmployee = (Employee)lbxEmployees.SelectedItem;

                if (selectedEmployee is PartTimeEmployee)
                {
                    tbxSalary.Clear();
                    tbxFirstName.Text = selectedEmployee.FirstName;
                    tbxSurname.Text = selectedEmployee.SurName;
                    tbxHourlyRate.Text = selectedEmployee.HourlyRate.ToString();
                    tbxHoursWorked.Text = selectedEmployee.HoursWorked.ToString();
                    tbkMonthlyPay.Text = selectedEmployee.CalculateMonthlyPay().ToString();
                    rbtnPartTime.IsChecked = true;
                }
                else if(selectedEmployee is FullTimeEmployee)
                {
                tbxHoursWorked.Clear();
                tbxHourlyRate.Clear();
                tbxFirstName.Text = selectedEmployee.FirstName;
                tbxSurname.Text = selectedEmployee.SurName;
                tbxSalary.Text = selectedEmployee.Salary.ToString();
                tbkMonthlyPay.Text = selectedEmployee.CalculateMonthlyPay().ToString();
                rbtnFullTime.IsChecked = true;
                }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
            tbxSurname.Clear();
            tbxSalary.Clear();
            tbxHoursWorked.Clear();
            tbxHourlyRate.Clear();
            rbtnFullTime.IsChecked = false;
            rbtnPartTime.IsChecked = false;
            tbkMonthlyPay.Text = null;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            employees.Remove((Employee)lbxEmployees.SelectedItem);
            btnClear_Click(null,null);

            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbxFullTime_Click(object sender, RoutedEventArgs e)
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
                if (cbxFullTime.IsChecked == true && cbxPartTime.IsChecked == false)
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
                else if (cbxPartTime.IsChecked == true && cbxFullTime.IsChecked == false)
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

        
    }
}
