using Microsoft.EntityFrameworkCore;
using AdlezRestaurant.DataAccessLayer.IRepository;
using AdlezRestaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly RMContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(RMContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity, bool saved=false)
        {
            _dbSet.Add(entity);
            if (saved)
            {
                _context.SaveChanges();
            }
        }

        public bool Contains(T entity)
        {
            return _dbSet.Contains(entity);
        }

        public void Delete(T entity, bool saved = false)
        {
            _dbSet.Remove(entity);
            if (saved)
            {
                _context.SaveChanges();
            }
        }

        public void Delete(int id, bool saved = false)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            if (saved)
            {
                _context.SaveChanges();
            }
        }

        public async Task<T> FindAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public DbSet<T> GetAll()
        {
            return _dbSet;
        }

        public T GetEntity(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity, bool saved = false)
        {
            _dbSet.Update(entity);
            if (saved)
            {
                _context.SaveChanges();
            }
        }
    }
}
