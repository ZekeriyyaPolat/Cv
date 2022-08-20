using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Cv.Models.Entity;

namespace Cv.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        CvEntities c = new CvEntities();

        public List<T> List()
        {
            return c.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }

        public void TDelete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }

        public T TGet(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void TUpdate(T p)
        {
            c.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return c.Set<T>().FirstOrDefault(where);
        }
    }
}