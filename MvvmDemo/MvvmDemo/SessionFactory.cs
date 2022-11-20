using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MvvmDemo.Mappings;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo
{
    public class SessionFactory
    {
        private static volatile ISessionFactory _iSessionFactory;
        private static object syncRoot = new object();
        public static ISession OpenSession
        {
            get
            {
                if(_iSessionFactory == null)
                {
                    lock (syncRoot)
                    {
                        if(_iSessionFactory == null)
                        {
                            _iSessionFactory = BuildSessionFactory();
                        }
                    }
                }
                return _iSessionFactory.OpenSession();
            }
        }

        private static ISessionFactory BuildSessionFactory()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.AppSettings["connection_string"];
                return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMapping>())
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(testc => testc.Namespace == "MvvmDemo.Models");
        }
        private static void BuildSchema(Configuration obj)
        {
            
        }
    }
}
