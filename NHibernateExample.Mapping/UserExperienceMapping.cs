using FluentNHibernate.Mapping;
using NHibernateExample.Models;

namespace NHibernateExample.Mapping
{
    public class UserExperienceMapping : ClassMap<UserExperience>
    {
        public UserExperienceMapping()
        {
            Table("UserExperienceMapping");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Description);
            Map(x => x.ExperienceCount).Not.Nullable();
            Map(x => x.UserId);
            Map(x => x.RegisterDate);


        }
    }
}
