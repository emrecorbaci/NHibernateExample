using System;

namespace NHibernateExample.Models
{
    public class UserExperience
    {
        public virtual int Id { get; set; }

        public virtual int UserId { get; set; }

        public virtual string Description { get; set; }

        public virtual int ExperienceCount { get; set; }

        public virtual DateTime RegisterDate { get; set; }
    }
}
