using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using InfoTrack.Core.Interface;
using InfoTrack.Infrastructure.Interface;
using InfoTrack.Infrastructure.Entities;

namespace InfoTrack.Infrastructure.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly InfoTrackContext context;
        private DbSet<T> dbSet;
        public Repository(InfoTrackContext infoTrackContext)
        {
            context = infoTrackContext;
            dbSet = context.Set<T>();
        }
     
        public IEnumerable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public DbSet<T> GetDbSet()
        {
            return dbSet;
        }


        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Insert(List<T> obj)
        {
            dbSet.AddRange(obj);
        }
        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            T getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }
    }
}
