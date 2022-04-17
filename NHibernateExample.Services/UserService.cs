using NHibernateExample.IServices;
using NHibernateExample.Models;
using NHibernateExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateExample.Services
{
    public class UserService : IUserService
    {
        private readonly BaseRepository<User> _baseRepository = new BaseRepository<User>();
        public void Add(User user)
        {
            _baseRepository.Insert(user);
        }

        public void Delete(User user)
        {
            _baseRepository.Delete(user);
        }

        public IList<User> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public void Update(User user)
        {
            _baseRepository.Update(user);
        }
    }
}
