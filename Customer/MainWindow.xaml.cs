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
        ObservableCollection<FullTimeEmployee> ftEmployees = new ObservableCollection<FullTimeEmployee>();

        ObservableCollection<PartTimeEmployee> ptEmployees = new ObservableCollection<PartTimeEmployee>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //read name from textbox
            string firstName = tbxFirstName.Text;
            string surname = tbxSurname.Text;

            FullTimeEmployee employee = new FullTimeEmployee(firstName, surname);

            ftEmployees.Add(employee);



            //add to list
            

            //refresh display
          

            
        }

        private void lbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FullTimeEmployee selectedEmployee = (FullTimeEmployee)lbxEmployees.SelectedItem;

            if(selectedEmployee != null)
            {
                tbxFirstName.Text = selectedEmployee.FirstName;
                tbxSurname.Text = selectedEmployee.SurName;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FullTimeEmployee ft1 = new FullTimeEmployee("Steve", "Rogers");
            FullTimeEmployee ft2 = new FullTimeEmployee("Peggy", "Carter");

            PartTimeEmployee pt1 = new PartTimeEmployee("Tony", "Stark");
            PartTimeEmployee pt2 = new PartTimeEmployee("Pepper", "Potts");

            ftEmployees.Add(ft1);
            ftEmployees.Add(ft2);

            ptEmployees.Add(pt1);
            ptEmployees.Add(pt2);

            lbxEmployees.ItemsSource = ftEmployees;
            //lbxEmployees.ItemsSource = ptEmployees;
           
        }

        private void tbxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
        }

        private void tbxSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSurname.Clear();
        }
    }
}
