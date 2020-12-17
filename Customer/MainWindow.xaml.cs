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
        //list for employees in the employee list box
        //observable collection for the filtered employees, no need to refresh display
        List<Employee> employees = new List<Employee>();
        ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();


        public MainWindow()
        {
            //upon running of program 2 objects from part and full time each are created
            InitializeComponent();
            //checkboxes are checked upon running
            cbxFullTime.IsChecked = true;
            cbxPartTime.IsChecked = true;
            FullTimeEmployee ft1 = new FullTimeEmployee("Steve", "Rogers", "Full", 30000);
            FullTimeEmployee ft2 = new FullTimeEmployee("Peggy", "Carter", "Full", 45000);

            PartTimeEmployee pt1 = new PartTimeEmployee("Tony", "Stark", "Part", 20, 50.5);
            PartTimeEmployee pt2 = new PartTimeEmployee("Pepper", "Potts", "Part", 15, 42);

            //adds each employee to the employees list
            employees.Add(ft1);
            employees.Add(ft2);
            employees.Add(pt1);
            employees.Add(pt2);

            //sorts the employees alphabetically
            employees.Sort();

            //refresh display
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;
        }

        //add button
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
                //selected employee object that refers to what is being selected in listbox
                //the item in the listbox is casted to an employee object
                Employee selectedEmployee = (Employee)lbxEmployees.SelectedItem;
                
                //checks if the selected item is a part time employee and displays the details in the necessary fields
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
            //checks if the selected item is a full time employee and displays the details in the necessary fields
            else if (selectedEmployee is FullTimeEmployee)
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

        //clear button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //each field to the right of listbox is cleared or set to false or null
            tbxFirstName.Clear();
            tbxSurname.Clear();
            tbxSalary.Clear();
            tbxHoursWorked.Clear();
            tbxHourlyRate.Clear();
            rbtnFullTime.IsChecked = false;
            rbtnPartTime.IsChecked = false;
            tbkMonthlyPay.Text = null;
        }

        //delete button
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //removes the employee currently selected from listbox
            employees.Remove((Employee)lbxEmployees.SelectedItem);

            //calls the btnClear_Click method to call the details in the fields
            btnClear_Click(null,null);

            //refresh display
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;
        }

        //update button
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //when the update button is clicked it removes the selected employee then adds them in again with the new details
            employees.Remove((Employee)lbxEmployees.SelectedItem);

            //checks if the full time radio button is selected and updates details as follows
            if (rbtnFullTime.IsChecked == true)
            {
                FullTimeEmployee fullTime = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, "Full", decimal.Parse(tbxSalary.Text));
                employees.Add(fullTime);
            }
            //checks if the part time radio button is selected and updates details as follows
            else if (rbtnPartTime.IsChecked == true)
            {
                PartTimeEmployee partTime = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, "Part", decimal.Parse(tbxHourlyRate.Text), double.Parse(tbxHoursWorked.Text));
                employees.Add(partTime);
            }
            //sorts the employee list
            employees.Sort();
            //calls the btnClear_Click method to call the details in the fields
            btnClear_Click(null, null);

            //refresh display
            lbxEmployees.ItemsSource = null;
            lbxEmployees.ItemsSource = employees;
        }

        //filter checkboxes
        private void cbxFullTime_Click(object sender, RoutedEventArgs e)
        {
            //clears any objects currently in the collection and sets the listbox to null
            filteredEmployees.Clear();
            lbxEmployees.ItemsSource = null;

            //if both full time and part time checkboxes are ticked add in all employees
            if (cbxFullTime.IsChecked == true && cbxPartTime.IsChecked == true)
            {
                foreach (Employee employee in employees)
                {
                    filteredEmployees.Add(employee);
                }
                //display employees in listbox
                lbxEmployees.ItemsSource = filteredEmployees;
            }
            else
            {
                //if full time is checked and not part time display full time employees
                if (cbxFullTime.IsChecked == true && cbxPartTime.IsChecked == false)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee is FullTimeEmployee)
                        {
                            filteredEmployees.Add(employee);
                        }

                    }
                    //display employees in listbox
                    lbxEmployees.ItemsSource = filteredEmployees;
                }
                //if part time is checked and not full time display part time employees
                else if (cbxPartTime.IsChecked == true && cbxFullTime.IsChecked == false)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee is PartTimeEmployee)
                        {
                            filteredEmployees.Add(employee);
                        }

                    }
                    //display employees in listbox
                    lbxEmployees.ItemsSource = filteredEmployees;

                }
                //if both boxes are not ticked no employees are displayed
                else if (cbxPartTime.IsChecked == false && cbxFullTime.IsChecked == false)
                {
                    //clears the filteredEmployees collection and outputs empty collection
                    filteredEmployees.Clear();
                    lbxEmployees.ItemsSource = filteredEmployees;
                }

            }
        }

        //full time radio button checked
        private void rbtnFullTime_Checked(object sender, RoutedEventArgs e)
        {
            //greys out hourly rate box so no data can be entered
            lblHourlyRate.Foreground = Brushes.Gray;
            tbxHourlyRate.Background = Brushes.Gray;
            tbxHourlyRate.IsEnabled = false;
            tbxHourlyRate.Cursor = Cursors.Arrow;
            //keeps the salary box to allow for data to be entered for full time employee
            lblSalary.Foreground = Brushes.Black;
            tbxSalary.Background = Brushes.White;
            tbxSalary.IsEnabled = true;
            tbxSalary.Cursor = Cursors.IBeam;
            //greys out hours worked box so no data can be entered
            lblHoursWorked.Foreground = Brushes.Gray;
            tbxHoursWorked.Background = Brushes.Gray;
            tbxHoursWorked.IsEnabled = false;
            tbxHoursWorked.Cursor = Cursors.Arrow;
        }

        //part time radio button checked
        private void rbtnPartTime_Checked(object sender, RoutedEventArgs e)
        {
            //keeps the hourly rate box to allow for data to be entered for part time employee
            lblHourlyRate.Foreground = Brushes.Black;
            tbxHourlyRate.Background = Brushes.White;
            tbxHourlyRate.IsEnabled = true;
            tbxHourlyRate.Cursor = Cursors.IBeam;
            //keeps the hours worked box to allow for data to be entered for part time employee
            lblHoursWorked.Foreground = Brushes.Black;
            tbxHoursWorked.Background = Brushes.White;
            tbxHoursWorked.IsEnabled = true;
            tbxHoursWorked.Cursor = Cursors.IBeam;
            //greys out salary box so no data can be entered
            lblSalary.Foreground = Brushes.Gray;
            tbxSalary.Background = Brushes.Gray;
            tbxSalary.IsEnabled = false;
            tbxSalary.Cursor = Cursors.Arrow;
        }
    }
}
#endregion code