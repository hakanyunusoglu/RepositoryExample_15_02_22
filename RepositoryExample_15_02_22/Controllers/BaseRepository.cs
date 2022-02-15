using RepositoryExample_15_02_22.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepositoryExample_15_02_22.Controllers
{
    public class BaseRepository<T> where T : class, new()
    {
        NorthwindEntities db = new NorthwindEntities();
        public DbSet<T> Set()
        {
            return db.Set<T>();
        }
        public List<T> Listele()
        {
            return Set().ToList();
        }
        public IQueryable<T> GenelListe()
        {
            return Set().AsQueryable();
        }
        public void Ekle(T entity)
        {
            Set().Add(entity);
           // db.Entry(entity).State = EntityState.Added;
        }
        public void Sil(T entity)
        {
            Set().Remove(entity);
           // db.Entry(entity).State = EntityState.Deleted;
        }
        public void Guncel()
        {
            db.SaveChanges();
        }
        public T Bul(int id)
        {
            return Set().Find(id);
        }
        public T Bul(string id)
        {
            return Set().Find(id);
        }
    }
}