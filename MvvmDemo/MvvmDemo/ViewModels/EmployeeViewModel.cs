using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MvvmDemo.Models;

namespace MvvmDemo.ViewModels
{
    public class EmployeeViewModel 
    {
        EmployeeService employeeService;

        public EmployeeViewModel()
        {
            employeeService = new EmployeeService();
            loadData();
        }

        public void loadData()
        {
            EmployeeList = employeeService.Get();
        }

        public void SaveOrUpdate(EmployeeMvvm employeeMvvm)
        {
            employeeService.Post(employeeMvvm);
        }

        public EmployeeMvvm Get(int id)
        {
            return employeeService.Get(id);
        }
        public void Delete(EmployeeMvvm employeeMvvm)
        {
            employeeService.Delete(employeeMvvm);
        }

        public List<EmployeeMvvm> EmployeeList { get; set; }
    }
}
