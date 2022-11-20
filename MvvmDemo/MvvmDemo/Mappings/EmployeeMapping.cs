using FluentNHibernate.Mapping;
using MvvmDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.Mappings
{
    public class EmployeeMapping : ClassMap<Models.EmployeeMvvm>
    {
        public EmployeeMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Age).Not.Nullable();
            Table("EmployeeMvvm");
        }
    }
}
