using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        LibraryDBEntities context = new LibraryDBEntities();
        public void Delete(int id)
        {
            this.context.Set<T>().Remove(Get(id));
            this.context.SaveChanges();
        }

        public T Get(int id)
        {
           return this.context.Set<T>().Find();
        }

        public List<T> GetALLData()
        {
            return this.context.Set<T>().ToList();

        }
        public void Insert(T entity)
        {
                this.context.Set<T>().Add(entity);
                this.context.SaveChanges();              
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        
    }
}