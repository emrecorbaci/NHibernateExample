using FluentNHibernate.Mapping;
using NHibernateExample.Models;

namespace NHibernateExample.Mapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("[User]");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Age).Nullable();
            Map(x => x.RegisterDate).Not.Nullable();
            //References(x => x.UserExperience).Cascade.All();
        }
    }
}
