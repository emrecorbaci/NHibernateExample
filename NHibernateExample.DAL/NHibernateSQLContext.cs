using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernateExample.Mapping;

namespace NHibernateExample.DB
{
    public class NHibernateSQLContext
    {

        private static ISessionFactory session;
        private static ISessionFactory CreateSession()
        {
            if (session != null)
            {
                return session;
            }
            
            var connectionStringFromConfig = System.Configuration.ConfigurationManager.ConnectionStrings["MSSQL_NHibernateDB"].ConnectionString;

            //FluentConfiguration _fluentConfiguration = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(/* that part can take from config */
            //x => x.Server(".").Username("sa").Password("sdfresDf234234Df34r!?").Database("NHibernateDB")
            var _fluentConfiguration = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                connectionStringFromConfig
                ).ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<UserExperienceMapping>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<UserMapping>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
            // options for check or not check the diffirences on the database 
            //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true)); 
            //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true)); 

            /*
              Note : 
                1.First run can need the create database
                2.Table class names must be different from sql special names for syntax
             */

            session = _fluentConfiguration.BuildSessionFactory();

            return session;
        }
        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}
