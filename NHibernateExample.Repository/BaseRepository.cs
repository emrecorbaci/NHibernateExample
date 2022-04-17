using NHibernate;
using NHibernateExample.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NHibernateExample.Repository
{
    public class BaseRepository<T> : ICrudRepository<T> where T : class
    {
        public BaseRepository()
        {
            
        }
        public void Delete(T entity)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Delete(entity);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }
                        throw new Exception("Delete Error : " + ex.Message);
                    }
                }
            }
        }

        public IList<T> GetAll()
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                try
                {
                    return _session.Query<T>().ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("GetAll Error : " + ex.Message);
                }
            }
        }

        public T GetById(int id)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                try
                {
                    return _session.Get<T>(id);
                }
                catch (Exception ex)
                {
                    throw new Exception("GetById Error : " + ex.Message);
                }
            }
        }

        public void Insert(T entity)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entity);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }
                        throw new Exception("Insert Error : " + ex.Message);
                    }
                }
            }
        }

        public void Update(T entity)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Update(entity);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }
                        throw new Exception("Update Error : " + ex.Message);
                    }
                }
            }
        }
    }
}
