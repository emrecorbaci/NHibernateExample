using NHibernateExample.Models;
using System.Collections.Generic;

namespace NHibernateExample.IServices
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
        IList<User> GetAll();



    }
}
