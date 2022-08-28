#region Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using HartleyMedical.Application.RepositoryInterfaces;
using HartleyMedical.Infrastructure.Persistence;

#endregion

namespace HartleyMedical.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        protected GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> Get(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual IList<T> GetMany(Func<T, bool> where, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).ToList();
        }
        public virtual T GetFirst(Func<T, bool> where, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).Where(where).FirstOrDefault();
        }

        public bool Exists(Func<T, bool> where)
        {
            return _context.Set<T>().Any(where);
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task AddRange(IList<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Delete(object id)
        {
            var entityToDelete = _context.Set<T>().Find(id);
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
            }
        }

        public void Delete(Func<T, bool> where)
        {
            IQueryable<T> objects = _context.Set<T>().Where<T>(where).AsQueryable();
            _context.Set<T>().RemoveRange(objects);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}