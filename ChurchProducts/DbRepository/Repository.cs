using DbModels;
using Microsoft.EntityFrameworkCore;
using DbModels.ModelBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectBase.DbRepository
{
    public class Repository<T> : IRepository<T> where T : class, ITablesBase
    {
        protected readonly ApplicationDbContext _context;
        public DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IList<T> GetAllWithIncludes(params Expression<Func<T, object>>[] predicates)
        {
            var QuarableEntities = _context.Set<T>().AsQueryable();
            foreach (var predicate in predicates)
            {
                QuarableEntities = QuarableEntities.Include(predicate);
            }
            return QuarableEntities.ToList();
        }

        public IList<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(object id)
        {
            return entities.Find(id);
        }

        public List<T> GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate).ToList();
        }

        public T GetByIdNoTracking(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate).AsNoTracking().FirstOrDefault();
        }

        public async Task<T> GetByIdNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public void CreatNew(T entity)
        {
            if (entity == null)
            { }
            entity.AddedOn = DateTime.Now;
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void RemoveByExpression(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                return;
            var models = entities.Where(predicate).ToList();
            if (models.Count > 0)
            {
                entities.RemoveRange(models);
                _context.SaveChanges();
            }
        }

        public void Remove(object id)
        {
            if (id == null)
                return;

            T exist = entities.Find(id);
            exist.DeletedOn = DateTime.Now;
            entities.Remove(exist);
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            if (model == null) { }
            model.ModifiedOn = DateTime.Now;
            entities.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await entities.FindAsync(id);
        }
        public async Task CreatNewAsync(T entity)
        {
            if (entity == null)
            { }
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(object id)
        {
            if (id == null)
            { }

            T exist = await entities.FindAsync(id);
            entities.Remove(exist);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T model)
        {
            if (model == null) { }
            entities.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



        public void RemoveAll(List<T> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                this.entities.RemoveRange(entities);
                _context.SaveChanges();
            }
        }

        public async Task RemoveAllAsync(List<T> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                this.entities.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
        }


        public virtual PropertyInfo GetKey(T entity)
        {
            var keyName = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            return entity.GetType().GetProperty(keyName);
        }
    }
}
