using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.Models
{
    public class EmployeeService
    {
        public List<EmployeeMvvm> Get()
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                try
                {
                    IQuery iQuery = iSession.CreateQuery("FROM EmployeeMvvm");
                    IList<EmployeeMvvm> employees = iQuery.List<EmployeeMvvm>();
                    return employees.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
        public EmployeeMvvm Get(int Id)
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                try
                {
                    IQuery iQuery = iSession.CreateQuery("From EmployeeMvvm where Id = " + Id + "");
                    EmployeeMvvm employee = iQuery.List<EmployeeMvvm>()[0];
                    return employee;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
        public bool Post(EmployeeMvvm employeeMvvm)
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                using(ITransaction iTransaction = iSession.BeginTransaction())
                {
                    try
                    {
                        iSession.SaveOrUpdate(employeeMvvm);
                        iTransaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        iTransaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false;
                        throw;
                    }
                }
            }
        }
        public bool Delete(EmployeeMvvm employeeMvvm)
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                using(ITransaction iTransaction = iSession.BeginTransaction())
                {
                    try
                    {
                        iSession.Delete(employeeMvvm);
                        iTransaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        iTransaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false;
                        throw;
                    }
                }
            }
        }
    }
}
