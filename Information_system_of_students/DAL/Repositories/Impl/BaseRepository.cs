using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Information_system_of_students.DAL.EF;
using Information_system_of_students.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Information_system_of_students.DAL.Repositories.Interfaces;

namespace Information_system_of_students.DAL.Repositories.Impl
{
    public abstract class BaseRepository<T>
        : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> _set;
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        void IRepository<T>.Create(T item)
        {
            _set.Add(item);
        }
        IEnumerable<T> IRepository<T>.Find(
            Func<T, bool> predicate,
            int pageNumber = 0,
            int pageSize = 10)
        {
            return
                _set.Where(predicate)
                    .Skip(pageSize * pageNumber)
                    .Take(pageNumber)
                    .ToList();
        }
        T IRepository<T>.Get(int id)
        {
            return _set.Find(id);
        }

        void IRepository<T>.Delete(int id)
        {
            var item = Get(id);
            _set.Remove(item);
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return _set.ToList();
        }

        void IRepository<T>.Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
