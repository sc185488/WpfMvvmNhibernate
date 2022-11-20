using MvvmDemo.Models;
using MvvmDemo.ViewModels;
using System;
using System.Collections.Generic;
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
using System.ComponentModel;

namespace MvvmDemo.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl , INotifyPropertyChanged
    {
        EmployeeViewModel employeeViewModel; 
        public EmployeeView()
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel();
            this.DataContext = employeeViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        Window window = new Window();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtId.Text == "" || txtId.Text == null)
            {
                EmployeeMvvm employeeMvvm = new EmployeeMvvm();
                employeeMvvm.Name = txtName.Text;
                employeeMvvm.Age = txtAge.Text;
                employeeViewModel = new EmployeeViewModel();
                employeeViewModel.SaveOrUpdate(employeeMvvm);

                txtId.Text = "";
                txtName.Text = "";
                txtAge.Text = "";

                employeeViewModel.loadData();
                
                window.Close();
            }
            else
            {
                EmployeeMvvm employeeMvvm = new EmployeeMvvm();
                employeeMvvm.Id = Convert.ToInt32(txtId.Text);
                employeeMvvm.Name = txtName.Text;
                employeeMvvm.Age = txtAge.Text;
                employeeViewModel = new EmployeeViewModel();
                employeeViewModel.SaveOrUpdate(employeeMvvm);

                txtId.Text = "";
                txtName.Text = "";
                txtAge.Text = "";
                window.Close();
            }
        }

        private void dgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtId.Text = ((MvvmDemo.Models.EmployeeMvvm)e.AddedItems[0]).Id.ToString();
            txtName.Text = ((MvvmDemo.Models.EmployeeMvvm)e.AddedItems[0]).Name.ToString();
            txtAge.Text = ((MvvmDemo.Models.EmployeeMvvm)e.AddedItems[0]).Age.ToString();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            EmployeeMvvm employeeMvvm = employeeViewModel.Get(id);

            txtId.Text = employeeMvvm.Id.ToString();
            txtName.Text = employeeMvvm.Name;
            txtAge.Text = employeeMvvm.Age;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeMvvm employeeMvvm = new EmployeeMvvm();
            employeeMvvm.Id = Convert.ToInt32(txtId.Text);
            employeeMvvm.Name = txtName.Text;
            employeeMvvm.Age = txtAge.Text;

            employeeViewModel.Delete(employeeMvvm);

            txtId.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            window.Close();
        }
    }
}
