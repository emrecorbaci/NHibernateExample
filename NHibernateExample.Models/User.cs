using System;
using System.Collections.Generic;

namespace NHibernateExample.Models
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual int Age { get; set; }


        public virtual DateTime RegisterDate { get; set; }

        public virtual IList<UserExperience> UserExperience { get; set; }

        public User()
        {
            UserExperience = new List<UserExperience>();
        }

    }
}
