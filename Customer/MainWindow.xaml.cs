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
   #region code
    public partial class MainWindow : Window
    {
        SolidColorBrush greyedOut = new SolidColorBrush(Color.FromRgb(0xa5, 0xa5, 0xa5));
        List<Employee> employees = new List<Employee>();
        ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();


        public MainWindow()
        {
            InitializeComponent();
            cbxFullTime.IsChecked = true;
            cbxPartTime.IsChecked = true;
            FullTimeEmployee ft1 = new FullTimeEmployee("Steve", "Rogers", "Full", 30000);
            FullTimeEmployee ft2 = new FullTimeEmployee("Peggy", "Carter", "Full", 55000);

            PartTimeEmployee pt1 = new PartTimeEmployee("Tony", "Stark", "Part", 20, 50.5);
            PartTimeEmployee pt2 = new PartTimeEmployee("Pepper", "Potts", "Part", 15, 42);

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

            if (rbtnPartTime.IsChecked == true)
            {
               PartTimeEmployee employee = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, "Part", decimal.Parse(tbxHoursWorked.Text), double.Parse(tbxHourlyRate.Text));
                employees.Add(employee);
            }
            else if(rbtnFullTime.IsChecked == true)
            {
                FullTimeEmployee employee = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, "Full", decimal.Parse(tbxSalary.Text));
                employees.Add(employee);
            }


            //refresh display
            employees.Sort();
            btnClear_Click(null, null);
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;

            
        }

            private void lbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

                Employee selectedEmployee = (Employee)lbxEmployees.SelectedItem;

                if (selectedEmployee is PartTimeEmployee)
                {
                    PartTimeEmployee employee = (PartTimeEmployee)selectedEmployee;
                    tbxSalary.Clear();
                    tbxFirstName.Text = employee.FirstName;
                    tbxSurname.Text = employee.SurName;
                    tbxHourlyRate.Text = employee.HourlyRate.ToString();
                    tbxHoursWorked.Text = employee.HoursWorked.ToString();
                    tbkMonthlyPay.Text = employee.CalculateMonthlyPay().ToString();
                    rbtnPartTime.IsChecked = true;
                }
                else if(selectedEmployee is FullTimeEmployee)
                {
                FullTimeEmployee employee = (FullTimeEmployee)selectedEmployee;
                tbxHoursWorked.Clear();
                tbxHourlyRate.Clear();
                tbxFirstName.Text = employee.FirstName;
                tbxSurname.Text = employee.SurName;
                tbxSalary.Text = employee.Salary.ToString();
                tbkMonthlyPay.Text = employee.CalculateMonthlyPay().ToString();
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
            employees.Remove((Employee)lbxEmployees.SelectedItem);

            if (rbtnFullTime.IsChecked == true)
            {
                FullTimeEmployee fullTime = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, "Full", decimal.Parse(tbxSalary.Text));
                employees.Add(fullTime);
            }
            else
            {
                PartTimeEmployee partTime = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, "Part", decimal.Parse(tbxHourlyRate.Text), double.Parse(tbxHoursWorked.Text));
                employees.Add(partTime);
            }
            employees.Sort();
            btnClear_Click(null, null);
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;
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

        private void rbtnFullTime_Checked(object sender, RoutedEventArgs e)
        {
            lblSalary.Foreground = Brushes.Black;
            tbxSalary.Background = Brushes.White;
            tbxSalary.IsEnabled = true;
            tbxSalary.Cursor = Cursors.IBeam;

            lblHourlyRate.Foreground = Brushes.Gray;
            tbxHourlyRate.Background = Brushes.Gray;
            tbxHourlyRate.IsEnabled = false;
            tbxHourlyRate.Cursor = Cursors.Arrow;

            lblHoursWorked.Foreground = Brushes.Gray;
            tbxHoursWorked.Background = Brushes.Gray;
            tbxHoursWorked.IsEnabled = false;
            tbxHoursWorked.Cursor = Cursors.Arrow;
        }

        private void rbtnPartTime_Checked(object sender, RoutedEventArgs e)
        {
            lblHourlyRate.Foreground = Brushes.Black;
            tbxHourlyRate.Background = Brushes.White;
            tbxHourlyRate.IsEnabled = true;
            tbxHourlyRate.Cursor = Cursors.IBeam;

            lblHoursWorked.Foreground = Brushes.Black;
            tbxHoursWorked.Background = Brushes.White;
            tbxHoursWorked.IsEnabled = true;
            tbxHoursWorked.Cursor = Cursors.IBeam;

            lblSalary.Foreground = Brushes.Gray;
            tbxSalary.Background = Brushes.Gray;
            tbxSalary.IsEnabled = false;
            tbxSalary.Cursor = Cursors.Arrow;
        }
    }
}
#endregion code