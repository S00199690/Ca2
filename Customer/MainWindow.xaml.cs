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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //read name from textbox
            string newName = tbxFirstName.Text + tbxSurname.Text;

            //add to list
            

            //refresh display
          

            
        }

        private void lbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FullTimeEmployee ft1 = new FullTimeEmployee("John", "Lennon");

            ftEmployees.Add(ft1);

            lbxEmployees.ItemsSource = ftEmployees;
           
        }
    }
}
