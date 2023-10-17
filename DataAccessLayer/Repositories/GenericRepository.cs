using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T p)
        {
            using var c = new Context();
            c.Set<T>().Add(p);
            c.SaveChanges();
        }

        public void Delete(T p)
        {
            using var c = new Context();
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
            
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Update(T p)
        {
            using var c = new Context();
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
    }
}
