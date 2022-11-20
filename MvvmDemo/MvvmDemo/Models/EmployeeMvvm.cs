using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MvvmDemo.Models
{
    public class EmployeeMvvm 
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Age { get; set; }
    }
}
